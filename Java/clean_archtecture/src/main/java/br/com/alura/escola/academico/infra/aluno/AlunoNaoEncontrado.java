package br.com.alura.escola.academico.infra.aluno;

import br.com.alura.escola.academico.dominio.aluno.CPF;

public class AlunoNaoEncontrado extends Exception {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	public AlunoNaoEncontrado(CPF cpf) {
		super("Aluno nao encontrado com CPF " + cpf.getNumero());
	}

	
}
