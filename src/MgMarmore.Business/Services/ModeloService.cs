using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }
        public async Task Adicionar(Modelo entity)
        {
            await _modeloRepository.Adicionar(entity);
        }

        public async Task Atualizar(Modelo entity)
        {
            await _modeloRepository.Atualizar(entity);
        }

        public async Task Remover(Guid Id)
        {
            await _modeloRepository.Remover(Id);
        }

        public void Dispose()
        {
            _modeloRepository?.Dispose();
        }
       
    }
}
