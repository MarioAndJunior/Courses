package br.com.alura.alugames.utilitario

import java.text.DecimalFormat
import java.text.DecimalFormatSymbols
import java.util.*

fun Double.formatoComDuasCasasDecimais(): Double {
    return DecimalFormat("#.00", DecimalFormatSymbols(Locale.US))
        .format(this).toDouble()
}