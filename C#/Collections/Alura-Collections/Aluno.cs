using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura_Collections
{
    public class Aluno
    {
        private string nome;
        private int numeroMatricula;

        public Aluno(string nome, int numeroMatricula)
        {
            this.nome = nome;
            this.numeroMatricula = numeroMatricula;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int NumeroMatricula
        {
            get { return numeroMatricula; }
            set { numeroMatricula = value; }
        }

        public override string ToString()
        {
            return $"Aluno - Nome: {this.Nome} e Matrícula: {this.NumeroMatricula}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.Nome.Equals((obj as Aluno).Nome) && this.NumeroMatricula.Equals((obj as Aluno).NumeroMatricula);
        }

        public override int GetHashCode()
        {
            return this.Nome.GetHashCode();
        }
    }
}
