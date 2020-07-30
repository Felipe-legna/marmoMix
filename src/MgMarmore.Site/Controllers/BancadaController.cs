using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MgMarmore.Site.Data;
using MgMarmore.Site.ViewModels;
using MgMarmore.Business.Interfaces;
using AutoMapper;
using MgMarmore.Business.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MgMarmore.Site.Controllers
{
    public class BancadaController : Controller
    {
       
        private readonly IBancadaRepository _contexto;
        private readonly IBancadaService _bancadaService;
        private readonly IMapper _mapper;

        public BancadaController(IBancadaRepository context,
                                 IBancadaService bancadaService,
                                 IMapper mapper)
        {
            _contexto = context;
            _bancadaService = bancadaService;
            _mapper = mapper;
        }

        [Route("lista-de-bancada")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<BancadaViewModel>>(await _contexto.ObterTodos()));
        }

        
        [Route("dados-da-bancada/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var bancadaViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (bancadaViewModel == null)
            {
                return NotFound();
            }

            return View(bancadaViewModel);
        }

        [Route("nova-bancada")]
        public IActionResult Create()
        {
            ViewBag.TiposBancadas = _bancadaService.ObterTiposBancadas();
            return View();
        }

        [Route("nova-bancada")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BancadaViewModel bancadaViewModel)
        {
            if (!ModelState.IsValid) return View(bancadaViewModel);

            //Criação vai ser pela classe de serviço.
            var bancada = _mapper.Map<Bancada>(bancadaViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(bancadaViewModel.ImagemUpload, imgPrefixo))
            {
                return View(bancadaViewModel);
            }

            bancada.Imagem = imgPrefixo + bancadaViewModel.ImagemUpload.FileName;
            bancada.Categoria += 1;
            await _bancadaService.Adicionar(bancada);

            return RedirectToAction("Index");
        }

        [Route("editar-bancada/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bancadaViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (bancadaViewModel == null) return NotFound();

            return View(bancadaViewModel);
        }


        [Route("editar-bancada/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,Frontao,Saia,Metodo,Imagem,QuantidadePecas,MetroQuadrado")] BancadaViewModel bancadaViewModel)
        {
            if (id != bancadaViewModel.Id) return NotFound();

            var bancadaAtualizacao = await _contexto.ObterPorId(id);
            bancadaViewModel.Imagem = bancadaAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(bancadaViewModel);

            if (bancadaViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(bancadaViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(bancadaViewModel);
                }

                bancadaAtualizacao.Imagem = imgPrefixo + bancadaViewModel.ImagemUpload.FileName;
            }

            bancadaAtualizacao.Saia = bancadaViewModel.Saia;
            bancadaAtualizacao.Frontao = bancadaViewModel.Frontao;
            bancadaAtualizacao.QuantidadePecas = bancadaViewModel.QuantidadePecas;



            await _contexto.Atualizar(_mapper.Map<Bancada>(bancadaAtualizacao));


            return RedirectToAction("Index");
        }

        [Route("excluir-bancada/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bancadaViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (bancadaViewModel == null) return NotFound();

            return View(bancadaViewModel);
        }

        [Route("excluir-bancada/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bancadaViewModel = _mapper.Map<BancadaViewModel>(await _contexto.ObterPorId(id));

            if (bancadaViewModel == null) return NotFound();

            await _contexto.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
