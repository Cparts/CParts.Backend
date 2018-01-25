using System.Threading;
using System.Threading.Tasks;
using CParts.Domain.Abstractions;
using CParts.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data
{
    public class CPartsContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, ICPartsContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}