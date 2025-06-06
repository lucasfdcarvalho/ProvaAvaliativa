using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class RelatorioPedido : IRelatorioPedido
    {
        private List<Pedido> pedidos = new List<Pedido>();

        private readonly ILogger logger;

        public RelatorioPedido(ILogger logger)
        {
            this.logger = logger;
        }

        public void AdicionarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
            this.logger.Log($"Pedido {pedido.ID} adicionado ao relatório");
        }

        public void GerarRelatorio()
        {
            this.logger.Log("Gerando relatório de pedidos");

            if(pedidos.Count == 0)
            {
                this.logger.Log("Nenhum pedido cadastrado!");
                return;
            }

            foreach(Pedido pedido in pedidos)
            {
                Console.WriteLine($"Pedido: #{pedido.ID}\nCliente: {pedido.Cliente.Nome} (CPF: {pedido.Cliente.CPF})\nData do Pedido: {pedido.Data:G}\n");

                Console.WriteLine("Itens:");
                foreach(ItemPedido item in pedido.Itens)
                {
                    Console.WriteLine($" - Produto: {item.produto.Nome}");
                    Console.WriteLine($" - Categoria: {item.produto.Categoria}");
                    Console.WriteLine($" - Quantidade: {item.Quantidade}");
                    Console.WriteLine($" - SubTotal: {item.CalcularSubTotal():F2}\n");
                }

                Console.WriteLine($"Valor Total com desconto: R$ {pedido.ValorTotal:F2}");
                Console.WriteLine("----------------------------------------------------\n");
            }

            this.logger.Log("Relatório gerado com sucesso!");
        }
    }
}
