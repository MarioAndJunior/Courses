package br.com.alura.leilao.login;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class LoginTest {
	
	private LoginPage paginaDeLogin;
	
	@BeforeEach
	public void beforeEach() {
		this.paginaDeLogin = new LoginPage();
	}
	
	@AfterEach
	public void afterEach() {
		this.paginaDeLogin.fechar();
	}
	
	@Test
	public void deveriaEfetuarLoginComDadosValidos() {
		this.paginaDeLogin.preencheFormularioDeLogin("fulano", "pass");
		this.paginaDeLogin.efetuaLogin();
		
		Assertions.assertFalse(this.paginaDeLogin.isPaginaDeLogin());
		Assertions.assertEquals("fulano", this.paginaDeLogin.getNomeUsuarioLogado());
	}
	
	@Test
	public void naoDeveriaEfetuarLoginComDadosInvalidos() {
		this.paginaDeLogin.preencheFormularioDeLogin("invalido", "123123");
		this.paginaDeLogin.efetuaLogin();
		
		Assertions.assertTrue(this.paginaDeLogin.isPaginaDeLoginComDadosInvalidos());
		Assertions.assertNull(this.paginaDeLogin.getNomeUsuarioLogado());
		Assertions.assertTrue(this.paginaDeLogin.contemTexto("Usuário e senha inválidos."));
	}
	
	@Test
	public void naoDeveriaAcessarPaginaRestritaSemEstarLogado() {
		this.paginaDeLogin.navegaParaPaginaDeLances();
		
		Assertions.assertTrue(this.paginaDeLogin.isPaginaDeLogin());
		Assertions.assertFalse(this.paginaDeLogin.contemTexto("Dados do Leilão"));
	}
}
