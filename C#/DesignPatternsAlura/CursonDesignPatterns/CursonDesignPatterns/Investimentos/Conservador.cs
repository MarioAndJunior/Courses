using System;

namespace CursonDesignPatterns.Investimentos
{
    public class Conservador : Investimento
    {
        public double CalculaDividendo(Conta conta)
        {
            double result = conta.Saldo * (0.8 / 100) * 0.75;
            return Math.Round(result, 2);
        }
    }
}
