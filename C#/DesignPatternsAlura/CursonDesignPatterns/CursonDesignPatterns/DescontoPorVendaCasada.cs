using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursonDesignPatterns
{
    public class DescontoPorVendaCasada : Desconto
    {
        public Desconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (this.Existe("Lapis", orcamento) && this.Existe("Caneta", orcamento))
            {
                return orcamento.Valor * 0.05;
            }

            return Proximo.Desconta(orcamento);
        }

        private bool Existe(string nomeDoItem, Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Nome.ToLower().Equals(nomeDoItem.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
