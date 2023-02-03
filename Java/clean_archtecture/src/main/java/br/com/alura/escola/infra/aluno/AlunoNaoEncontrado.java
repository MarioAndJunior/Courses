package br.com.alura.escola.infra.aluno;

import br.com.alura.escola.dominio.aluno.CPF;

public class AlunoNaoEncontrado extends Exception {
	public AlunoNaoEncontrado(CPF cpf) {
		super("Aluno nao encontrado com CPF " + cpf.getNumero());
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
}
