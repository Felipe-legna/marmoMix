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
    public class ServicosController : BaseController
    {
        private readonly IServicoRepository _contexto;
        private readonly IMapper _mapper;

        public ServicosController(IServicoRepository servicoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = servicoRepository;
        }

        [Route("lista-de-servicos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ServicoViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-do-servico/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var servicoViewModel = _mapper.Map<ServicoViewModel>(await _contexto.ObterPorId(id));

            if (servicoViewModel == null)
            {
                return NotFound();
            }

            return View(servicoViewModel);
        }

        [Route("novo-servico")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-servico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicoViewModel servicoViewModel)
        {
            if (!ModelState.IsValid) return View(servicoViewModel);


            //Criação vai ser pela classe de serviço.
            var servico = _mapper.Map<Servico>(servicoViewModel);
            await _contexto.Adicionar(servico);
            
            return RedirectToAction("Index");
        }

        [Route("editar-servico/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var servicoViewModel = _mapper.Map<ServicoViewModel>(await _contexto.ObterPorId(id));

            if (servicoViewModel == null) return NotFound();

            return View(servicoViewModel);
        }

        [Route("editar-servico/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(servicoViewModel);

            var servico = _mapper.Map<Servico>(servicoViewModel);
            await _contexto.Atualizar(servico);


            return RedirectToAction("Index");
        }

        [Route("excluir-servico/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var servicoViewModel = _mapper.Map<ServicoViewModel>(await _contexto.ObterPorId(id));

            if (servicoViewModel == null) return NotFound();

            return View(servicoViewModel);
        }

        [Route("excluir-servico/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var servicoViewModel = _mapper.Map<ServicoViewModel>(await _contexto.ObterPorId(id));

            if (servicoViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
