# language: pt

Funcionalidade: Apenas usuarios cadastrados podem se logar

	Cenario: Um usuario valido consegue se logar
		Dado o usuario valido
		Quando realiza o login
		Entao eh redirecionado para a pagina de leiloes
	
	Cenario: Um usuario invalido nao consegue se logar
		Dado o usuario invalido
		Quando tentar se logar
		Entao continua na pagina de login