using MgMarmore.Business.Models;


using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaEmLService
    {
        Bancada DefinirTipoBancada(string metodoDeCriacao, decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComUmApoio(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComUmApoioInvertido(decimal frontao, decimal saia, List<Peca> pecas);
        Bancada CriarBancadaEmLComDoisApoios(decimal frontao, decimal saia, List<Peca> pecas);       
    }
}
