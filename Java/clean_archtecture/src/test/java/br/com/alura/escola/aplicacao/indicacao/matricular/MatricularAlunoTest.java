package br.com.alura.escola.aplicacao.indicacao.matricular;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import br.com.alura.escola.dominio.aluno.Aluno;
import br.com.alura.escola.dominio.aluno.CPF;
import br.com.alura.escola.infra.aluno.RepositoryDeAlunosEmMemoria;

class MatricularAlunoTest {

	@Test
	void alunoDeveriaSerPersistido() {
		// Mock -> Mockito por exemplo
		RepositoryDeAlunosEmMemoria repositorio = new RepositoryDeAlunosEmMemoria();
		MatricularAluno useCase = new MatricularAluno(repositorio);
		
		MatricularAlunoDto dados = new MatricularAlunoDto("Fulano", "123.456.789-00", "fulano@email.com");
		useCase.executa(dados);
		
		Aluno aluno = repositorio.buscarPorCPF(new CPF("123.456.789-00"));
		
		Assertions.assertEquals("Fulano", aluno.getNome());
		Assertions.assertEquals("123.456.789-00", aluno.getCpf().getNumero());
		Assertions.assertEquals("fulano@email.com", aluno.getEmail().getEndereco());
	}

}
