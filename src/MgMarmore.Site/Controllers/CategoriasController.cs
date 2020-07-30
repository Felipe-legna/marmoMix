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
    public class CategoriasController : BaseController
    {
        
        private readonly ICategoriaRepository _contexto;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(
            ICategoriaRepository categoriaRepository, 
            IMapper mapper,
            ICategoriaService categoriaService)
        {
            _mapper = mapper;
            _contexto = categoriaRepository;
            _categoriaService = categoriaService;
        }

        
        [Route("lista-de-categorias")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _contexto.ObterTodos()));
        }


        [Route("dados-da-categoria/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));
              
            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            return View(categoriaViewModel);
        }


        [Route("nova-categoria")]
        public IActionResult Create()
        {
            return View();
        }

      
        [Route("nova-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);
            
            //Criação vai ser pela classe de serviço.
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Adicionar(categoria);

            return RedirectToAction("Index");
        }


        [Route("editar-categoria/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }


        [Route("editar-categoria/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Atualizar(categoria);
            
            return RedirectToAction("Index");
        }


        [Route("excluir-categoria/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }


        [Route("excluir-categoria/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _contexto.ObterPorId(id));

            if (categoriaViewModel == null) return NotFound();

            await _categoriaService.Remover(id);

            return RedirectToAction("Index");
        }

        
    }
}
