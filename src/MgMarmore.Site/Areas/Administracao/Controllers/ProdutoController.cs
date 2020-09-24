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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MgMarmore.Site.Areas.Administracao.Controllers
{
    [Area("Administracao")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _contexto;
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaProdutoRepository _categoriaProduto;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository context,
            IProdutoService produtoService,
            ICategoriaProdutoRepository categoriaProduto,
            IMapper mapper)
        {
            _contexto = context;
            _produtoService = produtoService;
            _categoriaProduto = categoriaProduto;
            _mapper = mapper;
        }

        // GET: Administracao/Produto
        [Route("lista-de-produto")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _contexto.ObterTodos()));
        }


        [Route("dados-da-produto/{id:Guid}")]
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
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoriaProduto = _mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(await _categoriaProduto.ObterTodos());
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

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
            {
                return View(produtoViewModel);
            }

            produto.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            //produto.CategoriaProdutoId += 1;
            await _produtoService.Adicionar(produto);

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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,Frontao,Saia,Metodo,Imagem,QuantidadePecas,MetroQuadrado")] ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = await _contexto.ObterPorId(id);
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }


            //produtoAtualizacao.QuantidadePecas = produtoViewModel.QuantidadePecas;



            await _contexto.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));


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

        //[Route("adicionar-bancada/{id:Guid}")]
        //[HttpPost]
        //public async Task<IActionResult> Adicionar(ProdutoViewModel bancadaViewModel, Guid id)
        //{


        //    var produto = _mapper.Map<ProdutoViewModel>(await _contexto.ObterPorId(id));


        //    bancadaViewModel.Metodo = produto.Metodo;
        //    //var pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas);


        //     bancada = new 
        //    {
        //        Metodo = produto.Metodo,
        //        Frontao = bancadaViewModel.Frontao,
        //        Saia = bancadaViewModel.Saia,
        //        //Pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas),
        //        QuantidadePecas = bancadaViewModel.QuantidadePecas
        //    };
        //    bancada.Pecas = new List<Peca>();
        //    foreach (var p in bancadaViewModel.Pecas)
        //    {
        //        bancada.Pecas.Add(new Peca() { LarguraPeca = p.LarguraPeca, ComprimentoPeca = p.ComprimentoPeca });
        //    }

        //    _bancadaService.DefinirTipo("Reta", bancada);

        //    //if (!OperacaoValida()) return PartialView("_AtualizarEndereco", clienteViewModel);


        //    return Json(bancadaViewModel);
        //}
    }
}
