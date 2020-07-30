using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Business.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MgMarmore.Business.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository
             , INotificador notificador) : base(notificador)
        {
            _itemRepository = itemRepository;
        }

        public async Task Adicionar(Item entity)
        {
            //Validar
            if (!ExecutarValidacao(new ItemValidation(), entity)) return;
            //Executar
            await _itemRepository.Adicionar(entity);
        }

        public async Task Atualizar(Item entity)
        {
            //Validar
            if (!ExecutarValidacao(new ItemValidation(), entity)) return;
            //Executar
            await _itemRepository.Atualizar(entity);
        }
        public async Task Remover(Guid id)
        {
            await _itemRepository.Remover(id);
        }

        public void Dispose()
        {
            _itemRepository?.Dispose();
        }

    }
}
