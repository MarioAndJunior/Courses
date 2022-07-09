using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class ModoFacil : Jogo
    {
        public override void PrimeiraFase()
        {
            Console.WriteLine("Combustivel para a corrida toda!");
        }

        public override void SegundaFase()
        {
            Console.WriteLine("Carros adversários devem correr menos...");
        }
    }
}
