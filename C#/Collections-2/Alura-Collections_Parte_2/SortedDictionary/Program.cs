using Alura_Collections;
using System;
using System.Collections.Generic;

namespace SortedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, Aluno> sortedAlunos = new SortedDictionary<string, Aluno>();

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
