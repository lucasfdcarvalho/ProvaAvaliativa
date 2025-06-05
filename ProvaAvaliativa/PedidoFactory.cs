using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class PedidoFactory : IPedidoFactory
    {
        public Pedido CriarPedido(int id, Cliente cliente, IDescontoStrategy descontoStrategy)
        {
            return new Pedido(id, cliente, descontoStrategy);
        }
    }
}
