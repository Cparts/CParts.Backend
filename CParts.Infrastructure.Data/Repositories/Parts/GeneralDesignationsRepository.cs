using System.Collections.Generic;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Abstractions.Repositories.Parts.Base;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Parts.Base;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class GeneralDesignationsRepository : DesignationRepositoryBase<GeneralDesignation>,
        IGeneralDesignationsRepository
    {
        public GeneralDesignationsRepository(IPartsDataDbContext context) : base(context)
        {
        }

        protected override DesignationReflectionAssigner<TEntity> CreateDesignationReflectionAssigner<TEntity>(
            IDesignationsRepository<GeneralDesignation> repository,
            ICollection<TEntity> entityCollection)
        {
            return new GeneralDesignationReflectionAssigner<TEntity>(repository, entityCollection);
        }

        protected class GeneralDesignationReflectionAssigner<TEntity> : DesignationReflectionAssigner<TEntity>
        {
            public GeneralDesignationReflectionAssigner(IDesignationsRepository<GeneralDesignation> repository,
                ICollection<TEntity> entityCollection) :
                base(repository, entityCollection)
            {
            }

            protected override bool IdPropertiesNamePredicate(string lowercasePropertyName)
            {
                return lowercasePropertyName.Contains("designation") &&
                       lowercasePropertyName.Contains("id") &&
                       !lowercasePropertyName.Contains("countrydesignation");
            }
        }
    }
}