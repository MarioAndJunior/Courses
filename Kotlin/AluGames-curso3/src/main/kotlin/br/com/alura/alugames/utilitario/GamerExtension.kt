package br.com.alura.alugames.utilitario

import br.com.alura.alugames.data.GamerEntity
import br.com.alura.alugames.modelo.Gamer
import br.com.alura.alugames.modelo.InfoGamerJson

fun InfoGamerJson.criaGamer(): Gamer {
    return Gamer(this.nome, this.email, this.dataNascimento, this.usuario)
}

fun Gamer.toEntity(): GamerEntity {
    return GamerEntity(
        this.nome,
        this.email,
        this.usuario,
        this.dataNascimento,
        this.id,
        this.plano.toEntity()
    )
}

fun GamerEntity.toModel() : Gamer {
    return Gamer(
        this.nome,
        this.email,
        this.usuario,
        this.dataNascimento,
        this.id
    ).apply { plano = this@toModel.plano.toModel() }
}