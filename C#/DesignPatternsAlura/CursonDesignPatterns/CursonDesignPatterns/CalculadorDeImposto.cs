using System;

namespace CursonDesignPatterns
{
    public class CalculadorDeImposto
    {
        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            double iss = imposto.Calcula(orcamento);
            Console.WriteLine(iss);
        }
    }
}
