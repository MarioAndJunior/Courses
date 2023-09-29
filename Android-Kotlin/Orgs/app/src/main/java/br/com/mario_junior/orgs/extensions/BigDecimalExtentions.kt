package br.com.mario_junior.orgs.extensions

import java.math.BigDecimal
import java.text.NumberFormat
import java.util.Locale

public fun BigDecimal.formataParaMoedaBrasileira(): String {
    val formatador: NumberFormat = NumberFormat.getCurrencyInstance(Locale("pt", "br"))
    return formatador.format(this)
}