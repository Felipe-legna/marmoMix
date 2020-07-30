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
    public class PecasController : BaseController
    {
        private readonly IPecaRepository _contexto;
        private readonly IMapper _mapper;

        public PecasController(IPecaRepository pecaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = pecaRepository;
        }

        [Route("lista-de-Pecas")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PecaViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-da-Peca/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var pecaViewModel = _mapper.Map<PecaViewModel>(await _contexto.ObterPorId(id));

            if (pecaViewModel == null)
            {
                return NotFound();
            }

            return View(pecaViewModel);
        }

        [Route("nova-Peca")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-Peca")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PecaViewModel pecaViewModel)
        {
            if (!ModelState.IsValid) return View(pecaViewModel);


            //Criação vai ser pela classe de serviço.
            var peca = _mapper.Map<Peca>(pecaViewModel);
            await _contexto.Adicionar(peca);
            
            return RedirectToAction("Index");
        }

        [Route("editar-Peca/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var pecaViewModel = _mapper.Map<PecaViewModel>(await _contexto.ObterPorId(id));

            if (pecaViewModel == null) return NotFound();

            return View(pecaViewModel);
        }

        [Route("editar-Peca/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PecaViewModel pecaViewModel)
        {
            if (id != pecaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pecaViewModel);

            var peca = _mapper.Map<Peca>(pecaViewModel);
            await _contexto.Atualizar(peca);


            return RedirectToAction("Index");
        }

        [Route("excluir-Peca/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pecaViewModel = _mapper.Map<PecaViewModel>(await _contexto.ObterPorId(id));

            if (pecaViewModel == null) return NotFound();

            return View(pecaViewModel);
        }

        [Route("excluir-Peca/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var pecaViewModel = _mapper.Map<PecaViewModel>(await _contexto.ObterPorId(id));

            if (pecaViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }

        
    }
}
