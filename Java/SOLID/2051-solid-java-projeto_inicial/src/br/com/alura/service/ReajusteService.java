package br.com.alura.service;

import java.math.BigDecimal;
import java.util.List;

import br.com.alura.rh.model.Funcionario;

public class ReajusteService {
	private List<ValidacaoReajuste> validacoes;
	
	public ReajusteService(List<ValidacaoReajuste> validacoes) {
		this.validacoes = validacoes;
	}
	public void reajustarSalario(Funcionario funcionario, BigDecimal reajuste) {
		this.validacoes.forEach(v -> v.validar(funcionario, reajuste));
		
		BigDecimal salarioAtualizado = funcionario.getSalario().add(reajuste);
		funcionario.atualizarSalario(salarioAtualizado);
	}
}
