package br.com.alura.escola.academico.dominio.aluno;

import java.util.regex.Pattern;

public class Telefone {
	private String ddd;
	private String numero;
	
	public Telefone(String ddd, String numero) {
		if(!dddEhValido(ddd) || !numeroEhValido(numero)) {
			throw new IllegalArgumentException("DDD ou numero inválido");
		}
		this.ddd = ddd;
		this.numero = numero;
	}

	private static boolean numeroEhValido(String numero) {
		if (numero == null) {
			return false;			
		}
		
		return Pattern.compile("^[0-9]{8,9}$")
			      .matcher(numero)
			      .matches();
	}

	private static boolean dddEhValido(String ddd) {
		if (ddd == null) {
			return false;			
		}
		
		return Pattern.compile("^[0-9]{2}$")
			      .matcher(ddd)
			      .matches();
	}
	
	public String getDdd() {
		return ddd;
	}
	
	public String getNumero() {
		return numero;
	}
}
