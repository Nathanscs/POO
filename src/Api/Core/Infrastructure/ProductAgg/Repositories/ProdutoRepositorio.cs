using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Poo.Api.Core.Domain.ProductAgg.Entities;
using Poo.Api.Core.Domain.ProductAgg.Repositories;
using Poo.Api.Core.Infrastructure.Shared;

namespace Poo.Api.Core.Infrastructure.ProductAgg.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly PedidoDbContext _context;

        public ProdutoRepositorio(PedidoDbContext context)
        {
            _context = context;
        }
        
        public void Adicionar(Produto produto)
        {
            _context.Set<Produto>().Add(produto);
        }

        public ICollection<Produto> Buscar(string nome)
        {
            var query = _context.Set<Produto>().AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(produto => produto.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToImmutableList();
        }

        public Produto ObterPeloId(string id)
        {
            return _context.Set<Produto>().FirstOrDefault(x => x.ExternalId == id);
        }
    }
}