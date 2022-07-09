using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ConversaoEOutrosTipos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("executando o projeto 4");

            double salario = 1200.50;

            int salarioInteiro = (int)salario;

            Console.WriteLine("salario de " + salarioInteiro);

            long idade = 13000000000000; //64bits

            short quantidadeProdutos = 15000; //16bits

            float altura = 1.80f; //Tem que colocar o F, float é meio inútil

            Console.WriteLine(idade + " " + quantidadeProdutos + " " + altura);

            int boolSize = sizeof(bool);

            Console.WriteLine(boolSize);

            Console.WriteLine("A execução terminou, pressione enter para continuar");
            Console.ReadLine();
        }
    }
}
