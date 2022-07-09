using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 2 - criando variáveis");
            
            int idade = 36;

            Console.WriteLine("A idade é: idade" + idade);

            idade = 10 + 5;

            Console.WriteLine("A idade é: " + idade);

            idade = 10 + 5 * 2;

            Console.WriteLine("A idade é: " + idade);

            idade = (10 + 5) * 2;

            Console.WriteLine("A idade é: " + idade);

            Console.WriteLine("Execução terminada, tecle enter para sair...");
            Console.ReadLine();
        }
    }
}
