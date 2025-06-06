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

        public double ValorTotal
        {
            get
            {
                double totalSemDesconto = 0.0;

                foreach (ItemPedido item in Itens)
                {
                    totalSemDesconto += item.CalcularSubTotal();
                }

                double desconto = descontoStrategy.CalcularDesconto(this);

                return totalSemDesconto - desconto;
            }
        }

        private readonly IDescontoStrategy descontoStrategy;

        private readonly ILogger logger;

        public Pedido(int id, Cliente cliente, IDescontoStrategy descontoStrategy, ILogger logger)
        {
            ValidarId(id);

            this.ID = id;
            this.Cliente = cliente;
            this.descontoStrategy = descontoStrategy;
            Itens = new List<ItemPedido>();
            Data = DateTime.Now;
            this.logger = logger;
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
            this.logger.Log("Item adicionado com sucesso!");
        }

    }
}
