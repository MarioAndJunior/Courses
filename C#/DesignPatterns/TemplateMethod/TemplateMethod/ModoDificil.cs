using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class ModoDificil : Jogo
    {
        public override void PrimeiraFase()
        {
            Console.WriteLine("Adicionar obstáculo na pista!");
        }

        public override void SegundaFase()
        {
            Console.WriteLine("Os carros adversários devem correr mais...");
        }
    }
}
