using MgMarmore.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Interfaces
{
    public interface IBaseService<TEntity> : IDisposable where TEntity: Entity
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid Id);

    }
}
