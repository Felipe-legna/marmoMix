using MgMarmore.Business.Models;
using System;


namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaBuilder
    {
        IBancadaBuilder AdicionarFrontaoSaia(decimal frontao, decimal saia);
        IBancadaBuilder AdicionarPeca(Peca peca, Func<decimal, decimal> apoioLargura, Func<decimal, decimal> apoioComprimento);          
        decimal AddSemApoio(decimal medida);
        decimal AddApoioUmaParede(decimal medida);
        decimal AddApoioDuasParedes(decimal medida);
        decimal AddApoioOutraPeca(decimal medida);
        
        Bancada ObterBancada();
    }
}
