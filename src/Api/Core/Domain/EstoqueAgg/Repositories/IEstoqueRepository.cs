using Poo.Api.Core.Domain.EstoqueAgg.Entities;

namespace Poo.Api.Core.Domain.EstoqueAgg.Repositories
{
    public interface IEstoqueRepository
    {
        void Adicionar(EstoqueItem estoqueItem);
        Estoque Carregar();
    }
}