package br.com.alura.orgs

import br.com.alura.orgs.model.Produto
import org.amshove.kluent.shouldBeFalse
import org.amshove.kluent.shouldBeTrue
import org.junit.Test
import java.math.BigDecimal

class ProdutoTests {
    @Test
    fun `deve retornar verdadeiro quando o valor for valido`() {
        val produtoValido = Produto(
            nome = "Banana",
            descricao = "Banana prata",
            valor = BigDecimal("6.99")
        )

        val ehValido = produtoValido.valorValido
        ehValido.shouldBeTrue()
        //Assert.assertTrue(ehValido)
    }

    @Test
    fun `deve retornar falso quando o valor for maior que cem`() {
        val produtoInvalido = Produto(
            nome = "Carambola",
            descricao = "Amarela",
            valor = BigDecimal("100.99")
        )

        val ehValido = produtoInvalido.valorValido
        ehValido.shouldBeFalse()
        //Assert.assertFalse(ehValido)
    }

    @Test
    fun `deve retornar falso quando o valor for menor ou igual a zero`() {
        val produtoComValorIgualAZero = Produto(
            nome = "Lichia",
            descricao = "Doce",
            valor = BigDecimal("0")
        )

        val produtoComMenorQueZero = Produto(
            nome = "Uva",
            descricao = "Thompson",
            valor = BigDecimal("-10.99")
        )

        val igualAZeroEhValido = produtoComValorIgualAZero.valorValido
        val menorQueZeroEhValido = produtoComMenorQueZero.valorValido

        igualAZeroEhValido.shouldBeFalse()
        menorQueZeroEhValido.shouldBeFalse()
        //Assert.assertFalse(igualAZeroEhValido)
        //Assert.assertFalse(menorQueZeroEhValido)
    }
}