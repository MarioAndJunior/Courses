using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    class Scorpion : IPersonagem
    {
        public void Escolhido()
        {
            Console.Write("Scorpion");
        }
    }
}
