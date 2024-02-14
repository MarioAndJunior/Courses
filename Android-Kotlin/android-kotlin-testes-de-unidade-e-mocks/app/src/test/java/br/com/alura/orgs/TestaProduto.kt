package br.com.alura.orgs

import br.com.alura.orgs.model.Produto
import org.junit.Assert
import org.junit.Test
import java.math.BigDecimal

class TestaProduto {
    @Test
    fun aoCriarUmProdutoComOValorCertoOValorDeveriaSerValido() {
        val produtoValido = Produto(
            nome = "Banana",
            descricao = "Banana prata",
            valor = BigDecimal("6.99")
        )

        val ehValido = produtoValido.valorValido

        Assert.assertTrue(ehValido)
    }

    @Test
    fun seOValorForMaiorQueCemReaisDeveriaDarErro() {
        val produtoInvalido = Produto(
            nome = "Carambola",
            descricao = "Amarela",
            valor = BigDecimal("100.99")
        )

        val ehValido = produtoInvalido.valorValido

        Assert.assertFalse(ehValido)
    }
}