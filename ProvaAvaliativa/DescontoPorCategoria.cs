using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class DescontoPorCategoria : IDescontoStrategy
    {
        private readonly string categoriaAlvo;

        private readonly double percentualDesconto;
        
        public DescontoPorCategoria(string categoriaAlvo, double percentualDesconto = 0.10)
        {
            ValidarCategoriaAlvo(categoriaAlvo);
            ValidarPercentual(percentualDesconto);

            this.categoriaAlvo = categoriaAlvo;
            this.percentualDesconto = percentualDesconto;
        }

        private void ValidarCategoriaAlvo(string categoriaAlvo)
        {
            if (string.IsNullOrWhiteSpace(categoriaAlvo))
            {
                throw new ArgumentException("Categoria inválida");
            }
        }

        private void ValidarPercentual(double percentualDesconto)
        {
            if (percentualDesconto <= 0 || percentualDesconto >= 1)
            {
                throw new ArgumentException("O percentual de desconto deve estar entre 0 e 1");
            }
        }

        public double CalcularDesconto(Pedido pedido)
        {
            double totalCategoria = 0.0;

            foreach(ItemPedido item in pedido.Itens)
            {
                if(item.produto.Categoria == categoriaAlvo)
                {
                    totalCategoria += item.CalcularSubTotal();
                }
            }

            return totalCategoria * percentualDesconto;
        }
    }
}
