namespace Poo.Api.Core.Application.ProductAgg.Contracts;

    public interface IProdutoView
    {
        string Id { get; }
        string Nome { get; }
        string Valor { get; }
        int QuantidadeDisponivel { get; }
        string Status { get; }
    }
