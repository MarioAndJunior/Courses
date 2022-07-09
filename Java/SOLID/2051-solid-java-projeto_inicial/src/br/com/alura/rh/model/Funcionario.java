package br.com.alura.rh.model;

import java.math.BigDecimal;
import java.time.LocalDate;

public class Funcionario {

	private DadosPessoais data = new DadosPessoais();
	public LocalDate dataUltimoReajuste;

	public Funcionario(String nome, String cpf, Cargo cargo, BigDecimal salario) {
		this.data.nome = nome;
		this.data.cpf = cpf;
		this.data.cargo = cargo;
		this.data.salario = salario;
	}

	public void atualizarSalario(BigDecimal salarioReajustado) {
		this.data.salario = salarioReajustado;
		this.dataUltimoReajuste = LocalDate.now();
	}

	public String getNome() {
		return data.nome;
	}

	public void setNome(String nome) {
		this.data.nome = nome;
	}

	public String getCpf() {
		return data.cpf;
	}

	public void setCpf(String cpf) {
		this.data.cpf = cpf;
	}

	public Cargo getCargo() {
		return data.cargo;
	}

	public void setCargo(Cargo cargo) {
		this.data.cargo = cargo;
	}

	public BigDecimal getSalario() {
		return data.salario;
	}

	public void setSalario(BigDecimal salario) {
		this.data.salario = salario;
	}

	public LocalDate getDataUltimoReajuste() {
		return dataUltimoReajuste;
	}

	public void setDataUltimoReajuste(LocalDate dataUltimoReajuste) {
		this.dataUltimoReajuste = dataUltimoReajuste;
	}

	public void promover(Cargo novoCargo) {
		this.data.cargo = novoCargo;
		
	}

}
