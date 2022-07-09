using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura_Collections
{
    public class Curso
    {
        private List<Aula> aulas;
        private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>();
        private ISet<Aluno> alunos = new HashSet<Aluno>();
        private string nome;
        private string instrutor;
        
        internal void Adiciona(Aula aula)
        {
            this.aulas.Add(aula);
        }

        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
            this.aulas = new List<Aula>();
        }

        public IList<Aula> Aulas
        {
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }

        public IList<Aluno> Alunos
        {
            get { return new ReadOnlyCollection<Aluno>(alunos.ToList()); }
        }

        internal void Matricula(Aluno aluno)
        {
            this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
            this.alunos.Add(aluno);
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Instrutor
        {
            get { return instrutor; }
            set { instrutor = value; }
        }

        public int TempoTotal
        {
            get
            {
                //int tempoTotal = 0;

                //foreach (var aula in this.Aulas)
                //{
                //    tempoTotal += aula.Tempo;
                //}

                //return tempoTotal;

                //LINQ Language Integrated Query
                //Consulta integrada à linguagem

                return this.aulas.Sum(aula => aula.Tempo); // way more easy
            }
        }

        internal void SubstituiAluno(Aluno aluno)
        {
            this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
        }

        internal Aluno BuscaMatriculado(int numeroMatricula)
        {
            //foreach (var aluno in this.alunos)
            //{
            //    if (aluno.NumeroMatricula == numeroMatricula)
            //    {
            //        return aluno;
            //    }
            //}

            //return this.dicionarioAlunos[numeroMatricula]; Assim pode estourar exception

            Aluno alunoEncontrado;
            this.dicionarioAlunos.TryGetValue(numeroMatricula, out alunoEncontrado);

            return alunoEncontrado;
        }

        public override string ToString()
        {
            return $"Curso: {this.Nome}, Tempo {this.TempoTotal}, Aulas:{string.Join(',', this.Aulas)}";
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return this.Alunos.Contains(aluno);
        }

    }
}
