using System.Linq;
using Poo.Api.Controllers.Contracts;
using Poo.Api.Core.Application.ProductAgg.Contracts;
using Poo.Api.Core.Application.ProductAgg.Parsers;
using Poo.Api.Core.Domain.EstoqueAgg.Repositories;
using Poo.Api.Core.Domain.ProductAgg.Entities;

namespace Poo.Api.Controllers.Parsers;

    public class ProdutoParser : IParser<Produto, IProdutoView>
    {
        public IProdutoView Parse(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome,
                Valor = produto.Valor.ToString(),
                Status = produto.Status
            };
        }
    }

    public class ProdutoReportParser : IParser<Produto, IProdutoView>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public ProdutoReportParser(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        
        public IProdutoView Parse(Produto produto)
        {
            var estoque = _estoqueRepository.Carregar();
            var item = estoque.Itens.First(x => x.ProdutoId == produto.Id);
            return new ProdutoDto
            {
                Id = produto.ExternalId,
                Nome = produto.Nome.ToUpper(),
                Valor = (produto.Valor / 100M).ToString("C"),
                QuantidadeDisponivel = item.QuantidadeDisponivel,
                Status = produto.Status
            };
        }
    }
