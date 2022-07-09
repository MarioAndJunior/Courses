package br.com.alura.rh.model;

import java.math.BigDecimal;

public class Terceirizado {
	private DadosPessoais dados;
	public Terceirizado(String empresa, Cargo cargo, String cpf, String nome, BigDecimal salario) {
		this.dados = new DadosPessoais();
		this.dados.cargo = cargo;
		this.dados.cpf = cpf;
		this.dados.nome = nome;
		this.dados.salario = salario;
		this.empresa = empresa;
	}
	private String empresa;
	
	public String getEmpresa() {
		return empresa;
	}
	public void setEmpresa(String empresa) {
		this.empresa = empresa;
	}
	
	
}
