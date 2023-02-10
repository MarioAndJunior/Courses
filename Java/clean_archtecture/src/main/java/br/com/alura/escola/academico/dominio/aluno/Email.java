package br.com.alura.escola.academico.dominio.aluno;

import java.util.regex.Pattern;

public class Email {
	
	//VALUE OBJECT
	private String endereco;
	

	public Email(String endereco) {
		if (endereco == null || !ehValido(endereco)) {
			throw new IllegalArgumentException("Endereço de e-mail inválido");
		}
		this.endereco = endereco;
	}

	private static boolean ehValido(String endereco) {
		return Pattern.compile("^[a-z0-9]{1,}[@][a-z0-9]{1,}[.][a-z]{1,}[.]?[a-z]{1,}$$")
			      .matcher(endereco)
			      .matches();
	}
	
	public String getEndereco() {
		return endereco;
	}
}
