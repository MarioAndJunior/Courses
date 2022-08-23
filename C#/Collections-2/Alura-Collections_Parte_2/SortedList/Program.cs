using Alura_Collections;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um dicionario de alunos
            // VT, Vanessa, 34672
            // AL, Ana, 5617
            // RN, Rafael, 17645
            // WM, Wanderson, 11287

            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();

            alunos.Add("VT", new Aluno("Vanessa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            alunos.Remove("AL");
            alunos.Add("MO", new Aluno("Marcelo", 12345));

            Console.WriteLine();

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine("\nOrdenada\n");
            IDictionary<string, Aluno> sortedAlunos = new SortedList<string, Aluno>();

            sortedAlunos.Add("VT", new Aluno("Vanessa", 34672));
            sortedAlunos.Add("AL", new Aluno("Ana", 5617));
            sortedAlunos.Add("RN", new Aluno("Rafael", 17645));
            sortedAlunos.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var aluno in sortedAlunos)
            {
                Console.WriteLine(aluno);
            }

            Console.ReadLine();
        }
    }
}
