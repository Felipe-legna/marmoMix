using AutoMapper;
using MgMarmore.Business.Interfaces;
using MgMarmore.Business.Models;
using MgMarmore.Site.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MgMarmore.Site.Controllers
{

    public class ModeloBancadaController : Controller
    {
        private readonly IModeloBancadaRepository _contexto;
        private readonly IBancadaService _bancadaService;
        private readonly IModeloBancadaService _modeloBancadaService;
        private readonly IMapper _mapper;
        private readonly List<ModeloBancadaViewModel> _listaModeloBancadaViewModel;

        public ModeloBancadaController(IModeloBancadaRepository context,
                                         IBancadaService bancadaService,
                                         IModeloBancadaService modeloBancadaService,
                                         IMapper mapper)
        {
            _contexto = context;
            _bancadaService = bancadaService;
            _modeloBancadaService = modeloBancadaService;
            _mapper = mapper;
            _listaModeloBancadaViewModel = new List<ModeloBancadaViewModel>();
        }

        [Route("lista-de-modelo")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ModeloBancadaViewModel>>(await _contexto.ObterTodos()));
        }


        [Route("dados-da-modelo/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null)
            {
                return NotFound();
            }

            return View(modeloViewModel);
        }

        [Route("novo-modelo")]
        public IActionResult Create()
        {
            ViewBag.TiposBancadas = _modeloBancadaService.ObterTiposBancadas();
            return View();
        }

        [Route("novo-modelo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloBancadaViewModel modeloViewModel)
        {
            if (!ModelState.IsValid) return View(modeloViewModel);

            //Criação vai ser pela classe de serviço.
            var modelo = _mapper.Map<ModeloBancada>(modeloViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
            {
                return View(modeloViewModel);
            }

            modelo.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            modelo.Categoria += 1;
            await _modeloBancadaService.Adicionar(modelo);

            return RedirectToAction("Index");
        }

        [Route("editar-modelo/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }


        [Route("editar-modelo/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,Frontao,Saia,Metodo,Imagem,QuantidadePecas,MetroQuadrado")] ModeloBancadaViewModel modeloViewModel)
        {
            if (id != modeloViewModel.Id) return NotFound();

            var modeloAtualizacao = await _contexto.ObterPorId(id);
            modeloViewModel.Imagem = modeloAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(modeloViewModel);

            if (modeloViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(modeloViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(modeloViewModel);
                }

                modeloAtualizacao.Imagem = imgPrefixo + modeloViewModel.ImagemUpload.FileName;
            }


            modeloAtualizacao.QuantidadePecas = modeloViewModel.QuantidadePecas;



            await _contexto.Atualizar(_mapper.Map<ModeloBancada>(modeloAtualizacao));


            return RedirectToAction("Index");
        }

        [Route("excluir-modelo/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

            return View(modeloViewModel);
        }

        [Route("excluir-modelo/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modeloViewModel = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));

            if (modeloViewModel == null) return NotFound();

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

        [Route("adicionar-bancada/{id:Guid}")]
        [HttpPost]
        public async Task<IActionResult> AdicionarBancada(ModeloBancadaViewModel bancadaViewModel, Guid id)
        {


            var modeloBancada = _mapper.Map<ModeloBancadaViewModel>(await _contexto.ObterPorId(id));


            bancadaViewModel.Metodo = modeloBancada.Metodo;
            //var pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas);


            Bancada bancada = new Bancada
            {
                Metodo = modeloBancada.Metodo,
                Frontao = bancadaViewModel.Frontao,
                Saia = bancadaViewModel.Saia,
                //Pecas = _mapper.Map<List<Peca>>(bancadaViewModel.Pecas),
                QuantidadePecas = bancadaViewModel.QuantidadePecas
            };
            bancada.Pecas = new List<Peca>();
            foreach(var p in bancadaViewModel.Pecas)
            {
                bancada.Pecas.Add(new Peca() { LarguraPeca = p.LarguraPeca, ComprimentoPeca = p.ComprimentoPeca});
            }

            _bancadaService.DefinirTipoBancada("Reta", bancada);

            //if (!OperacaoValida()) return PartialView("_AtualizarEndereco", clienteViewModel);


            return Json(bancadaViewModel);
        }


    }
}


public class Teste
{
    public double Frontao { get; set; }
    public double Saia { get; set; }
    public List<PecaViewModel> Pecas { get; set; }
}