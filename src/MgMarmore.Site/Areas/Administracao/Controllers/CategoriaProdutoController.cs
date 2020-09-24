using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MgMarmore.Site.Areas.Administracao.ViewModels;
using MgMarmore.Site.Data;
using MgMarmore.Business.Interfaces;
using AutoMapper;
using MgMarmore.Business.Models;

namespace MgMarmore.Site.Areas.Administracao.Controllers
{
    [Area("Administracao")]
    public class CategoriaProdutoController : Controller
    {
        private readonly ICategoriaProdutoRepository _contexto;
        private readonly IMapper _mapper;

        public CategoriaProdutoController(ICategoriaProdutoRepository context
            , IMapper mapper)
        {
            _contexto = context;
            _mapper = mapper;
        }

        // GET: Administracao/CategoriaProduto
        [Route("lista-de-categorias-do-produto")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(await _contexto.ObterTodos()));
        }

        // GET: Administracao/CategoriaProduto/Details/5
        [Route("dados-da-categoria-do-produto/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var modeloViewModel = _mapper.Map<CategoriaProdutoViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        [Route("nova-categoria-do-produto")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-categoria-do-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaProdutoViewModel categoriaProdutoViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaProdutoViewModel);


            //Criação vai ser pela classe de serviço.
            var categoriaProduto = _mapper.Map<CategoriaProduto>(categoriaProdutoViewModel);
            await _contexto.Adicionar(categoriaProduto);

            return RedirectToAction("Index");
        }

        [Route("editar-categoria-do-produto/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoriaProdutoViewModel = _mapper.Map<CategoriaProdutoViewModel>(await _contexto.ObterPorId(id));

            if (categoriaProdutoViewModel == null) return NotFound();

            return View(categoriaProdutoViewModel);
        }

        [Route("editar-categoria-do-produto/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaProdutoViewModel categoriaProdutoViewModel)
        {
            if (id != categoriaProdutoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaProdutoViewModel);

            var categoriaProduto = _mapper.Map<CategoriaProduto>(categoriaProdutoViewModel);
            await _contexto.Atualizar(categoriaProduto);


            return RedirectToAction("Index");
        }

        [Route("excluir-categoria-do-produto/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaProdutoViewModel = _mapper.Map<CategoriaProdutoViewModel>(await _contexto.ObterPorId(id));

            if (categoriaProdutoViewModel == null) return NotFound();

            return View(categoriaProdutoViewModel);
        }

        [Route("excluir-categoria-do-produto/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var categoriaProdutoViewModel = _mapper.Map<CategoriaProdutoViewModel>(await _contexto.ObterPorId(id));

            if (categoriaProdutoViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
