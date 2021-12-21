using Poo.Api.Core.Application.ProductAgg.Contracts;

namespace Poo.Api.Controllers.Contracts
{
    public class AdicionarProdutoDto : IAdicionarProduto
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
    }
}