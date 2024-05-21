package br.com.alura.ceep.webclient.model

data class NotaRequisiscao(
    val titulo: String,
    val descricao: String,
    val imagem: String? = null
) {
}