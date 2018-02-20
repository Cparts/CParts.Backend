using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Abstractions.Repositories.Internal;
using CParts.Domain.Core.Model.Internal;
using CParts.Infrastructure.Data.Contexts;
using CParts.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Repositories.Internal
{
    public class ApplicationUsersRepository : CrudRepositoryBase<ApplicationUser, string, IInternalDataDbContext>,
        IApplicationUsersRepository
    {
        public ApplicationUsersRepository(IInternalDataDbContext context) : base(context)
        {
        }

        protected override Expression<Func<ApplicationUser, bool>> KeyPredicate(string key) => (user => user.Id == key);

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            email = email.ToUpper();
            var query = from user in DbSet
                where user.NormalizedEmail == email
                select user;

            return await query.FirstOrDefaultAsync();
        }
    }
}