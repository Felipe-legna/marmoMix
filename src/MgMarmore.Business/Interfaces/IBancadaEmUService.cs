using MgMarmore.Business.Models;


using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaEmUService 
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmUComTresApoios(decimal frontao, decimal saia, List<Peca> pecas);
    }
}
