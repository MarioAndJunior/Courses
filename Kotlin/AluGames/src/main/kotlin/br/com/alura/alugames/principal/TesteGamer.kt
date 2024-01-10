import br.com.alura.alugames.modelo.Gamer

fun main() {
    val gamer1 = Gamer("Fulano", "fulano@fulanos.com")
    val gamer2 = Gamer("Fulano Dois", "fulano.dois@fulanos.com", "13/11/1985", "gamerTop")

    println(gamer1)
    println(gamer2)

    gamer1.let {
        it.dataNascimento = "28/07/1983"
        it.usuario = "gamerNotTop"
    }.also {
        println(gamer1.idInterno)
    }

    println(gamer1)

    gamer1.usuario = "fulaninho"

    println(gamer1)
}