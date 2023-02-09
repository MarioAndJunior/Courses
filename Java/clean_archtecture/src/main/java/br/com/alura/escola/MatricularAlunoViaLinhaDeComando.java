package br.com.alura.escola;

import br.com.alura.escola.aplicacao.indicacao.matricular.MatricularAluno;
import br.com.alura.escola.aplicacao.indicacao.matricular.MatricularAlunoDto;
import br.com.alura.escola.infra.aluno.RepositoryDeAlunosEmMemoria;

public class MatricularAlunoViaLinhaDeComando {
	public static void main(String[] args) {
		String nome = "Fulano da Silva";
		String cpf = "123.456.789-00";
		String email = "fulano@email.com";
		
		MatricularAluno matricular = new MatricularAluno(new RepositoryDeAlunosEmMemoria());
		matricular.executa(new MatricularAlunoDto(nome, cpf, email));
	}
}
