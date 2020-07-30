using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository,
            INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task Adicionar(Categoria entity)
        {
            //Validar
            if (!ExecutarValidacao(new CategoriaValidation(), entity)) return;
            //Executar
            await _categoriaRepository.Adicionar(entity);
        }

        public async Task Atualizar(Categoria entity)
        {
            //Validar
            if (!ExecutarValidacao(new CategoriaValidation(), entity)) return;
            //Executar
            await _categoriaRepository.Atualizar(entity); ;
        }

      
        public async Task Remover(Guid id)
        {
            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
