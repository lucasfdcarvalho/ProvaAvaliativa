using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class ItemPedido : ISubTotal
    {
        public Produto produto { get; private set; }

        public int Quantidade { get; private set; }

        public double SubTotal => produto.Preco * Quantidade;

        public ItemPedido(Produto produto, int quantidade)
        {
            ValidarQuantidade(quantidade);

            this.produto = produto;
            this.Quantidade = quantidade;
        }

        private void ValidarQuantidade(int quantidade)
        {
            if(quantidade <= 0)
            {
                throw new ArgumentException("Quantidade inválida");
            }
        }

        public double CalcularSubTotal()
        {
            return SubTotal;
        }
    }
}
