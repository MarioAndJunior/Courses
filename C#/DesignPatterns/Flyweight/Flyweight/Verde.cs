using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Verde : Tartaruga
    {
        public Verde()
        {
            this.condicao = " tartaruga fora do casco, ";
            this.acao = "voando - ";
        }
        public override void Mostra(string cor)
        {
            Console.WriteLine(this.condicao + this.acao + cor.ToUpper());
        }
    }
}
