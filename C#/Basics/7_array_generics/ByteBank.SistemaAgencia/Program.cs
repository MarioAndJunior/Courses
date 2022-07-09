using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {

            Lista<ContaCorrente> lista = new Lista<ContaCorrente>();
            ContaCorrente conta1 = new ContaCorrente(111, 111111);
            lista.Adicionar(conta1);
            lista.Adicionar(new ContaCorrente(222, 111555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));
            lista.Adicionar(new ContaCorrente(123, 444555));

            lista.AdicionarVarios(
                new ContaCorrente(333, 444555),
                new ContaCorrente(333, 444556),
                new ContaCorrente(333, 444557),
                new ContaCorrente(333, 444558),
                new ContaCorrente(333, 444559)
                );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                Console.WriteLine($"Conta em {i} = {lista[i].Agencia}/{lista[i].Numero}");
            }

            Console.ReadLine();
        }

        static void testaArrayInt()
        {
            int[] idades = new int[5];

            idades[0] = 10;
            idades[1] = 20;
            idades[2] = 30;
            idades[3] = 40;
            idades[4] = 50;

            Console.WriteLine(idades[2]);

            int[] novasIdades = idades;
            Console.WriteLine(novasIdades[2]);
            novasIdades[2] = 55;

            Console.WriteLine(novasIdades[2]);
            Console.WriteLine(idades[2]);

            int acumulador = 0;
            for (int i = 0; i < idades.Length; i++)
            {
                Console.WriteLine($"idade[{i}] = {idades[i]}");
                acumulador += idades[i];
            }

            int media = acumulador / idades.Length;

            Console.WriteLine("A média das idades é: " + media);
        }
    }
}
