package br.com.alura.escola.academico.dominio.aluno;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import br.com.alura.escola.academico.dominio.aluno.Telefone;

class TelefoneTest {

	@Test
	void naoDeveriaCriarTelefonesComNumerosInvalidos() {
		assertThrows(IllegalArgumentException.class,
				() -> new Telefone(null, null));
		assertThrows(IllegalArgumentException.class,
				() -> new Telefone("1", "998989898"));
		assertThrows(IllegalArgumentException.class,
				() -> new Telefone("19", "999"));
	}
	
	@Test
	void deveriaCriarTelefoneComNumerosValidos() {
		assertDoesNotThrow(() -> new Telefone("19", "998989898"));
	}
}
