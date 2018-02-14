using System.Collections.Generic;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Abstractions.Repositories.Parts;
using CParts.Domain.Abstractions.Repositories.Parts.Base;
using CParts.Domain.Core.Model.Parts;
using CParts.Infrastructure.Data.Repositories.Parts.Base;
using Microsoft.Extensions.Logging;

namespace CParts.Infrastructure.Data.Repositories.Parts
{
    public class CountryDesignationsRepository : DesignationRepositoryBase<CountryDesignation>,
        ICountryDesignationsRepository
    {
        public CountryDesignationsRepository(IPartsDataDbContext context) : base(context)
        {
        }

        protected override DesignationReflectionAssigner<TEntity> CreateDesignationReflectionAssigner<TEntity>(
            IDesignationsRepository<CountryDesignation> repository,
            ICollection<TEntity> entityCollection)
        {
            return new CountryDesignationReflectionAssigner<TEntity>(repository, entityCollection);
        }

        protected class CountryDesignationReflectionAssigner<TEntity> : DesignationReflectionAssigner<TEntity>
        {
            public CountryDesignationReflectionAssigner(IDesignationsRepository<CountryDesignation> repository,
                ICollection<TEntity> entityCollection) :
                base(repository, entityCollection)
            {
            }

            protected override bool IdPropertiesNamePredicate(string lowercasePropertyName)
            {
                return lowercasePropertyName.Contains("countrydesignation") &&
                       lowercasePropertyName.Contains("id");
            }
        }
    }
}