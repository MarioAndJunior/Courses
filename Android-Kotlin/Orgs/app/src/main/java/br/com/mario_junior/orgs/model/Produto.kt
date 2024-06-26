package br.com.mario_junior.orgs.model

import android.os.Parcelable
import androidx.room.Entity
import androidx.room.PrimaryKey
import kotlinx.parcelize.Parcelize
import java.math.BigDecimal
@Entity
@Parcelize
class Produto(
    @PrimaryKey(autoGenerate = true)
    val id: Long = 0L,
    val nome: String,
    val descricao: String,
    val valor: BigDecimal,
    val imagem: String? = null
) : Parcelable {
    override fun toString(): String {
        return "Produto - [Nome: $nome, Descricao: $descricao, Valor: $valor]"
    }
}
