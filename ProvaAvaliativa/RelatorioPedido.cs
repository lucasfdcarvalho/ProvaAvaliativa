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

        public void AdicionarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
            Console.WriteLine("Pedido adicionado ao relatório com sucesso!");
        }

        public void GerarRelatorio()
        {
            if(pedidos.Count == 0)
            {
                Console.WriteLine("Nenhum pedido cadastrado!");
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
        }
    }
}
