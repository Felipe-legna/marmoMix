using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ServicoService : BaseService, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoService(IServicoRepository contexto
            , INotificador notificador) : base(notificador)
        {
            _servicoRepository = contexto;
        }

        public async Task Adicionar(Servico entity)
        {
            //Validar
            if (!ExecutarValidacao(new ServicoValidation(), entity)) return;
            //Executar
            await _servicoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Servico entity)
        {
            //Validar
            if (!ExecutarValidacao(new ServicoValidation(), entity)) return;
            //Executar
            await _servicoRepository.Atualizar(entity);
        }

        public async Task Remover(Guid id)
        {
            await _servicoRepository.Remover(id);
        }
        public void Dispose()
        {
            _servicoRepository?.Dispose();
        }
    }
}
