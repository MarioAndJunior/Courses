package br.com.alura.escola.gamificacao.aplicacao;

import java.time.format.DateTimeFormatter;

import br.com.alura.escola.gamificacao.dominio.selo.RepositorioDeSelos;
import br.com.alura.escola.gamificacao.dominio.selo.Selo;
import br.com.alura.escola.shared.dominio.CPF;
import br.com.alura.escola.shared.dominio.evento.Evento;
import br.com.alura.escola.shared.dominio.evento.Ouvinte;
import br.com.alura.escola.shared.dominio.evento.TipoDeEvento;

public class GeraSeloAlunoNovato extends Ouvinte {

	private final RepositorioDeSelos repositorioDeSelos;
	
	public GeraSeloAlunoNovato(RepositorioDeSelos repositorioDeSelos) {
		this.repositorioDeSelos = repositorioDeSelos;
	}

	@Override
	protected void reageAo(Evento evento) {
		CPF cpfDoAluno = (CPF) evento.informacoes().get("cpf");
		Selo novato = new Selo(cpfDoAluno , "Novato");
		this.repositorioDeSelos.adicionar(novato);
		
		String momentoFormatado = evento.momento().format(DateTimeFormatter.ofPattern("dd/MM/yyy HH:mm"));
		
		System.out.println(
					String.format(
						"Selo %s atribuido ao aluno com CPF %s em: %s", 
						novato.getNome(),
						cpfDoAluno.getNumero(),
						momentoFormatado));
	}

	@Override
	protected boolean deveProcessar(Evento evento) {
		return evento.tipo() == TipoDeEvento.ALUNO_MATRICULADO;
	}

}
