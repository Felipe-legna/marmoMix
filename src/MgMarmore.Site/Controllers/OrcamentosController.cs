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
using MgMarmore.Site.ViewModels;
using AutoMapper;

namespace MgMarmore.Site.Controllers
{
    public class OrcamentosController : BaseController
    {
        private readonly IOrcamentoRepository _contexto;
        private readonly IMapper _mapper;

        public OrcamentosController(IOrcamentoRepository orcamentoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = orcamentoRepository;
        }

        [Route("lista-de-orcamentos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<OrcamentoViewModel>>(await _contexto.ObterTodos()));
        }

        [Route("dados-do-orcamento/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var orcamentoViewModel = await ObterOrcamentoClienteServicoRevendaItens(id);

            if (orcamentoViewModel == null)
            {
                return NotFound();
            }

            return View(orcamentoViewModel);
        }

        [Route("novo-orcamento")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-orcamento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrcamentoViewModel orcamentoViewModel)
        {
            if (!ModelState.IsValid) return View(orcamentoViewModel);


            //Criação vai ser pela classe de serviço.
            var orcamento = _mapper.Map<Orcamento>(orcamentoViewModel);
            await _contexto.Adicionar(orcamento);

            return RedirectToAction("Index");
        }

        [Route("editar-orcamento/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var orcamentoViewModel = _mapper.Map<OrcamentoViewModel>(await _contexto.ObterPorId(id));

            if (orcamentoViewModel == null) return NotFound();

            return View(orcamentoViewModel);
        }

        [Route("editar-orcamento/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, OrcamentoViewModel orcamentoViewModel)
        {
            if (id != orcamentoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(orcamentoViewModel);

            var orcamento = _mapper.Map<Orcamento>(orcamentoViewModel);
            await _contexto.Atualizar(orcamento);


            return RedirectToAction("Index");
        }

        [Route("excluir-orcamento/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var orcamentoViewModel = await ObterOrcamentoClienteServicoRevendaItens(id);

            if (orcamentoViewModel == null) return NotFound();

            return View(orcamentoViewModel);
        }

        [Route("excluir-orcamento/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var orcamentoViewModel = await ObterOrcamentoClienteServicoRevendaItens(id);

            if (orcamentoViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<OrcamentoViewModel> ObterOrcamentoClienteServicoRevendaItens(Guid id)
        {
            return _mapper.Map<OrcamentoViewModel>(await _contexto.ObterOrcamentoClienteServicoRevendaItens(id));
        }


    }
}
