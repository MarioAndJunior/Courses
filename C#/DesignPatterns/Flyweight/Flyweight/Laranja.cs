using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Laranja : Tartaruga
    {
        public Laranja()
        {
            this.condicao = " tartaruga dentro do casco, ";
            this.acao = "parada - ";
        }
        public override void Mostra(string cor)
        {
            Console.WriteLine(this.condicao + this.acao + cor.ToUpper());
        }
    }
}
