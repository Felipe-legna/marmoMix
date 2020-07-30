using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models.Construtores;
using MgMarmore.Business.Notifications;
using MgMarmore.Business.Services;
using MgMarmore.Data.Context;
using MgMarmore.Data.Repository;
using MgMarmore.Site.Extensions;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;


namespace MgMarmore.Site.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MgContext>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IPecaRepository, PecaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IBancadaRepository, BancadaRepository>();

            services.AddScoped<IBancadaBuilder, BancadaBuilder>();

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IBancadaService, BancadaService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IBancadaRetaService, BancadaRetaService>();
            services.AddScoped<IBancadaEmLService, BancadaEmLService>();
            services.AddScoped<IBancadaEmTService, BancadaEmTService>();
            services.AddScoped<IBancadaEmUService, BancadaEmUService>();

            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
