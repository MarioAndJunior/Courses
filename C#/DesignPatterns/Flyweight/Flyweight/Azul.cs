using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class Azul : Tartaruga
    {
        public Azul()
        {
            this.condicao = " tartaruga fora do casco, ";
            this.acao = "caminhando - ";
        }
        public override void Mostra(string cor)
        {
            Console.WriteLine(this.condicao + this.acao + cor.ToUpper());
        }
    }
}
