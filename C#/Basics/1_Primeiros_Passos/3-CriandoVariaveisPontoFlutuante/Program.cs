using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CriandoVariaveisPontoFlutuante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 3 - Criando pontos flutiantes");

            double salario = 1200.70;

            Console.WriteLine("O salário é de " + salario);

            double idade;
            idade = 15.0 / 2;

            Console.WriteLine("A idade é " + idade);

            idade = 5 / 3;

            Console.WriteLine("A idade é " + idade);

            idade = 5 / 3.0;

            Console.WriteLine("A idade é " + idade);

            Console.WriteLine("A execuão terminou, tecle enter para continuar");
            Console.ReadLine();
        }
    }
}
