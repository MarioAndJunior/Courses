package br.com.mario_junior.orgs.model

import android.os.Parcelable
import kotlinx.parcelize.Parcelize
import java.math.BigDecimal

@Parcelize
class Produto(
    val nome: String,
    val descricao: String,
    val valor: BigDecimal,
    val imagem: String? = null
) : Parcelable {
    override fun toString(): String {
        return "Produto - [Nome: $nome, Descricao: $descricao, Valor: $valor]"
    }
}
