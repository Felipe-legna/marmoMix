using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MgMarmore.Business.Models;
using MgMarmore.Site.Data;
using MgMarmore.Business.Interfaces;
using AutoMapper;
using MgMarmore.Site.ViewModels;

namespace MgMarmore.Site.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _contexto;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = produtoRepository;
        }

        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-do-produto/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);


            //Criação vai ser pela classe de serviço.
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _contexto.Adicionar(produto);

            return RedirectToAction("Index");
        }

        [Route("editar-produto/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);

            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _contexto.Atualizar(produto);


            return RedirectToAction("Index");
        }

        [Route("excluir-produto/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));

            if (produtoViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
