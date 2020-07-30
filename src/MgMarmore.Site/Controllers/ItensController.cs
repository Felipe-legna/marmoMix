using AutoMapper;
using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MgMarmore.Site.Controllers
{
    public class ItensController : BaseController
    {
        private readonly IItemRepository _contexto;
       
        private readonly IMapper _mapper;

        public ItensController(IItemRepository itemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = itemRepository;
           // _bancadaService = bancadaService;
        }

        [Route("lista-de-itens")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ItemViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-do-item/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var itemViewModel = await BuscarItemServicosPecas(id);

            if (itemViewModel == null)
            {
                return NotFound();
            }

            return View(itemViewModel);
        }

        [Route("novo-item")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-item")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel itemViewModel)
        {
            
          //  var bancada = _bancadaService.DefinirTipoBancda("CriarBancadaRetaUmApoio", 0.20M, 0.15M, new List<Peca>{ new Peca(){ LarguraPeca = 1.50M, ComprimentoPeca = 0.60M }}, 0.80M);
           
            if (!ModelState.IsValid) return View(itemViewModel);


            ////Criação vai ser pela classe de serviço.
            var item = _mapper.Map<Item>(itemViewModel);
            await _contexto.Adicionar(item);

            return RedirectToAction("Index");
        }

        [Route("editar-item/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var itemViewModel = await BuscarItemServicosPecas(id); 

            if (itemViewModel == null) return NotFound();

            return View(itemViewModel);
        }

        [Route("editar-item/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ItemViewModel itemViewModel)
        {
            if (id != itemViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(itemViewModel);

            var item = _mapper.Map<Item>(itemViewModel);
            await _contexto.Atualizar(item);


            return RedirectToAction("Index");
        }

        [Route("excluir-item/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var itemViewModel = await BuscarItemServicosPecas(id);

            if (itemViewModel == null) return NotFound();

            return View(itemViewModel);
        }

        [Route("excluir-item/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var itemViewModel = _mapper.Map<ItemViewModel>(await _contexto.ObterPorId(id));

            if (itemViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }


        

        private async Task<ItemViewModel> BuscarItemServicosPecas(Guid id)
        {
            return _mapper.Map<ItemViewModel>(await _contexto.ObterItemServicosPecas(id));
        }

        //private async Task<ItemViewModel> BuscarItemServicosPecasMaterial(Guid id)
        //{
        //    return _mapper.Map<ItemViewModel>(await _contexto.ObterItemServicosPecasMaterial(id));
        //}
    }
}
