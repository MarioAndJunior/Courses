package br.com.alura.escola.academico.aplicacao.indicacao.matricular;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import br.com.alura.escola.academico.aplicacao.indicacao.matricular.MatricularAluno;
import br.com.alura.escola.academico.aplicacao.indicacao.matricular.MatricularAlunoDto;
import br.com.alura.escola.academico.dominio.PublicadorDeEventos;
import br.com.alura.escola.academico.dominio.aluno.Aluno;
import br.com.alura.escola.academico.dominio.aluno.CPF;
import br.com.alura.escola.academico.dominio.aluno.LogDeAlunoMatriculado;
import br.com.alura.escola.academico.infra.aluno.RepositoryDeAlunosEmMemoria;

class MatricularAlunoTest {

	@Test
	void alunoDeveriaSerPersistido() {
		// Mock -> Mockito por exemplo
		RepositoryDeAlunosEmMemoria repositorio = new RepositoryDeAlunosEmMemoria();
		PublicadorDeEventos publicador = new PublicadorDeEventos();
		publicador.adicionar(new LogDeAlunoMatriculado());
		
		MatricularAluno useCase = new MatricularAluno(repositorio, publicador);
		
		MatricularAlunoDto dados = new MatricularAlunoDto("Fulano", "123.456.789-00", "fulano@email.com");
		useCase.executa(dados);
		
		Aluno aluno = repositorio.buscarPorCPF(new CPF("123.456.789-00"));
		
		Assertions.assertEquals("Fulano", aluno.getNome());
		Assertions.assertEquals("123.456.789-00", aluno.getCpf().getNumero());
		Assertions.assertEquals("fulano@email.com", aluno.getEmail().getEndereco());
	}

}
