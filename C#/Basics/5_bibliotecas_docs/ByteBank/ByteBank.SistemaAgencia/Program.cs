using ByteBank.Modelos;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaCorrente = new ContaCorrente(123, 7775551);
    
            Console.WriteLine(contaCorrente.Numero);
            DateTime dataFimPagamento = new DateTime(2021, 11, 23);
            DateTime dataCorrente = DateTime.Now;

            Console.WriteLine("dataFimPagamento " + dataFimPagamento);
            Console.WriteLine("dataCorrente " + dataCorrente);

            TimeSpan diferenca = dataCorrente - dataFimPagamento;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            Console.ReadLine();
        }
    }
}
