using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class RevestimentoBaseProtoss : IRevestimento
    {
        public void Composicao()
        {
            Console.WriteLine("Base revestida pela cor amarela");
        }
    }
}
