package br.com.alura.alugames.principal

import br.com.alura.alugames.modelo.Jogo
import br.com.alura.alugames.servicos.ConsumoApi
import java.util.*

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
fun main() {
    val leitura = Scanner(System.`in`)
    println("Digite o código de jogo para buscar:")

    val busca = leitura.nextLine()
    val buscaApi = ConsumoApi()

    var meuJogo: Jogo? = null
    val resultado = runCatching {
        val informacaoJogo = buscaApi.buscaJogo(busca)
        meuJogo = Jogo(
            informacaoJogo.info.title,
            informacaoJogo.info.thumb
        )
    }

    resultado.onFailure {
        println("Jogo inexistente. Tente outro id.")
    }

    resultado.onSuccess {
        println("Deseja inserir uma descrição personalizada? S/N")
        val opcao = leitura.nextLine()
        if (opcao.equals("S", true)) {
            println("Digite a descrição:")
            val descricao = leitura.nextLine()
            meuJogo?.descricao = descricao
        } else {
            println("A descrição do jogo será o título")
            meuJogo?.descricao = meuJogo?.titulo
        }

        println(meuJogo)
    }

    resultado.onSuccess {
        println("Busca finalizada com sucesso.")
    }
}