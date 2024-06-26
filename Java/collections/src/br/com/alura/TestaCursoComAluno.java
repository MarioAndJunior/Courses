package br.com.alura;

public class TestaCursoComAluno {
	public static void main(String[] args) {
		Curso javaColecoes = new Curso("Dominando as coleções do Java", "Paulo Silveira");
		
		javaColecoes.adiciona(new Aula("Trabalhando com ArrayList", 21));
		javaColecoes.adiciona(new Aula("Criando uma Aula", 20));
		javaColecoes.adiciona(new Aula("Modelando com cole��es", 22));
		
		Aluno a1 = new Aluno("Mauricio Aniche", 1234);
		Aluno a2 = new Aluno("Guilherme Silveira", 4321);
		Aluno a3 = new Aluno("Sergio Lopes", 57164);
		
		javaColecoes.matricula(a1);
		javaColecoes.matricula(a2);
		javaColecoes.matricula(a3);
		
		System.out.println("Todos os alunos matriculados: ");
		javaColecoes.getAlunos().forEach(a -> {
			System.out.println(a);
		});
		
		boolean a1Matriculado = javaColecoes.estaMatriculado(a1);
		System.out.println(a1Matriculado);
		
		Aluno aniche = new Aluno("Mauricio Aniche", 1234);
		
		System.out.println(javaColecoes.estaMatriculado(aniche));
		
		Aluno matriculado = javaColecoes.buscaMatriculado(4321);
		System.out.println(matriculado);
	}
}
