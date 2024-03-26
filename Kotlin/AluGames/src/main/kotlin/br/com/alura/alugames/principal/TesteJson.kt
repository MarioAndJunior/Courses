package br.com.alura.alugames.principal

import br.com.alura.alugames.modelo.Periodo
import br.com.alura.alugames.modelo.PlanoAssinatura
import br.com.alura.alugames.servicos.ConsumoApi
import com.google.gson.GsonBuilder
import java.io.File
import java.time.LocalDate
import java.time.Month

fun main() {
    val service = ConsumoApi()
//    println(service.buscaGamers())
//    println(service.buscaJogo("111"))
//    println(service.listaJogosJson())

    val listaGamer = service.buscaGamers()
    val listaJogos = service.listaJogosJson()
    val gamerCaroline = listaGamer.get(3)
    val jogoResidentVillage = listaJogos.get(10)
    val jogoSpider = listaJogos.get(13)
    val jogoLastOfUs = listaJogos.get(2)
    val jogoDandara = listaJogos.get(5)
    val jogoAssassins = listaJogos.get(4)
    val jogoCyber = listaJogos.get(6)
    val jogoGod = listaJogos.get(7)
    val jogoSkyrim = listaJogos.get(18)


//    println(gamerCaroline)
//    println(jogoResidentVillage)

    val periodo1 = Periodo(LocalDate.now(), LocalDate.now().plusDays(7))
    val periodo2 = Periodo(LocalDate.now(), LocalDate.now().plusDays(3))
    val periodo3 = Periodo(LocalDate.now(), LocalDate.now().plusDays(10))

    val aluguel = gamerCaroline.alugaJogo(jogoResidentVillage,periodo1)
    //println(aluguel)

    gamerCaroline.alugaJogo(jogoSpider,periodo2)
    gamerCaroline.alugaJogo(jogoLastOfUs,periodo3)
    println(gamerCaroline.jogosAlugados)
    //println(gamerCaroline.jogosDoMes(Month.MARCH.value))

    val gamerCamila = listaGamer.get(5)
    gamerCamila.plano = PlanoAssinatura("PRATA", 9.90, 3, 0.15)
    gamerCamila.alugaJogo(jogoResidentVillage, periodo1)
    gamerCamila.alugaJogo(jogoSpider, periodo2)
    gamerCamila.alugaJogo(jogoLastOfUs, periodo3)
    gamerCamila.alugaJogo(jogoLastOfUs, periodo3)

    gamerCamila.recomendar(7)
    gamerCamila.recomendar(8)
    gamerCamila.recomendar(10)
    println(gamerCamila)
    println(gamerCamila.jogosAlugados)

    gamerCamila.alugaJogo(jogoResidentVillage, periodo1)
    println(gamerCamila.jogosAlugados.last())

//    jogoSpider.recomendar(10)
//    jogoSpider.recomendar(5)
//    println(jogoSpider)
//
//    gamerCamila.recomendarJogo(jogoResidentVillage, 7)
//    gamerCamila.recomendarJogo(jogoLastOfUs, 10)
//
//    gamerCaroline.recomendarJogo(jogoResidentVillage, 8)
//    gamerCaroline.recomendarJogo(jogoLastOfUs, 9)
//
//
//    println("Recomendações da Camila")
//    println(gamerCamila.jogosRecomendados)
//    println("Recomendações da Caroline")
//    println(gamerCaroline.jogosRecomendados)

    gamerCamila.recomendarJogo(jogoResidentVillage, 7)
    gamerCamila.recomendarJogo(jogoLastOfUs, 10)
    gamerCamila.recomendarJogo(jogoAssassins, 8)
    gamerCamila.recomendarJogo(jogoCyber, 7)
    gamerCamila.recomendarJogo(jogoGod, 10)
    gamerCamila.recomendarJogo(jogoDandara, 8)
    gamerCamila.recomendarJogo(jogoSkyrim, 8)
    gamerCamila.recomendarJogo(jogoSpider, 6)

    val gson = GsonBuilder()
        .excludeFieldsWithoutExposeAnnotation()
        .create()

    val serializacao = gson.toJson(gamerCamila.jogosRecomendados)
    //println(serializacao)

    val arquivo = File("jogosRecomendados-${gamerCamila.nome}.json")
    arquivo.writeText(serializacao)
    println(arquivo.absolutePath)
}