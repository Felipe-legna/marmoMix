using System;

namespace MgMarmore.Business.Models
{
    public class ServicosItens
    {
        public Guid ServicoId { get; set; }
        public Servico Servico { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}