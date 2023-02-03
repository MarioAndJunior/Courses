package br.com.alura.escola.dominio.aluno;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import br.com.alura.escola.dominio.aluno.Email;

class EmailTest {

	@Test
	void naoDeveriaCriarEmailComEnderecosInvalidos() {
		assertThrows(IllegalArgumentException.class,
				() -> new Email(null));
		assertThrows(IllegalArgumentException.class,
				() -> new Email(""));
		assertThrows(IllegalArgumentException.class,
				() -> new Email("emailInvalido"));
	}
	
	@Test
	void deveriaCriarEmailComEnderecoValido() {
		assertDoesNotThrow(() -> new Email("majr85@gmail.com"));
	}

}
