using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IBancadaService
    {
        Bancada DefinirTipoBancada(string tipoBancada, Bancada bancada);
        Task Adicionar(Bancada entity);
        Task Atualizar(Bancada entity);
        Task Remover(Guid id);
    }
}
