using System;
using System.Collections;
using System.Collections.Generic;

namespace Covariancia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("string para object");
            
            string titulo = "meses";
            object obj = titulo;

            Console.WriteLine(obj);

            Console.WriteLine("List<string> para List<object>");

            IList<string> listaMeses = new List<string>()
            {
                "Janeiro", "Fevereiro", "Março", "Abril",
                "Maio", "Junho", "Julho", "Agosto", 
                "Setembro", "Outubro", "Novembro", "Dezembro",
            };

            // IList<object> listaObj = listaMeses;
            Console.WriteLine();

            Console.WriteLine("string[] para object[]?");

            string[] arrayMeses = new string[]
            {
                "Janeiro", "Fevereiro", "Março", "Abril",
                "Maio", "Junho", "Julho", "Agosto",
                "Setembro", "Outubro", "Novembro", "Dezembro",
            };

            object[] arrayObj = arrayMeses; // Covariância do array. Deve ser evitada SEMPRE

            foreach (var mes in arrayObj)
            {
                Console.WriteLine(mes);
            }

            arrayObj[0] = "PRIMEIRO MÊS";
            Console.WriteLine(arrayObj[0]);
            Console.WriteLine();

            // arrayObj[0] = 12345;
            // Console.WriteLine(arrayObj[0]);
            // Console.WriteLine();

            Console.WriteLine("List<string> para IEnumerable<object>");

            IEnumerable<object> enumObj = listaMeses; // Covariância
            foreach (var item in enumObj)
            {
                Console.WriteLine(item);
            }

            // IEnumerable não permite alterar o dado de entrada bem como acessar via índice
        }
    }
}
