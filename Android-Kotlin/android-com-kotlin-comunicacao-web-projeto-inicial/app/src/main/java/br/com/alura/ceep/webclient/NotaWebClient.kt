package br.com.alura.ceep.webclient

import android.util.Log
import br.com.alura.ceep.model.Nota
import br.com.alura.ceep.webclient.model.NotaRequisiscao
import br.com.alura.ceep.webclient.services.NotaService

class NotaWebClient {
    companion object {
        val TAG: String = NotaWebClient::class.java.name
    }

    private val notaService: NotaService =
        RetrofitInicializador().notaService

    suspend fun buscaTodas(): List<Nota>? {
        return try {
            val listaResposta = notaService.buscaTodas()
            listaResposta.map { notaResposta ->
                notaResposta.nota
            }
        } catch (e: Exception) {
            Log.e(TAG, "buscaTodas: ", e)
            null
        }
    }

    suspend fun salva(nota: Nota): Boolean {
        try {
            val resposta = notaService.salva(
                nota.id, NotaRequisiscao(
                    titulo = nota.titulo,
                    descricao = nota.descricao,
                    imagem = nota.imagem
                )
            )

            return resposta.isSuccessful
        } catch (e: Exception) {
            Log.e(TAG, "salva: falha ao tentar salvar", e)
        }
        return false
    }

    suspend fun remove(id: String): Boolean {
        try {
            val resposta = notaService.remove(id)
            return true
        } catch (e: Exception) {
            Log.e(TAG, "salva: falha ao tentar remover", e)
        }

        return false
    }
}