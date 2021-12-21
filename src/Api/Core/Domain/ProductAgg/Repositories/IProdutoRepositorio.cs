using System.Collections.Generic;
using Poo.Api.Core.Domain.ProductAgg.Entities;

namespace Poo.Api.Core.Domain.ProductAgg.Repositories
{
    public interface IProdutoRepositorio
    {
        void Adicionar(Produto produto);
        ICollection<Produto> Buscar(string nome);
        Produto ObterPeloId(string id);
    }
}