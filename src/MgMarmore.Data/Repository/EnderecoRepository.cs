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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MgContext db) : base(db) {}

        public async Task<Endereco> ObterEnderecoPorCliente(Guid ClienteID)
        {
            return await Db.Enderecos.AsNoTracking()
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(e => e.ClienteId == ClienteID);
        }
    }
}
