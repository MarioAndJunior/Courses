package br.com.alura.aluvery.dao

import androidx.compose.runtime.mutableStateListOf
import br.com.alura.aluvery.model.Product
import br.com.alura.aluvery.sampledata.sampleProducts

class ProductDao {
    companion object {
        // Conhecido como snapshot state list
        //private val products = mutableStateListOf<Product>(*sampleProducts.toTypedArray()) // Asterisco para passar a referencia, já que o construtor espera varargs
        private val products = mutableStateListOf<Product>()
    }

    fun products() = products.toList()
    fun save(product: Product) {
        products.add(product)
    }
}