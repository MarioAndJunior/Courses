using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class EnergiaBaseZerg : IEnergia
    {
        public void Composicao()
        {
            Console.WriteLine("Energia de sustentação com base pela terra");
        }
    }
}
