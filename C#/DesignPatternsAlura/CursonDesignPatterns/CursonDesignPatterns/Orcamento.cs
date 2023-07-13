using System.Collections.Generic;

namespace CursonDesignPatterns
{
    public class Orcamento
    {
        public Orcamento(double valor)
        {
            this.Valor = valor;
            Itens = new List<Item>();
        }

        public double Valor { get; private set; }
        public IList<Item> Itens { get; private set; }

        public void AdicionaItem(Item item)
        {
            this.Itens.Add(item);
        }
    }
}
