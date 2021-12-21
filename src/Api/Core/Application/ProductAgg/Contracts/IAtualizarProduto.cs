namespace Poo.Api.Core.Application.ProductAgg.Contracts;

    public interface IAtualizarProduto
    {
        string? Nome { get; set; }
        long Valor { get; }
    }
