using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class PedidoFactory : IPedidoFactory
    {
        private readonly ILogger logger;

        public PedidoFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public Pedido CriarPedido(int id, Cliente cliente, IDescontoStrategy descontoStrategy)
        {
            this.logger.Log($"Criando pedido {id} para cliente {cliente.Nome}");
            return new Pedido(id, cliente, descontoStrategy, this.logger);
        }
    }
}
