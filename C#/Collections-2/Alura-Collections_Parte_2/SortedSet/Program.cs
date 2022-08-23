using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conjunto de alunos
            ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Priscila Stuani"
            };

            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            alunos.Add("Fabio Gushiken");
            alunos.Add("FABIO GUSHIKEN");

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            ISet<string> outroConjunto = new HashSet<string>();

            // Esse conjunto é subconjunto do outro?
            alunos.IsSubsetOf(outroConjunto);
            // Esse conjunto é superconjunto do outro?
            alunos.IsSupersetOf(outroConjunto);
            // Os conjuntos contêm os mesmos elementos?
            alunos.SetEquals(outroConjunto);
            // Subtrai os elementos da coleção que também estão nessa coleção
            alunos.ExceptWith(outroConjunto);
            // Intersecção dos conjuntos
            alunos.IntersectWith(outroConjunto);
            // Somente em um ou outro conjunto
            alunos.SymmetricExceptWith(outroConjunto);
            // União de conjuntos
            alunos.UnionWith(outroConjunto);

        }
    }

    internal class ComparadorMinusculo : IComparer<string>
    {
        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
