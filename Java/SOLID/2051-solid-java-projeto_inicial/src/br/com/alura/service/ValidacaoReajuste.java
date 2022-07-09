package br.com.alura.service;

import java.math.BigDecimal;

import br.com.alura.rh.model.Funcionario;

public interface ValidacaoReajuste {
	void validar(Funcionario funcionario, BigDecimal reajuste);
}
