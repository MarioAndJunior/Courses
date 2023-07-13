using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursonDesignPatterns
{
    public interface Desconto
    {
        public Desconto Proximo { get; set; }
        public double Desconta(Orcamento orcamento);
    }
}
