﻿using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MgMarmore.Business.Services
{
    //Diretor
    public class BancadaEmLService : IBancadaEmLService
    {
        private readonly IBancadaBuilder _bancada;
        public BancadaEmLService(IBancadaBuilder bancada)
        {
            _bancada = bancada;
        }

        public Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas)
        {
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(metodoDeCriacao);
            return (Bancada)theMethod.Invoke(this, new object[] { frontao, saia, pecas});
        }

        public Bancada CriarBancadaEmLComUmApoio(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 2)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddSemApoio)
                                    .AdicionarPeca(pecas[1], _bancada.AddSemApoio, _bancada.AddApoioOutraPeca);
            }

            return _bancada.ObterBancada();
        }

        public Bancada CriarBancadaEmLComUmApoioInvertido(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 2)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioUmaParede)
                                    .AdicionarPeca(pecas[1], _bancada.AddSemApoio, _bancada.AddApoioOutraPeca);
            }

            return _bancada.ObterBancada();
        }

        public Bancada CriarBancadaEmLComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas)
        {
            if (pecas.Count == 2)
            {
                _bancada.AdicionarFrontaoSaia(frontao, saia)
                                    .AdicionarPeca(pecas[0], _bancada.AddApoioUmaParede, _bancada.AddApoioUmaParede)
                                    .AdicionarPeca(pecas[1], _bancada.AddApoioUmaParede, _bancada.AddApoioDuasParedes);
            }

            return _bancada.ObterBancada();
        }
            

    }
}
