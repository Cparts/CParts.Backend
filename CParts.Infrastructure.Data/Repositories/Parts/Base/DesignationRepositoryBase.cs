using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts.Base;
using CParts.Domain.Core.Model.Parts.Contracts;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Parts.Base
{
    public abstract class DesignationRepositoryBase<TDesignation> :
        ReadRepositoryBase<TDesignation, IPartsDataDbContext>,
        IDesignationsRepository<TDesignation> where TDesignation : class, IDesignation
    {
        public async Task<TDesignation> GetByIdAndLanguageAsync(int id, int languageId)
        {
            return await DbSet.AsNoTracking().Include(x => x.Text)
                .SingleOrDefaultAsync(x => x.Id == id && x.LanguageId == languageId);
        }

        public async Task<ICollection<TDesignation>> GetByIdAndLanguageAsync(IEnumerable<int?> ids, int languageId)
        {
            return await DbSet.AsNoTracking().Include(x => x.Text)
                .Where(x => ids.Contains(x.Id) && x.LanguageId == languageId).ToListAsync();
        }

        protected DesignationRepositoryBase(IPartsDataDbContext context) : base(context)
        {
        }

        public async Task<ICollection<TEntity>> AppendDesignationsToCollectionAsync<TEntity>(
            ICollection<TEntity> entityCollection,
            int languageId = 4)
        {
            var reflectionAssigner = CreateDesignationReflectionAssigner(this, entityCollection);

            await reflectionAssigner.ExecuteAsync(languageId);

            return entityCollection;
        }

        protected abstract DesignationReflectionAssigner<TEntity> CreateDesignationReflectionAssigner<TEntity>(
            IDesignationsRepository<TDesignation> repository, ICollection<TEntity> entityCollection);

        protected abstract class DesignationReflectionAssigner<TEntity>
        {
            private readonly IDictionary<int, ICollection<PropertyNameToEntityIdLink>> _entityHashPropertyLinks;
            private ICollection<PropertyInfo> _idPropertyList;
            private ICollection<PropertyInfo> _targetPropertyList;
            private readonly ICollection<TEntity> _entityList;
            private ICollection<TDesignation> _designationList;
            private readonly ICollection<int?> _databaseDesignationIdList;
            private readonly IDesignationsRepository<TDesignation> _repository;

            protected DesignationReflectionAssigner(IDesignationsRepository<TDesignation> repository,
                ICollection<TEntity> entityCollection)
            {
                _repository = repository;
                _entityList = entityCollection;
                _entityHashPropertyLinks = new Dictionary<int, ICollection<PropertyNameToEntityIdLink>>();
                _databaseDesignationIdList = new List<int?>();
            }

            public async Task<ICollection<TEntity>> ExecuteAsync(int languageId)
            {
                GetEntitiesDesignationProperties();
                CreateEntityHashToPropertyLinks();
                await GetDesignationsFromDb(languageId);
                SetEntitiesProperties();
                return _entityList;
            }

            private async Task GetDesignationsFromDb(int languageId)
            {
                _designationList = await _repository.GetByIdAndLanguageAsync(_databaseDesignationIdList, languageId);
            }

            private void GetEntitiesDesignationProperties()
            {
                var entityProperties = _entityList.GetType().GetGenericArguments()[0].GetProperties();

                _targetPropertyList = entityProperties.Where(property =>
                    property.PropertyType == typeof(TDesignation)).ToList();

                _idPropertyList = entityProperties.Where(property =>
                {
                    var lowercasePropertyName = property.Name.ToLower();
                    return IdPropertiesNamePredicate(lowercasePropertyName);
                }).ToList();
            }

            protected abstract bool IdPropertiesNamePredicate(string lowercasePropertyName);

            private void SetEntitiesProperties()
            {
                foreach (var entity in _entityList)
                {
                    var entityPropertyLinks = _entityHashPropertyLinks[entity.GetHashCode()];
                    foreach (var prop in _targetPropertyList)
                    {
                        var designations = _designationList.Where(x =>
                                x.Id == entityPropertyLinks.FirstOrDefault(y => y.Name == prop.Name.ToLower())?.Id)
                            .ToList();

                        var targetDesignation = designations.FirstOrDefault();
                        if (designations.Count > 1)
                        {
                            targetDesignation.Text.Text = designations.Aggregate(new StringBuilder(),
                                    (builder, designation) => builder.Append(designation.Text.Text).Append(", "))
                                .ToString()
                                .TrimEnd(' ', ',');
                        }

                        prop.SetValue(entity, targetDesignation);
                    }
                }
            }

            private void CreateEntityHashToPropertyLinks()
            {
                foreach (var entity in _entityList)
                {
                    var hash = entity.GetHashCode();
                    if (_entityHashPropertyLinks.ContainsKey(hash))
                        continue;
                    var list = new List<PropertyNameToEntityIdLink>();
                    foreach (var propertyName in _idPropertyList)
                    {
                        var id = Convert.ToInt32(propertyName.GetValue(entity));
                        _databaseDesignationIdList.Add(id);
                        list.Add(new PropertyNameToEntityIdLink
                        {
                            Id = id,
                            Name = propertyName.Name.ToLower().Replace("id", "")
                        });
                    }

                    _entityHashPropertyLinks.Add(hash, list);
                }
            }

            private class PropertyNameToEntityIdLink
            {
                public string Name { get; set; }
                public int Id { get; set; }
            }
        }
    }
}