package br.com.alura.escola.academico.aplicacao.indicacao.matricular;

import br.com.alura.escola.academico.dominio.aluno.Aluno;
import br.com.alura.escola.academico.dominio.aluno.FabricaDeAluno;

public class MatricularAlunoDto {
	private String nomeAluno;
	private String cpfAluno;
	private String emailAluno;
	
	public MatricularAlunoDto(String nomeAluno, String cpfAluno, String emailAluno) {
		this.nomeAluno = nomeAluno;
		this.cpfAluno = cpfAluno;
		this.emailAluno = emailAluno;
	}

	public Aluno criarAluno() {
		FabricaDeAluno fabrica = new FabricaDeAluno();
		return fabrica.comNomeCPFEmail(this.nomeAluno, this.cpfAluno, this.emailAluno)
				.criar();
	}
	
}
