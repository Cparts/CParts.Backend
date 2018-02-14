using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Core.Model.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Contexts
{
    public class InternalDataDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, IInternalDataDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public InternalDataDbContext(DbContextOptions<InternalDataDbContext> options) : base(options)
        {
            
        }
    }
}