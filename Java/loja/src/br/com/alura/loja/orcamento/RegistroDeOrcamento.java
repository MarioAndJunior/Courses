package br.com.alura.loja.orcamento;

import java.util.Map;

import br.com.alura.loja.http.HttpAdapter;
import br.com.alura.loja.orcamento.situacao.DomainException;

public class RegistroDeOrcamento {
	
	private HttpAdapter http;
	public RegistroDeOrcamento(HttpAdapter http) {
		this.http = http;
	}
	public void registrar(Orcamento orcamento) {
		if(!orcamento.isFinalizado()) {
			throw new DomainException("Orçamento não finalizado");
		}
		
		String url = "http://api.externa/orcamento/";
		Map<String, Object> dados= Map.of(
				"valor", orcamento.getValor(),
				"quantidadeDeItens", orcamento.getQuantidadeItens()
				);
		
		http.post(url, dados);
		
	}
}
