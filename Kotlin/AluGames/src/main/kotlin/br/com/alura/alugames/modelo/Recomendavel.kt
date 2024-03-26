package br.com.alura.alugames.modelo

interface Recomendavel {
    val media: Double

    fun recomendar(nota: Int)

    fun notaEhValida(nota: Int): Boolean {
        return nota in 1..10
    }
}