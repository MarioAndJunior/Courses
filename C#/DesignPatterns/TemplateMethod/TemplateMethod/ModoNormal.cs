using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class ModoNormal : Jogo
    {
        public override void PrimeiraFase()
        {
            Console.WriteLine("O Carro precisa abastecer uma vez!");
        }

        public override void SegundaFase()
        {
            Console.WriteLine("Os carros devem correr na mesma velocidade...");
        }
    }
}
