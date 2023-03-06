package br.com.alura.escola.academico.dominio.aluno;

import java.util.ArrayList;
import java.util.List;

import br.com.alura.escola.shared.dominio.CPF;

// Aggregate Root
public class Aluno {
	
	// ENTIDADE
	private CPF cpf;
	private String nome;
	private Email email;
	
	private List<Telefone> telefones = new ArrayList<>();
	private String senha;
	
	public Aluno(CPF cpf, String nome, Email email) {
		this.cpf = cpf;
		this.nome = nome;
		this.email = email;
	}

	public void adicionarTelefone(String ddd, String numero) throws ValorMaximoDeCadatroExcedido {
		if (this.telefones.size() == 2) {
			throw new ValorMaximoDeCadatroExcedido("Numero maximo " + this.telefones.size() + " de telefones atingido!");
		}
		this.telefones.add(new Telefone(ddd, numero));
	}
	
	public CPF getCpf() {
		return cpf;
	}
	
	public String getNome() {
		return nome;
	}
	
	public Email getEmail() {
		return email;
	}

	public List<Telefone> getTelefones() {
		return telefones;
	}
}
