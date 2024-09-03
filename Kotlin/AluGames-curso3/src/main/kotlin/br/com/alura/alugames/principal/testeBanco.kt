package br.com.alura.alugames.principal

import br.com.alura.alugames.data.Banco
import br.com.alura.alugames.data.JogosDAO
import br.com.alura.alugames.modelo.Jogo


fun main() {
//    val conexao = Banco.obterConexao()
//    println(conexao)

    val manager = Banco.getEntityManager()
    val dao = JogosDAO(manager)

    val jogo = Jogo("The Last of Us Part I", "https://cdn.cloudflare.steamstatic.com/steam/apps/1888930/header.jpg?t=1686864554", 5.99,"Uma aventura pós-apocalíptica de sobrevivência em um mundo infestado por zumbis e facções em conflito.")
    val jogo2 = Jogo("Dandara", "https://cdn.cloudflare.steamstatic.com/steam/apps/612390/header.jpg?t=1674055293", 9.99,"Um jogo de plataforma e ação com elementos de metroidvania, onde você controla a heroína Dandara em sua luta para libertar um mundo repleto de opressão e tirania.")

    //dao.adicionar(jogo2)

    val jogoRecuperado = dao.recuperarPeloId(4)
    println(jogoRecuperado)
    dao.apagar(4)
    val listaJogos: List<Jogo> = dao.getLista()
    println(listaJogos)

    manager.close()
}
