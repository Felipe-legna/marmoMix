using AutoMapper;
using MgMarmore.Business.Models;
using MgMarmore.Site.Areas.Administracao.ViewModels;
using MgMarmore.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MgMarmore.Site.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>().ReverseMap();
            CreateMap<CategoriaMaterial, CategoriaMaterialViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();          
            CreateMap<Orcamento, OrcamentoViewModel>().ReverseMap();
            //CreateMap<Peca ,PecaViewModel>().ReverseMap();
           
            //CreateMap<Servico, ServicoViewModel>().ReverseMap();
            //CreateMap<Bancada, BancadaViewModel>().ReverseMap();
            //CreateMap<ModeloBancada, ModeloBancadaViewModel>().ReverseMap();
            //CreateMap<Bancada, ModeloBancadaViewModel>().ReverseMap();

        }
    }
}