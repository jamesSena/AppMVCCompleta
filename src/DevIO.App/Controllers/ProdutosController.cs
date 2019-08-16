using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevIO.App.Data;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using AutoMapper;
using DevIO.Business.Models;

namespace DevIO.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper, IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterFornecedorEndereco(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterAll());
            return produto;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Adicionar(produto);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterFornecedorProdutosEndereco(id);
            if (produtoViewModel == null) return NotFound();
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.ID) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Atualizar(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var produtoViewModel = await ObterFornecedorProdutosEndereco(id);
            if (produtoViewModel == null) return NotFound();
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterFornecedorProdutosEndereco(id);
            if (produtoViewModel == null) return NotFound();
            await _produtoRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _produtoRepository.ObterProdutosPorFornecedor(id));
        }
    }
}
