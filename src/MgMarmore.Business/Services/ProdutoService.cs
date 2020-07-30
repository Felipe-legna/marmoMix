using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, 
            INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto entity)
        {
            //Validar
            if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _produtoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Produto entity)
        {
            //Validar
            if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            //Executar
            await _produtoRepository.Atualizar(entity);
        }
        
        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
