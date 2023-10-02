package br.com.mario_junior.orgs.database.converter

import androidx.room.TypeConverter
import java.math.BigDecimal

class Converters {
    @TypeConverter
    fun deDouble(valor: Double?): BigDecimal {
        return valor?.let { BigDecimal(valor.toString()) } ?: BigDecimal.ZERO
    }

    @TypeConverter
    fun deBigDecimal(valor: BigDecimal?): Double? {
        return valor?.let { valor.toDouble() }
    }
}