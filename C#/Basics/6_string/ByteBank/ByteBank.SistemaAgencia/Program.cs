using ByteBank.Modelos;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestaExtrator();
            //TestaRegex();

            ContaCorrente conta = new ContaCorrente(123, 555666);
            Console.WriteLine(conta);

            Cliente cliente1 = new Cliente
            {
                CPF = "111.222.333-55",
                Nome = "Mario",
                Profissao = "Admin"
            };

            Cliente cliente2 = new Cliente
            {
                CPF = "111.222.333-55",
                Nome = "Mario",
                Profissao = "Admin"
            };

            Console.WriteLine(cliente1.Equals(cliente2));
            Console.ReadLine();
        }

        private static void TestaExtrator()
        {
            string url = "www.bytebank.com/cambio?origem=real&destino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(url);
            string valor = extrator.GetValor("valor");
            Console.WriteLine(valor);
            Console.ReadLine();
        }

        static void TestaRegex()
        {
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            Console.WriteLine("Entre com o número de telefone");
            string telefone = Console.ReadLine();

            Match match = Regex.Match(telefone, padrao);

            if (!String.IsNullOrEmpty(match.ToString()))
            {
                Console.WriteLine("Telefone válido: " + telefone);
            }
            else
            {
                Console.Beep(566, 3000);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Telefone inválido");
            }

            Console.ReadLine();
        }
    }
}
