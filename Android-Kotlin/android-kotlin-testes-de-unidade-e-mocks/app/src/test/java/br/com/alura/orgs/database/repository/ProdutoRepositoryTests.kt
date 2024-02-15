package br.com.alura.orgs.database.repository

import android.content.Context
import br.com.alura.orgs.database.AppDatabase
import br.com.alura.orgs.database.dao.ProdutoDao
import br.com.alura.orgs.model.Produto
import io.mockk.coEvery
import io.mockk.coVerify
import io.mockk.every
import io.mockk.mockk
import io.mockk.verify
import kotlinx.coroutines.test.runTest
import org.junit.Assert.*

import org.junit.Test
import java.math.BigDecimal

class ProdutoRepositoryTests {

    @Test
    fun `deve chamar o dao quando salva um produto`() = runTest {
        val dao = mockk<ProdutoDao>()
        val produtoRepository = ProdutoRepository(dao)
        val produto = Produto(
            nome = "Banana",
            descricao = "Banana prata",
            valor = BigDecimal("6.99")
        )

        coEvery {
            dao.salva(produto)
        }.returns(Unit)

        produtoRepository.salva(produto)

        coVerify {
            dao.salva(produto)
        }
    }
}