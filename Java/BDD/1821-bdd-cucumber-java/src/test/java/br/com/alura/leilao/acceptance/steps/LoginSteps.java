package br.com.alura.leilao.acceptance.steps;

import org.junit.jupiter.api.Assertions;

import br.com.alura.leilao.e2e.pages.Browser;
import br.com.alura.leilao.e2e.pages.LeiloesPage;
import br.com.alura.leilao.e2e.pages.LoginPage;
import io.cucumber.java.After;
import io.cucumber.java.AfterStep;
import io.cucumber.java.pt.Dado;
import io.cucumber.java.pt.Entao;
import io.cucumber.java.pt.Quando;

public class LoginSteps {
	
	private Browser browser;
	private LoginPage loginPage;
	private LeiloesPage leiloesPage;
	
//	@AfterStep
//	public void after() {
//		this.browser.close();
//	}
	
	@Dado("o usuario valido")
	public void o_usuario_valido() {
	    browser = new Browser();
	    browser.seed();
	    loginPage = browser.getLoginPage();
	}
	@Quando("realiza o login")
	public void realiza_o_login() {
		leiloesPage = this.loginPage.realizaLoginComo("fulano", "pass");
	}
	@Entao("eh redirecionado para a pagina de leiloes")
	public void eh_redirecionado_para_a_pagina_de_leiloes() {
	    Assertions.assertTrue(leiloesPage.estaNaPaginaDeLeiloes());
	    this.browser.clean();
	}
	
	@Dado("o usuario invalido")
	public void o_usuario_invalido() {
		browser = new Browser();
		loginPage = browser.getLoginPage();
	}
	@Quando("tentar se logar")
	public void tentar_se_logar() {
		leiloesPage = this.loginPage.realizaLoginComo("bla", "pass");
	}
	@Entao("continua na pagina de login")
	public void continua_na_pagina_de_login() {
		Assertions.assertTrue(loginPage.estaNaPaginaDeLoginComErro());
		this.browser.clean();
	}
}
