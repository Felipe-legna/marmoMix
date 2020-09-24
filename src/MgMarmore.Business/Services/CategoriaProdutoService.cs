using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class CategoriaProdutoService : BaseService, ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoService(ICategoriaProdutoRepository categoriaProdutoRepository,
            INotificador notificador) : base(notificador)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }
        public async Task Adicionar(CategoriaProduto entity)
        {
            //Validar
            if (!ExecutarValidacao(new CategoriaProdutoValidation(), entity)) return;
            //Executar
            await _categoriaProdutoRepository.Adicionar(entity);
        }

        public async Task Atualizar(CategoriaProduto entity)
        {
            //Validar
            if (!ExecutarValidacao(new CategoriaProdutoValidation(), entity)) return;
            //Executar
            await _categoriaProdutoRepository.Atualizar(entity); ;
        }

      
        public async Task Remover(Guid id)
        {
            await _categoriaProdutoRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaProdutoRepository?.Dispose();
        }
    }
}
