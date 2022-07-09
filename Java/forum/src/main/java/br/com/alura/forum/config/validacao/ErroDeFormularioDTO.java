package br.com.alura.forum.config.validacao;

public class ErroDeFormularioDTO {
	public String campo;
	public String erro;
	
	public String getCampo() {
		return campo;
	}

	public String getErro() {
		return erro;
	}

	public ErroDeFormularioDTO(String campo, String erro) {
		this.campo = campo;
		this.erro = erro;
	}
	
	
}
