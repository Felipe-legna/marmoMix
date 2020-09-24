using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ModeloBancadaService : IModeloBancadaService
    {
        private readonly IModeloBancadaRepository _modeloRepository;
        public ModeloBancadaService(IModeloBancadaRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }
        public async Task Adicionar(ModeloBancada entity)
        {
            await _modeloRepository.Adicionar(entity);
        }

        public async Task Atualizar(ModeloBancada entity)
        {
            await _modeloRepository.Atualizar(entity);
        }

        public async Task Remover(Guid Id)
        {
            await _modeloRepository.Remover(Id);
        }

        public List<TipoBancada> ObterTiposBancadas()
        {

            return Enum.GetValues(typeof(TipoBancada)).Cast<TipoBancada>().ToList();
        }
        public void Dispose()
        {
            _modeloRepository?.Dispose();
        }
       
    }
}
