using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.Logging;
using Poo.Api.Core.Application.ProductAgg.Contracts;
using Poo.Api.Core.Application.ProductAgg.Parsers;
using Poo.Api.Core.Domain.ProductAgg.Entities;
using Poo.Api.Core.Domain.ProductAgg.Repositories;
using Poo.Api.Core.Domain.Shared.Exceptions;
using Poo.Api.Core.Domain.Shared.Repositories;

namespace Poo.Api.Core.Application.ProductAgg.AppServices
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepositorio _repositorio;
        private readonly IProdutoParseFactory _parseFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProdutoAppService> _logger;

        public ProdutoAppService(
            IProdutoRepositorio repositorio,
            IProdutoParseFactory parseFactory,
            IUnitOfWork unitOfWork,
            ILogger<ProdutoAppService> logger)
        {
            _repositorio = repositorio;
            _parseFactory = parseFactory;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IProdutoView Adicionar(IAdicionarProduto adicionarProduto)
        {
            _logger.LogDebug("Criando produto a partir do dto {@dto}", adicionarProduto);
            var produto = new Produto(adicionarProduto.Nome, adicionarProduto.Valor);
            _logger.LogDebug("Produto criado {@produto}", produto);
            _repositorio.Adicionar(produto);
            _logger.LogDebug("Produto adicionado ao repositório {@produto}", produto);
            _logger.LogDebug("Iniciando gravação do produto {@produto}", produto);
            _unitOfWork.SaveChanges();
            _logger.LogDebug("Produto gravado {@produto}", produto);
            _logger.LogDebug("Realizando parse do produto {@produto}", produto);
            var produtoView = _parseFactory.GetProdutoParse().Parse(produto);
            _logger.LogDebug("Parse realizado {@produto} {@view}", produto, produtoView);
            return produtoView;
        }

        public ICollection<IProdutoView> Buscar(string nome)
        {
            var produtos = _repositorio.Buscar(nome);

            return produtos.Select(_parseFactory.GetProdutoReportParse().Parse).ToImmutableList();
        }

        public IProdutoView ObterPeloId(string id)
        {
            var produto = _repositorio.ObterPeloId(id);

            if (produto == null)
            {
                throw new NotFoundException(nameof(produto), id);
            }
            
            return _parseFactory.GetProdutoParse().Parse(produto);
        }

        public IProdutoView Atualizar(string id, IAtualizarProduto atualizarProduto)
        {
            var produto = _repositorio.ObterPeloId(id);
            produto.Atualizar(atualizarProduto);
            _unitOfWork.SaveChanges();
            return _parseFactory.GetProdutoParse().Parse(produto);
        }

        public void Deletar(string id)
        {
            var produto = _repositorio.ObterPeloId(id);
            produto.Deletar();
            _unitOfWork.SaveChanges();
        }
    }
}