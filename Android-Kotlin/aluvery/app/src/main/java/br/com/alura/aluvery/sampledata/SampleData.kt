package br.com.alura.aluvery.sampledata

import br.com.alura.aluvery.R
import br.com.alura.aluvery.model.Product
import java.math.BigDecimal

val sampleProducts = listOf(

    Product(
        "Hamburguer",
        BigDecimal("12.99"),
        R.drawable.burger
    ),
    Product(
        "Pizza",
        BigDecimal("19.99"),
        R.drawable.pizza
    ),
    Product(
        "Batata Frita",
        BigDecimal("9.99"),
        R.drawable.fries
    )
)