using Poo.Api.Core.Application.ProductAgg.Contracts;

namespace Poo.Api.Controllers.Contracts;

    public class AtualizarProdutoDto : IAtualizarProduto
    {
        public string? Nome { get; set; }
        public long Valor { get; set; }
    }
