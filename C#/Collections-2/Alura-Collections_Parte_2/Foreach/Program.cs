using System;
using System.Collections.Generic;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var meses = new List<string>()
            {
                "Janeiro", "Fevereiro", "Março", "Abril",
                "Maio", "Junho", "Julho", "Agosto",
                "Setembro", "Outubro", "Novembro", "Dezembro",
            };

            var mesesArray = new string[]
            {
                "Janeiro", "Fevereiro", "Março", "Abril",
                "Maio", "Junho", "Julho", "Agosto",
                "Setembro", "Outubro", "Novembro", "Dezembro",
            };

            // for each usa o MoveNext() do Enumerator para as classes que implementam a interface
            foreach (var item in meses)
            {
                // item = item.ToUpper(); // Não compila, não aceita alterar o iterador do for each
                // meses[0] = meses[0].ToUpper(); // Aqui estoura exception indicando que a coleção foi alterada
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in mesesArray)
            {
                meses[0] = meses[0].ToUpper(); // Aqui aceita, é como se fosse um laço for
                Console.WriteLine(item);
            }
        }
    }
}
