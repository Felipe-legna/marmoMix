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
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MgMarmore.Site.Controllers
{
    public class MateriaisController : BaseController
    {
        private readonly IMaterialRepository _contexto;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        

        public MateriaisController(IMaterialRepository materialRepository, 
                                   ICategoriaRepository categoriaRepository,
                                   IMapper mapper)
        {
            _contexto = materialRepository;
            _categoriaRepository = categoriaRepository;            
            _mapper = mapper;
        }

        [Route("lista-de-materiais")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MaterialViewModel>>(await _contexto.ObterMateriaisCategoria()));            
        }

        [Route("dados-do-material/{id:Guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterMaterialCategoria(id));

            if (materialViewModel == null)
            {
                return NotFound();
            }

            return View(materialViewModel);
        }

        [Route("novo-material")]
        public async Task<IActionResult> Create()
        {  
            ViewBag.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
           
            return View();
        }

        [Route("novo-material")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialViewModel materialViewModel)
        {
            if (!ModelState.IsValid) return View(materialViewModel);
            
            //Criação vai ser pela classe de serviço.
            var material = _mapper.Map<Material>(materialViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(materialViewModel.ImagemUpload, imgPrefixo))
            {
                return View(materialViewModel);
            }

            material.Imagem = imgPrefixo + materialViewModel.ImagemUpload.FileName;
            await _contexto.Adicionar(material);
                        
            return RedirectToAction("Index");
        }

        [Route("editar-material/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterMaterialCategoria(id));

            if (materialViewModel == null) return NotFound();

            return View(materialViewModel);
        }

        [Route("editar-material/{id:Guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MaterialViewModel materialViewModel)
        {
            if (id != materialViewModel.Id) return NotFound();

            var materialAtualizacao = await _contexto.ObterMaterialCategoria(id);            
            materialViewModel.Imagem = materialAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(materialViewModel);

            if (materialViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(materialViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(materialViewModel);
                }

                materialAtualizacao.Imagem = imgPrefixo + materialViewModel.ImagemUpload.FileName;
            }

            materialAtualizacao.Nome = materialViewModel.Nome;
            materialAtualizacao.Custo = materialViewModel.Custo;
            materialAtualizacao.Valor = materialViewModel.Valor;
            

            
            await _contexto.Atualizar(_mapper.Map<Material>(materialAtualizacao));


            return RedirectToAction("Index");
        }

        [Route("excluir-material/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterMaterialCategoria(id));

            if (materialViewModel == null) return NotFound();

            return View(materialViewModel);
        }

        [Route("excluir-material/{id:Guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var materialViewModel = _mapper.Map<MaterialViewModel>(await _contexto.ObterMaterialCategoria(id));

            if (materialViewModel == null) return NotFound();

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
