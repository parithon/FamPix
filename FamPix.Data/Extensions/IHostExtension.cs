using FamPix.Data;
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
                var context = services.GetRequiredService<FamPixDbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            finally
            {
            }
            return host;
        }
    }
}
