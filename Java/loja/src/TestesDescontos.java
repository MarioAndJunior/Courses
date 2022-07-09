import java.math.BigDecimal;

import br.com.alura.loja.desconto.CalculadoraDeDescontos;
import br.com.alura.loja.orcamento.ItemOrcamento;
import br.com.alura.loja.orcamento.Orcamento;

public class TestesDescontos {
	public static void main(String[] args) {
		Orcamento primeiro = new Orcamento();
		Orcamento segundo = new Orcamento();
		ItemOrcamento itemDoPrimeiro = new ItemOrcamento(new BigDecimal("200"));
		ItemOrcamento itemDoSegundo = new ItemOrcamento(new BigDecimal("1000"));
		
		primeiro.adicionarItem(itemDoPrimeiro);
		segundo.adicionarItem(itemDoSegundo);
		
		CalculadoraDeDescontos calculadora = new CalculadoraDeDescontos();
		System.out.println(calculadora.calcular(primeiro));
		System.out.println(calculadora.calcular(segundo));
	}
}
