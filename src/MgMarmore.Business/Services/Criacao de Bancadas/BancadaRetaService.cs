using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MgMarmore.Business.Services
{
    //Diretor
    public class BancadaRetaService : IBancadaRetaService
    {       
        private readonly IBancadaBuilder _bancada;
        public BancadaRetaService(IBancadaBuilder bancada)
        {
            _bancada = bancada;
        }

       

        public Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas)
        {        

            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(metodoDeCriacao);
            return (Bancada)theMethod.Invoke(this, new object[] { frontao, saia, pecas});
        }        

        public Bancada CriarBancadaRetaUmApoio(decimal frontao, decimal saia, List<Peca> pecas)
        {
            var bancadaReta = _bancada.AdicionarFrontaoSaia(frontao, saia)
                                .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddSemApoio)                               
                                .ObterBancada();
            return bancadaReta;
        }
      

        public Bancada CriarBancadaRetaDoisApoio(decimal frontao, decimal saia, List<Peca> pecas)
        {
            var bancadaReta = _bancada.AdicionarFrontaoSaia(frontao, saia)
                                .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioUmaParede)
                                .ObterBancada();
            return bancadaReta;
        }
      


        public Bancada CriarBancadaRetaTresApoio(decimal frontao, decimal saia, List<Peca> pecas)
        {
            var bancadaReta = _bancada.AdicionarFrontaoSaia(frontao, saia)
                                .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioDuasParedes)
                                .ObterBancada();
            return bancadaReta;
        }

        
    }
}
