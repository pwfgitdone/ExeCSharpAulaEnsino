using Daniel.AulaEnsino.Core.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daniel.AulaEnsino.Core.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped => Uma instância única para o request

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            #region Domain
            /*
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            #endregion

            #region InfraData

            services.AddScoped<MeuContextoBD>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            */
            #endregion
        }
    }
}