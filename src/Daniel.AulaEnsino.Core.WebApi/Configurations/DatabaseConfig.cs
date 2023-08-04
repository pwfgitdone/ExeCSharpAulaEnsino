using Daniel.AulaEnsino.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Daniel.AulaEnsino.Core.WebApi.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<MeuContextoBD>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
