package br.com.mario_junior.orgs.dao

import br.com.mario_junior.orgs.model.Produto

class ProdutosDao {
    fun adiciona(produto: Produto) {
        produtos.add(produto)
    }

    fun buscaTodos() : List<Produto> {
        return produtos.toList()
    }

    companion object {
        private val produtos = mutableListOf<Produto>()
    }
}