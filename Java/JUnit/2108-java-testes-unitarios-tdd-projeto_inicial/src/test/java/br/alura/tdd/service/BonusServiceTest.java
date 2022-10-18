package br.alura.tdd.service;

import static org.junit.Assert.assertEquals;

import java.math.BigDecimal;
import java.time.LocalDate;

import org.junit.jupiter.api.Test;

import br.com.alura.tdd.modelo.Funcionario;
import br.com.alura.tdd.service.BonusService;

class BonusServiceTest {

	@Test
	void bonusDeveriaSerZeroParaFuncionarioComSalarioMuitoAlto() {
		BonusService bonusService = new BonusService();
		Funcionario funcionario = new Funcionario("Mario", LocalDate.now(), new BigDecimal("10001"));
		
		BigDecimal bonus = bonusService.calcularBonus(funcionario);
		
		assertEquals(new BigDecimal("0.00"), bonus);
	}
	
	@Test
	void bonusDeveriaSer10PorCentoDoSalario() {
		BonusService bonusService = new BonusService();
		Funcionario funcionario = new Funcionario("Mario", LocalDate.now(), new BigDecimal("2500"));
		
		BigDecimal bonus = bonusService.calcularBonus(funcionario);
		
		assertEquals(new BigDecimal("250.00"), bonus);
	}
	
	@Test
	void bonusDeveriaSer10PorCentoDoSalario10mil() {
		BonusService bonusService = new BonusService();
		Funcionario funcionario = new Funcionario("Mario", LocalDate.now(), new BigDecimal("10000"));
		
		BigDecimal bonus = bonusService.calcularBonus(funcionario);
		
		assertEquals(new BigDecimal("1000.00"), bonus);
	}

}
