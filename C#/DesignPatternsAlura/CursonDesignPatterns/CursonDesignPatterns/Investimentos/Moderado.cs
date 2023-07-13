using System;

namespace CursonDesignPatterns.Investimentos
{
    public class Moderado : Investimento
    {
        public double CalculaDividendo(Conta conta)
        {
            int chance = new Random().Next(101);

            double alicota = 0.0;

            if (chance > 50)
            {
                alicota = 0.7;
            }
            else
            {
                alicota = 2.5;
            }

            double result = conta.Saldo * (alicota / 100) * 0.75;
            return Math.Round(result, 2);
        }
    }
}
