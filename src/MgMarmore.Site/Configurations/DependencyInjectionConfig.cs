using MgMarmore.Business.Interfaces;
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

            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<ICategoriaMaterialRepository, CategoriaMaterialRepository>();
            services.AddScoped<ICategoriaMaterialService, CategoriaMaterialService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
    

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IClienteService, ClienteService>();
                   
           
          

            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

           
            //services.AddScoped<IServicoRepository, ServicoRepository>();
            //services.AddScoped<IRevendaRepository, RevendaRepository>();


            //services.AddScoped<IBancadaBuilder, BancadaBuilder>();

           
           
            //services.AddScoped<IItemService, ItemService>();
           
            services.AddScoped<IOrcamentoService, OrcamentoService>();
          
            //services.AddScoped<IServicoService, ServicoService>();
            //services.AddScoped<IBancadaService, BancadaService>();
            //services.AddScoped<IModeloBancadaService, ModeloBancadaService>();

            services.AddScoped<INotificador, Notificador>();
            //services.AddScoped<IBancadaRetaService, BancadaRetaService>();
            //services.AddScoped<IBancadaEmLService, BancadaEmLService>();
            //services.AddScoped<IBancadaEmTService, BancadaEmTService>();
            //services.AddScoped<IBancadaEmUService, BancadaEmUService>();

            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
