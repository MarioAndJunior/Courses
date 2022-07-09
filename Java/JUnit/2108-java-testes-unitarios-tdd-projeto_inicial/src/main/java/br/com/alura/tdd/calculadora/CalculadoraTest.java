package br.com.alura.tdd.calculadora;

import org.junit.jupiter.api.Test;
import org.junit.Assert;

public class CalculadoraTest {
	
	@Test
	public void deveriaSomarDoisNumerosPositivos() {
		Calculadora calc = new Calculadora();
		int soma = calc.somar(3, 7);
		
		Assert.assertEquals(10, soma);
	}
}
