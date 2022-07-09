using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("executando projeto 5 - caracteres e textos");

            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)(primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);

            string titulo = "Alura cursos de tecnologia " + 2020;
            Console.WriteLine(titulo);

            string cursosProgramacao = 
@"- .NET 
- Java 
- JavaScript";
            Console.WriteLine(cursosProgramacao);

            Console.WriteLine("execução terminou, pressione enter para continuar");

            
            Console.ReadLine();
        }
    }
}
