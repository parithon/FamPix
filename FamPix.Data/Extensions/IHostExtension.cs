using FamPix.Data;
using FamPix.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Microsoft.Extensions.Hosting
{
    public static class IHostExtension
    {
        public static IHost MigrateDb(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<FamPixDbContext>();
                var idContext = services.GetRequiredService<IdentityContext>();

                dbContext.Database.EnsureCreated();
                idContext.Database.EnsureCreated();                

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
            finally
            {
            }
            return host;
        }
    }
}
