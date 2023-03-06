package br.com.alura.escola.academico.dominio.aluno;

import java.time.format.DateTimeFormatter;

import br.com.alura.escola.shared.dominio.evento.Evento;
import br.com.alura.escola.shared.dominio.evento.Ouvinte;

public class LogDeAlunoMatriculado extends Ouvinte {
	
	@Override
	public void reageAo(Evento evento) {
		String momentoFormatado = evento.momento().format(DateTimeFormatter.ofPattern("dd/MM/yyy HH:mm"));
		
		System.out.println(
					String.format(
						"Aluno com CPF %s matriculado em: %s", 
						((AlunoMatriculado) evento).getCpfDoAluno().getNumero(),
						momentoFormatado));
	}

	@Override
	protected boolean deveProcessar(Evento evento) {
		return evento instanceof AlunoMatriculado;
	}
}
