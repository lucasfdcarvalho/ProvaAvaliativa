using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public interface IDescontoStrategy
    {
        double CalcularDesconto(Pedido pedido);
    }
}
