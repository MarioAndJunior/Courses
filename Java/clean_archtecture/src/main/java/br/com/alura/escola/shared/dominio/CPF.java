package br.com.alura.escola.shared.dominio;

import java.util.regex.Pattern;

public class CPF {
	private String numero;


	public CPF(String numero) {
		if (numero == null || !ehValido(numero)) {
			throw new IllegalArgumentException("CPF inválido");
		}
		this.numero = numero;
	}
	
	private static boolean ehValido(String numero) {
		return Pattern.compile("^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}$")
			      .matcher(numero)
			      .matches();
	}
	
	public String getNumero() {
		return numero;
	}
}
