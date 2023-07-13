using System;

namespace CursonDesignPatterns.Investimentos
{
    public class RealizadorDeInvestimento
    {
        public void PagaDividendo(Conta conta, Investimento investimento)
        {
            Console.WriteLine($"Saldo antes do pagamento: {conta.Saldo}");
            Console.WriteLine("Calculando o dividendo");
            double dividendo = investimento.CalculaDividendo(conta);
            Console.WriteLine($"Valor a pagar: {dividendo}");
            conta.Deposita(dividendo);
            Console.WriteLine($"Saldo após o pagamento: {conta.Saldo}");
        }
    }
}
