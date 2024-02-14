package br.com.alura.orgs

import br.com.alura.orgs.model.Usuario
import org.junit.Assert
import org.junit.Test

class TestaUsuario {
    @Test
    fun aoCriarUmUsuarioComOValorCertoOUsuarioDeveriaSerValido() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email.com",
            senha = "123456"
        )

        val ehValido = usuarioValido.ehValido()

        Assert.assertTrue(ehValido)
    }

    @Test
    fun aoCriarUmUsuarioComEmailInvalidoDeveriaDarErro() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email",
            senha = "123456"
        )

        val ehValido = usuarioValido.ehValido()

        Assert.assertFalse(ehValido)
    }

    @Test
    fun aoCriarUmUsuarioComSenhaMenorQueSeisCaracteresDeveriaDarErro() {
        val usuarioValido = Usuario(
            id = "Mario",
            email = "email@email.com",
            senha = "12345"
        )

        val ehValido = usuarioValido.ehValido()

        Assert.assertFalse(ehValido)
    }
}