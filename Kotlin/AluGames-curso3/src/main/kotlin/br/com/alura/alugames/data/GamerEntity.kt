package br.com.alura.alugames.data

import javax.persistence.*

@Entity
@Table(name = "gamers")
class GamerEntity(
    val nome: String = "Nome do gamer",
    val email: String = "gamer@gamer.com",
    val usuario: String? = "Nick do gamer",
    val dataNascimento: String? = "13/11/1985",
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    val id: Int = 0,
    @ManyToOne
    val plano: PlanoEntity = PlanoAvulsoEntity()
) {
}