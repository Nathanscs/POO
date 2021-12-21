using Poo.Api.Core.Domain.ProductAgg.Entities;

namespace Poo.Api.Core.Domain.EstoqueAgg.Entities;
    public class EstoqueItem
    {
        private EstoqueItem()
        {
        }
        
        public EstoqueItem(Produto produto)
        {
            Produto = produto;
        }

        public long Id { get; private set; }
        public Produto Produto { get; private set; }
        public long ProdutoId { get; private set; }
        public int QuantidadeDisponivel { get; private set; }

        public void AtualizarQuantidadeDisponivel(int quantidade)
        {
            QuantidadeDisponivel = quantidade;
        }
    }
