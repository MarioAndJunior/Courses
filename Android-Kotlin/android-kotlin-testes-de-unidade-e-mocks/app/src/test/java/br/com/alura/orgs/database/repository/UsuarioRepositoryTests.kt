package br.com.alura.orgs.database.repository

import br.com.alura.orgs.database.dao.UsuarioDao
import br.com.alura.orgs.model.Usuario
import io.mockk.coEvery
import io.mockk.coVerify
import io.mockk.mockk
import kotlinx.coroutines.test.runTest
import org.junit.Test

class UsuarioRepositoryTests {
    private val dao = mockk<UsuarioDao>()
    private val usuarioRepository = UsuarioRepository(dao)
    @Test
    fun `deve chamar o dao quando salva um usuario`() = runTest {
        val usuario = Usuario(
            id = "Mario",
            email = "mario@email.com",
            senha = "123456"
        )

        coEvery {
            dao.salva(usuario)
        }.returns(Unit)

        usuarioRepository.salva(usuario)

        coVerify {
            dao.salva(usuario)
        }
    }

    @Test
    fun `deve chamar o dao quando autentica um usuario`() = runTest {
        val usuario = Usuario(
            id = "Mario",
            email = "mario@email.com",
            senha = "123456"
        )

        coEvery {
            dao.autentica(usuario.id, usuario.senha)
        }.returns(usuario)

        usuarioRepository.autentica(usuario.id, usuario.senha)

        coEvery {
            dao.autentica(usuario.id, usuario.senha)
        }

    }
}