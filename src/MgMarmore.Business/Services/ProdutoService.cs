using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _ProdutoRepository;

        public ProdutoService(IProdutoRepository ProdutoRepository,
            INotificador notificador) : base(notificador)
        {
            _ProdutoRepository = ProdutoRepository;
        }
        public async Task Adicionar(Produto entity)
        {
            //Validar
            //if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _ProdutoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Produto entity)
        {
            //Validar
            //if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _ProdutoRepository.Atualizar(entity); ;
        }


        public async Task Remover(Guid id)
        {
            await _ProdutoRepository.Remover(id);
        }

        public void Dispose()
        {
            _ProdutoRepository?.Dispose();
        }

    }
}
