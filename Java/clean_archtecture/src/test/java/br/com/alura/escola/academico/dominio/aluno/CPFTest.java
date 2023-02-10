package br.com.alura.escola.academico.dominio.aluno;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

import br.com.alura.escola.academico.dominio.aluno.CPF;

class CPFTest {

	@Test
	void naoDeveriaCriarCPFComNumerosInvalidos() {
		assertThrows(IllegalArgumentException.class,
				() -> new CPF(null));
		assertThrows(IllegalArgumentException.class,
				() -> new CPF(""));
		assertThrows(IllegalArgumentException.class,
				() -> new CPF("11.11.11.-1"));
	}
	
	@Test
	void deveriaCriarCPFComNumeroValidoESeparadores() {
		assertDoesNotThrow(() -> new CPF("111.222.333-44"));
	}
	
	@Test
	void deveriaCriarCPFComNumeroValidoSemSeparadores() {
		assertDoesNotThrow(() -> new CPF("11122233344"));
	}

}
