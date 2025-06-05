using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class DescontoPorQuantidade : IDescontoStrategy
    {
        private readonly int QuantidadeMinima;

        private readonly double PercentualDesconto;

        public DescontoPorQuantidade(int quantidadeMinima = 5, double percentualDesconto = 0.10)
        {
            ValidarQuantidadeMinima(quantidadeMinima);
            ValidarPercentual(percentualDesconto);

            this.QuantidadeMinima = quantidadeMinima;
            this.PercentualDesconto = percentualDesconto;
        }

        private void ValidarQuantidadeMinima(int quantidadeMinima)
        {
            if(quantidadeMinima <= 0)
            {
                throw new ArgumentException("Quantidade Mínima inválida");
            }
        }

        private void ValidarPercentual(double percentualDesconto)
        {
            if(percentualDesconto <= 0 || percentualDesconto >= 1)
            {
                throw new ArgumentException("O percentual de desconto deve estar entre 0 e 1");
            }
        }

        public double CalcularDesconto(Pedido pedido)
        {
            int quantidadeItens = 0;
            double totalBruto = 0.0;

            foreach(ItemPedido item in pedido.Itens)
            {
                quantidadeItens += item.Quantidade;
                totalBruto += item.CalcularSubTotal();
            }

            if(quantidadeItens >= QuantidadeMinima)
            {
                return totalBruto * PercentualDesconto;
            }

            return 0.0;
        }
    }
}
