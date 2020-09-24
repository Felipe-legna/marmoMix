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
    public class CategoriaMaterialController : Controller
    {
        private readonly ICategoriaMaterialRepository _contexto;
        private readonly IMapper _mapper;

        public CategoriaMaterialController(ICategoriaMaterialRepository context
            , IMapper mapper)
        {
            _contexto = context;
            _mapper = mapper;
        }

        // GET: Administracao/CategoriaMaterial
        [Route("lista-de-categorias-do-material")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CategoriaMaterialViewModel>>(await _contexto.ObterTodos()));
        }

        // GET: Administracao/CategoriaMaterial/Details/5
        [Route("dados-da-categoria-do-material/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var modeloViewModel = _mapper.Map<CategoriaMaterialViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        [Route("nova-categoria-do-material")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-categoria-do-material")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaMaterialViewModel categoriaMaterialViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaMaterialViewModel);


            //Criação vai ser pela classe de serviço.
            var categoriaMaterial = _mapper.Map<CategoriaMaterial>(categoriaMaterialViewModel);
            await _contexto.Adicionar(categoriaMaterial);

            return RedirectToAction("Index");
        }

        [Route("editar-categoria-do-material/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoriaMaterialViewModel = _mapper.Map<CategoriaMaterialViewModel>(await _contexto.ObterPorId(id));

            if (categoriaMaterialViewModel == null) return NotFound();

            return View(categoriaMaterialViewModel);
        }

        [Route("editar-categoria-do-material/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaMaterialViewModel categoriaMaterialViewModel)
        {
            if (id != categoriaMaterialViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaMaterialViewModel);

            var categoriaMaterial = _mapper.Map<CategoriaMaterial>(categoriaMaterialViewModel);
            await _contexto.Atualizar(categoriaMaterial);


            return RedirectToAction("Index");
        }

        [Route("excluir-categoria-do-material/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaMaterialViewModel = _mapper.Map<CategoriaMaterialViewModel>(await _contexto.ObterPorId(id));

            if (categoriaMaterialViewModel == null) return NotFound();

            return View(categoriaMaterialViewModel);
        }

        [Route("excluir-categoria-do-material/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var categoriaMaterialViewModel = _mapper.Map<CategoriaMaterialViewModel>(await _contexto.ObterPorId(id));

            if (categoriaMaterialViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }


    }
}
