using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Wish.Authorization.Roles;
using Wish.Authorization.Users;
using Wish.MultiTenancy;

namespace Wish.EntityFrameworkCore
{
    public class WishDbContext : AbpZeroDbContext<Tenant, Role, User, WishDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WishDbContext(DbContextOptions<WishDbContext> options)
            : base(options)
        {
        }
    }
}
