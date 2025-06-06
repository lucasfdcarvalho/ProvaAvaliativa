using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string mensagem)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:G} - {mensagem}");
        }
    }
}
