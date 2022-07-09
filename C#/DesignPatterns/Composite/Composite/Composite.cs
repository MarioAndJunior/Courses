using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class Composite : ComponenteFase
    {

        private List<ComponenteFase> fasesJogo = new List<ComponenteFase>();
        public Composite(string nome) : base(nome)
        {
        }

        public override void Adicionar(ComponenteFase c)
        {
            this.fasesJogo.Add(c);
        }

        public override void Mostrar(int profundidade)
        {
            Console.WriteLine(new string('-', profundidade) + nome);

            foreach(ComponenteFase fase in this.fasesJogo)
            {
                fase.Mostrar(profundidade + 2);
            }
        }

        public override void Remover(ComponenteFase c)
        {
            this.fasesJogo.Remove(c);
        }
    }
}
