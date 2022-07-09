using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura_Collections
{
    public class Aula : IComparable
    {
        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public string Titulo { get; set; }
        public int Tempo { get; set; }

        public int CompareTo(object obj)
        {
            return this.Titulo.CompareTo((obj as Aula).Titulo);
        }

        public override string ToString()
        {
            return $"Aula - Título: {this.Titulo} e duração {this.Tempo} min.";
        }
    }
}
