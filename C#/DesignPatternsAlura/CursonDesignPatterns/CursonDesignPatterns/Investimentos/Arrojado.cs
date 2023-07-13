using System;

namespace CursonDesignPatterns.Investimentos
{
    public class Arrojado : Investimento
    {
        public double CalculaDividendo(Conta conta)
        {
            int chance = new Random().Next(101);

            double alicota = 0.0;

            if (chance <= 20)
            {
                alicota = 5;
            }
            else if(chance > 20 && chance <= 50)
            {
                alicota = 3;
            }
            else
            {
                alicota = 0.6;
            }

            double result = conta.Saldo * (alicota / 100) * 0.75;
            return Math.Round(result, 2);
        }
    }
}
