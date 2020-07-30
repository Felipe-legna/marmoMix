using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class OrcamentoService : BaseService, IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository
            , INotificador notificador) : base(notificador)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        public async Task Adicionar(Orcamento entity)
        {
            //Validar
            if (!ExecutarValidacao(new OrcamentoValidation(), entity)) return;
            //Executar
            await _orcamentoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Orcamento entity)
        {
            //Validar
            if (!ExecutarValidacao(new OrcamentoValidation(), entity)) return;
            //Executar
            await _orcamentoRepository.Atualizar(entity);
        }


        public async Task Remover(Guid id)
        {
            await _orcamentoRepository.Remover(id);
        }
        public void Dispose()
        {
            _orcamentoRepository?.Dispose();
        }
    }
}
