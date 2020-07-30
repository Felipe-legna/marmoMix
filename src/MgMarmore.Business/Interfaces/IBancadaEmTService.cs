using MgMarmore.Business.Models;
using System.Collections.Generic;

namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaEmTService
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTDoisApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmTTrêsApoio(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
