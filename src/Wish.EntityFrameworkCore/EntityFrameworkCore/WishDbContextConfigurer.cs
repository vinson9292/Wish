using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Wish.EntityFrameworkCore
{
    public static class WishDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WishDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WishDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
