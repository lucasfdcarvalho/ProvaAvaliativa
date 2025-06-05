using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public interface IRelatorioPedido
    {
        void AdicionarPedido(Pedido pedido);

        void GerarRelatorio();
    }
}
