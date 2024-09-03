package br.com.alura.alugames.principal

import br.com.alura.alugames.data.AluguelDAO
import br.com.alura.alugames.data.Banco
import br.com.alura.alugames.data.GamersDAO
import br.com.alura.alugames.data.JogosDAO
import br.com.alura.alugames.modelo.Gamer
import br.com.alura.alugames.modelo.Periodo

fun main() {
    val manager = Banco.getEntityManager()
    val jogoDao = JogosDAO(manager)
    val gamerDao = GamersDAO(manager)
    val aluguelDao = AluguelDAO(manager)

    val gamer = gamerDao.recuperarPeloId(2)
    val jogo = jogoDao.recuperarPeloId(3)
    val aluguel = gamer.alugaJogo(jogo, Periodo())

    aluguelDao.adicionar(aluguel)

    val listaAluguel = aluguelDao.getLista()

    println(listaAluguel)

    manager.close()
}