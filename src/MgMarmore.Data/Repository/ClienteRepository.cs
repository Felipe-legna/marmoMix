using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Data.Repository
{
    //Repositorio padrao, Repositorio especifico
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MgContext context) : base (context) {}
        public async Task<Cliente> ObterClienteEnderecos(Guid id)
        {
            return await Db.Clientes.Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);            
        }

    }
}
