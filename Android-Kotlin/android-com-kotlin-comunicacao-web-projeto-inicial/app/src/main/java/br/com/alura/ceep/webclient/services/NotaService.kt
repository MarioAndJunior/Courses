package br.com.alura.ceep.webclient.services

import br.com.alura.ceep.webclient.model.NotaRequisiscao
import br.com.alura.ceep.webclient.model.NotaResposta
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.DELETE
import retrofit2.http.GET
import retrofit2.http.PUT
import retrofit2.http.Path

interface NotaService {
    //Sem coroutines
//    @GET("notas")
//    fun buscaTodas() : Call<List<NotaResposta>>

    @GET("notas")
    //pode ser Response<List<NotaResposta>> caso precise dos dados da requisição
    suspend fun buscaTodas(): List<NotaResposta>

    @PUT("notas/{id}")
    suspend fun salva(@Path("id") id : String,
              @Body nota: NotaRequisiscao) : Response<NotaResposta>

    @DELETE("notas/{id}")
    suspend fun remove(@Path("id") id: String) : Response<Void>
}