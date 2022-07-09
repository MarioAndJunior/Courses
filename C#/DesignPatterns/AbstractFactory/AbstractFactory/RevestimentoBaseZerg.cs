using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class RevestimentoBaseZerg : IRevestimento
    {
        public void Composicao()
        {
            Console.WriteLine("Base revestida na cor vermelha");
        }
    }
}
