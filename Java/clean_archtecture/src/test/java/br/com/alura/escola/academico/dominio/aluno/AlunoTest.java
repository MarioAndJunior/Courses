package br.com.alura.escola.academico.dominio.aluno;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import br.com.alura.escola.academico.dominio.aluno.Aluno;
import br.com.alura.escola.academico.dominio.aluno.Email;
import br.com.alura.escola.academico.dominio.aluno.ValorMaximoDeCadatroExcedido;
import br.com.alura.escola.shared.dominio.CPF;

class AlunoTest {
	private Aluno aluno;
	
	@BeforeEach
	void criarAluno() {
		this.aluno = new Aluno(
				new CPF("123.456.789-10"), 
				"Fulano da Silva", 
				new Email("fulano@email.com"));
	}
	
	@Test
	void deveriaPermitirAdicionarUmTelefone() {
		try {
			this.aluno.adicionarTelefone("19", "998989898");
		} catch (ValorMaximoDeCadatroExcedido e) {
			Assertions.fail();
		}
		
	}
	
	@Test
	void deveriaPermitirAdicionarDoisTelefones() {
		try {
			this.aluno.adicionarTelefone("19", "998989898");
			this.aluno.adicionarTelefone("19", "998989898");
		} catch (ValorMaximoDeCadatroExcedido e) {
			Assertions.fail();
		}
		
	}
	
	@Test
	void naoDeveriaPermitirAdicionarMaisDeDoisTelefones() {
		try {
			this.aluno.adicionarTelefone("19", "998989898");
			this.aluno.adicionarTelefone("19", "998989898");
			this.aluno.adicionarTelefone("19", "998989898");
		} catch (ValorMaximoDeCadatroExcedido e) {
			return;
		}
		
		Assertions.fail();
	}

}
