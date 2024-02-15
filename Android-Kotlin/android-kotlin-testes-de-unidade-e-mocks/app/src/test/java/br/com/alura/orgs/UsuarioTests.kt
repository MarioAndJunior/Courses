package br.com.alura.orgs

import br.com.alura.orgs.model.Usuario
import org.amshove.kluent.shouldBeFalse
import org.amshove.kluent.shouldBeTrue
import org.junit.Assert
import org.junit.Test

class UsuarioTests {
    @Test
    fun `deve retornar verdadeiro quando o usuario for valido`() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email.com",
            senha = "123456"
        )

        val ehValido = usuarioValido.ehValido()

        ehValido.shouldBeTrue()
        //Assert.assertTrue(ehValido)
    }

    @Test
    fun `deve retornar falso quando o email do usuario for invalido`() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email",
            senha = "123456"
        )

        val ehValido = usuarioValido.ehValido()

        ehValido.shouldBeFalse()
        //Assert.assertFalse(ehValido)
    }

    @Test
    fun `deve retornar falso quando o tamanho da senha do usuario for menor que seis digitos`() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email.com",
            senha = "12345"
        )

        val ehValido = usuarioValido.ehValido()

        ehValido.shouldBeFalse()
        //Assert.assertFalse(ehValido)
    }
}