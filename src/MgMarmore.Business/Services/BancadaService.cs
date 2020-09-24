using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Models.Construtores;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    //Diretor
    public class BancadaService : BaseService, IBancadaService
    {
        
        private readonly IBancadaRepository _bancadaRepository;
        //private readonly INotificador _notificador;
        private readonly IBancadaRetaService _bancadaReta;
        private readonly IBancadaEmLService _bancadaEmL;
        private readonly IBancadaEmTService _bancadaEmT;
        private readonly IBancadaEmUService _bancadaEmU;

        private static List<Bancada> Bancadas;

        public BancadaService(
                               IBancadaRepository bancadaRepository,
                               INotificador notificador, 
                               IBancadaRetaService bancadaReta,
                               IBancadaEmLService bancadaEmL,
                               IBancadaEmTService bancadaEmT,
                               IBancadaEmUService bancadaEmU) : base(notificador)
        {

            _bancadaRepository = bancadaRepository;
            //_notificador = notificador;
            _bancadaReta = bancadaReta;
            _bancadaEmL = bancadaEmL;
            _bancadaEmT = bancadaEmT;
            _bancadaEmU = bancadaEmU;

           Bancadas = new List<Bancada>();
        }


        public Bancada DefinirTipoBancada(string tipoBancada, Bancada bancada)
        {
            //Bancada bancada = null;
                        
            Enum.TryParse(tipoBancada, out TipoBancada tipo);

            switch (tipo)
            {
                case TipoBancada.Reta:              
                    bancada =  _bancadaReta.DefinirTipoBancada(bancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case TipoBancada.L:
                    bancada = _bancadaEmL.DefinirTipoBancada(bancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case TipoBancada.T:
                    bancada = _bancadaEmT.DefinirTipoBancada(bancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
                case TipoBancada.U:
                    bancada = _bancadaEmU.DefinirTipoBancada(bancada.Metodo, bancada.Frontao, bancada.Saia, bancada.Pecas);
                    break;
            }

            Bancadas.Add(bancada);
            return bancada;
        }
        
        


        public async Task Adicionar(Bancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new BancadaValidation(), entity)) return;
            //Executar
            await _bancadaRepository.Adicionar(entity);
        }



        public async Task Atualizar(Bancada entity)
        {
            //Validar
            if (!ExecutarValidacao(new BancadaValidation(), entity)) return;
            //Executar
            await _bancadaRepository.Atualizar(entity);
        }

        public async Task<Bancada> ObterPorId(Guid id)
        {
            var bancada =  await _bancadaRepository.ObterPorId(id);
            bancada.Pecas = new List<Peca>();
            for (var i = 0; i< bancada.QuantidadePecas; i++)
            {
                bancada.Pecas.Add(new Peca());
            }
             
            return bancada;
        }

        public async Task Remover(Guid id)
        {
            await _bancadaRepository.Remover(id);
        }

        public void Dispose()
        {
            _bancadaRepository?.Dispose();
        }

    }
}
