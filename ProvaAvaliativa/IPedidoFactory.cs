using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public interface IPedidoFactory
    {
        Pedido CriarPedido(int id, Cliente cliente, IDescontoStrategy descontoStrategy);
    }
}
