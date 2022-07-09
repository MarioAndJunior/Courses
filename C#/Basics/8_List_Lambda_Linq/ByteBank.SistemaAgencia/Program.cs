using System;
using System.Collections.Generic;
using System.Linq;
using ByteBank.Modelos;
using ByteBank.Modelos.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                null,
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950),
                null
            };

            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            //contas.Sort();

            //var contasOrdedenadas = contas.OrderBy(conta => 
            //{
            //    if (conta == null)
            //    {
            //        return int.MaxValue;
            //    }

            //    return conta.Numero;
            //});

            //var contasSemNulos = contas.Where(conta => conta != null);

            //var contasOrdenadas = contasSemNulos.OrderBy(conta => conta.Numero);
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            List<string> nomes = new List<string>();
            nomes.AdicionarVarios("mario", "maria", "kathy");
            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }
        static void SobreOVar()
        {
            // var idade; n compila pois deve-se atribuir
            // var conta = new ContaCorrente(123, 555444);
            // var gerenciador = new GerenciadorBonificacao();
            // var gerenciadores = new List<GerenciadorBonificacao>();
            // Fica bem mais legivel
        }
        static void TestaExtensoes()
        {
            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(20);
            idades.Add(30);
            idades.Add(50);
            idades.Add(60);
            idades.Add(12);

            idades.Remove(5);

            idades.AdicionarVarios(500, 600, 999);
            idades.AdicionarVarios(-1, 99);
            idades.Sort();

            foreach (var item in idades)
            {
                Console.WriteLine($"Idade {item}");
            }
        }
        static void testaMinhaLista()
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
