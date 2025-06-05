using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class Pedido
    {
        public int ID { get; private set; }

        public Cliente Cliente { get; private set; }

        public List<ItemPedido> Itens { get; private set; }

        public DateTime Data { get; private set; }

        public double ValorTotal { get; private set; }

        private readonly IDescontoStrategy descontoStrategy;

        public Pedido(int id, Cliente cliente, IDescontoStrategy descontoStrategy)
        {
            ValidarId(id);

            this.ID = id;
            this.Cliente = cliente;
            this.descontoStrategy = descontoStrategy;
            Itens = new List<ItemPedido>();
            Data = DateTime.Now;
        }

        private void ValidarId(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("ID inválido");
            }
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemPedido item = new ItemPedido(produto, quantidade);
            Itens.Add(item);
            Console.WriteLine("Item adicionado com sucesso!");
        }

        public void CalcularTotal()
        {
            double totalSemDesconto = 0.0;

            foreach (ItemPedido item in Itens)
            {
                totalSemDesconto += item.CalcularSubTotal();
            }

            double desconto = descontoStrategy.CalcularDesconto(this);

            this.ValorTotal = totalSemDesconto - desconto;

            Console.WriteLine($"Valor Total do Pedido: {this.ValorTotal}");
        }
    }
}
