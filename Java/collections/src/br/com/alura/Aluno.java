package br.com.alura;

public class Aluno {
	private String nome;
	private int numeroMatricula;
	
	public Aluno(String nome, int numeroMatricula) {
		
		if (nome == null || nome.isEmpty()) {
			throw new IllegalArgumentException("Nome deve ser preenchido");
		}
		this.nome = nome;
		this.numeroMatricula = numeroMatricula;
	}

	public String getNome() {
		return nome;
	}

	public int getNumeroMatricula() {
		return numeroMatricula;
	}
	
	@Override
	public String toString() {
		return "[Aluno: " + this.nome + ", matricula: " + this.numeroMatricula + "]";
	}
	
	@Override
	public boolean equals(Object outro) {
		if(outro instanceof Aluno) {
			return this.getNome().equals(((Aluno) outro).getNome());
		}
		
		return false;
	}
	
	@Override
	public int hashCode() {
		return this.getNome().hashCode();
	}
}
