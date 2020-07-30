using MgMarmore.Business.Models;
using System.Collections.Generic;

namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaRetaService
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaRetaUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaRetaDoisApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaRetaTresApoio(decimal frontao, decimal saia, List<Peca> pecas);
     
    }
}
