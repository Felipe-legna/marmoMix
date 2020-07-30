using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class MaterialService : BaseService, IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository
            , INotificador notificador) : base(notificador)
        {
            _materialRepository = materialRepository;
        }

        public async Task Adicionar(Material entity)
        {
            //Validar
            if (!ExecutarValidacao(new MaterialValidation(), entity)) return;
            //Executar
            await _materialRepository.Adicionar(entity);
        }

        public async Task Atualizar(Material entity)
        {
            //Validar
            if (!ExecutarValidacao(new MaterialValidation(), entity)) return;
            //Executar
            await _materialRepository.Atualizar(entity);
        }
        
        public async Task Remover(Guid id)
        {            
            await _materialRepository.Remover(id);
        }

        public void Dispose()
        {
            _materialRepository?.Dispose();
        }
    }
}
