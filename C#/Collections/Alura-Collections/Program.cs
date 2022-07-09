using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura_Collections
{
    class Program
    {
        static readonly Queue<string> pedagio = new();

        static void Main(string[] args)
        {
            TestaFila();
        }

        private static void TestaFila()
        {
            Enfileirar("van");
            Enfileirar("kombi");
            Enfileirar("guincho");
            Enfileirar("pickup");

            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
        }

        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "guincho")
                {
                    Console.WriteLine("Guincho está fazendo o pagamento");
                }

                string veiculo = pedagio.Dequeue();
                Console.WriteLine($"Saiu da fila: {veiculo}");
                ImprimirFila();
            }
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}");
            pedagio.Enqueue(veiculo);
            ImprimirFila();
        }

        private static void ImprimirFila()
        {
            Console.WriteLine();
            Console.WriteLine("Fila:");
            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }
        }

        private static void TestaPilha()
        {
            var navegador = new Navegador();
            navegador.NavegarPara("google.com");
            navegador.NavegarPara("caelum.com.br");
            navegador.NavegarPara("alura.com.br");

            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();

            navegador.Proximo();
        }

        private static void TestaListaLigada()
        {
            //List<string> frutas = new List<string>()
            //{
            //    "abacate", "banana", "caqui", "damasco", "figo"
            //};

            //foreach (var fruta in frutas)
            //{
            //    Console.WriteLine(fruta);
            //}

            // Se quiser adicionar uma fruta no meio do caminho não funfa

            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("quarta");

            //LinkedList não possui um Add
            //4 formas de adicionar
            // 1. Como primeiro nó AddFirst
            // 2. Como ultimo nó AddLast
            // 3. Antes de um nó conhecido
            // 4. Depois de um nó conhecido

            var d2 = dias.AddBefore(d4, "segunda");
            var d3 = dias.AddAfter(d2, "terça");

            var d6 = dias.AddAfter(d4, "sexta");
            var d7 = dias.AddAfter(d6, "sábado");
            var d5 = dias.AddBefore(d6, "quinta");
            var d1 = dias.AddBefore(d2, "domingo");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            Console.WriteLine();

            // LinkedList não dá suporte ao acesso por índice
            // podemos fazer foreach mas não o fo
            var quarta = dias.Find("quarta");
            Console.WriteLine(quarta.Value);
            dias.Remove("quarta");

            Console.WriteLine();
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            Console.WriteLine();
        }

        private static void TestaDicionario()
        {
            Curso csharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");

            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 22));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a3);

            Imprimir(csharpColecoes.Alunos);

            Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1));

            Aluno tonini = new Aluno("Vanessa Tonini", 34672);
            Console.WriteLine($"O aluno {tonini.Nome} está matriculado?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(tonini));
            Console.WriteLine($"a1 == Tonini? {a1 == tonini}");
            Console.WriteLine($"a1 equals Tonini? {a1.Equals(tonini)}");

            Console.Clear();

            // Trabalhando com dicionários

            Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);
            Console.WriteLine("aluno5617 " + aluno5617);


            Aluno aluno5618 = csharpColecoes.BuscaMatriculado(5618);
            Console.WriteLine("aluno5618 " + aluno5618);

            Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            csharpColecoes.SubstituiAluno(fabio);

            Console.WriteLine("aluno5617 " + csharpColecoes.BuscaMatriculado(5617));
        }

        private static void HashSetBasics()
        {
            //Sets = conjuntos
            //1. Não permite duplicidade
            //2. Os elementos não são mantidos em ordem específicas
            //HashSet muito escalável com boa performance, em contrapartida o consumo de memória é maior

            ISet<string> alunos = new HashSet<string>();

            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            Console.WriteLine(alunos);
            Console.WriteLine(string.Join(", ", alunos));

            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(", ", alunos));

            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");
            Console.WriteLine(string.Join(", ", alunos));

            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(", ", alunos));

            List<string> alunosEmLista = new List<string>(alunos);
            alunosEmLista.Sort();
            Console.WriteLine(string.Join(", ", alunosEmLista));
        }

        private static void MaisSobreListas()
        {
            Curso csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
            csharpColecoes.Adiciona(new Aula("Trabalhando com listas", 21));
            Imprimir(csharpColecoes.Aulas);

            csharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 20));
            Imprimir(csharpColecoes.Aulas);

            //csharpColecoes.Aulas.Sort();
            List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);
            aulasCopiadas.Sort();
            Imprimir(aulasCopiadas);

            Console.WriteLine(csharpColecoes.TempoTotal);

            Console.WriteLine(csharpColecoes);
        }

        private static void TestaListaObjetos()
        {
            var aulaIntro = new Aula("Introdução às Coleções", 20);
            var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            var aulaSets = new Aula("Trabalhando com conjuntos", 16);

            List<Aula> aulas = new List<Aula>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            Imprimir(aulas);

            aulas.Sort();
            Imprimir(aulas);

            aulas.Sort((self, other) => self.Tempo.CompareTo(other.Tempo));
            Imprimir(aulas);
        }

        private static void TestaListas()
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";

            //List<string> aulas = new List<string>
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            List<string> aulas = new List<string>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            Imprimir(aulas);

            Console.WriteLine($"A primeira aula é {aulas[0]}");
            Console.WriteLine($"A ultima aula é {aulas[aulas.Count - 1]}");
            Console.WriteLine($"A ultima aula é {aulas.Last()}");

            aulas[0] = "Trabalhando com listas";
            Imprimir(aulas);

            Console.WriteLine($"A primeira alua 'Trabalhando' é " +
                $"{aulas.First(aula => aula.Contains("Trabalhando"))}");

            Console.WriteLine($"A ultima alua 'Trabalhando' é " +
                $"{aulas.Last(aula => aula.Contains("Trabalhando"))}");

            Console.WriteLine($"A ultima alua 'Conclusão' é " +
                $"{aulas.FirstOrDefault(aula => aula.Contains("Conclusão"))}"); // Se não incluir o OrDefault dá exception se não encontrar

            aulas.Reverse();
            Imprimir(aulas);
            aulas.Reverse();
            Imprimir(aulas);

            aulas.RemoveAt(aulas.Count - 1);
            Imprimir(aulas);

            aulas.Add("Conclusão");
            Imprimir(aulas);

            aulas.Sort();
            Imprimir(aulas);

            List<string> copia = aulas.GetRange(aulas.Count - 2, 2);
            Imprimir(copia);

            List<string> clone = new List<string>(aulas);
            Imprimir(clone);

            clone.RemoveRange(clone.Count - 2, 2);
            Imprimir(clone);
        }

        private static void TestaArray()
        {
            //Array é mais utilizados em arquivos de baixo nível
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";
            //string[] aulas = new string[]
            //{ 
            //    aulaIntro, 
            //    aulaModelando, 
            //    aulaSets 
            //};

            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            Console.WriteLine(aulas);
            Imprimir(aulas);
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[aulas.Length - 1]);
            aulaIntro = "Trabalhando com Arrays";
            Imprimir(aulas);

            aulas[0] = aulaIntro;

            Imprimir(aulas);

            Console.WriteLine($"Aula modelando está no índice {Array.IndexOf(aulas, aulaModelando)}");
            Console.WriteLine(Array.LastIndexOf(aulas, aulaModelando));

            Array.Reverse(aulas);
            Imprimir(aulas);

            Array.Reverse(aulas);
            Imprimir(aulas);

            Array.Resize(ref aulas, 2); //copia internamente então não quebra
            Imprimir(aulas);

            Array.Resize(ref aulas, 3);
            Imprimir(aulas);

            aulas[aulas.Length - 1] = "Conclusão";
            Imprimir(aulas);

            Array.Sort(aulas); // Não tem como voltar para o estado anterior igual ao revert
            Imprimir(aulas);

            string[] copia = new string[2];
            Array.Copy(aulas, 1, copia, 0, 2);
            Imprimir(copia);

            string[] clone = aulas.Clone() as string[];
            Imprimir(clone);

            Array.Clear(clone, 1, 2);
            Imprimir(clone);
        }

        private static void Imprimir(string[] aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }

            Console.WriteLine();
        }

        private static void Imprimir(IList<Aluno> alunos)
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine();
        }

        private static void Imprimir(List<string> aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            //for (int i = 0; i < aulas.Count; i++)
            //{
            //    Console.WriteLine(aulas[i]);
            //}

            aulas.ForEach(aula =>
            {
                Console.WriteLine(aula);
            });

            Console.WriteLine();
        }

        private static void Imprimir(List<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.WriteLine();
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.WriteLine();
        }
    }
}

