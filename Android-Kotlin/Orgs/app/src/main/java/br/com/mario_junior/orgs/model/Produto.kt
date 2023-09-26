package br.com.mario_junior.orgs.model

import java.math.BigDecimal

class Produto(
    val nome: String,
    val descricao: String,
    val valor: BigDecimal
) {
    override fun toString(): String {
        return "Produto - [Nome: $nome, Descricao: $descricao, Valor: $valor]"
    }
}
