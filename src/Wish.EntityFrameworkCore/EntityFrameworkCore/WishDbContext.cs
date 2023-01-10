using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Wish.Authorization.Roles;
using Wish.Authorization.Users;
using Wish.MultiTenancy;
using Wish.Todos;

namespace Wish.EntityFrameworkCore
{
    public class WishDbContext : AbpZeroDbContext<Tenant, Role, User, WishDbContext>
    {
        /* Define a DbSet for each entity of the application */
        /// <summary>
        /// 待辦工作
        /// </summary>
        public virtual DbSet<Todo> Todos { get; set; }

        public WishDbContext(DbContextOptions<WishDbContext> options)
            : base(options)
        {
        }
    }
}
