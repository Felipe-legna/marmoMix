using AutoMapper;
using MgMarmore.Business.Models;
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
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<Orcamento, OrcamentoViewModel>().ReverseMap();
            CreateMap<Peca ,PecaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Servico, ServicoViewModel>().ReverseMap();
            CreateMap<Bancada, BancadaViewModel>().ReverseMap();

        }
    }
}