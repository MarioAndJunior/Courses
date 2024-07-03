package br.com.alura.aluvery.ui.screens.state

import br.com.alura.aluvery.model.Product

class ProductFormScreenUiState(
    val urlText: String = "",
    val onUrlChange: (String) -> Unit = {},
    val nameText: String = "",
    val onNameChange: (String) -> Unit = {},
    val priceText: String = "",
    val onPriceChange: (String) -> Unit = {},
    val descriptionText: String = "",
    val onDescriptionChange: (String) -> Unit = {},
    val onSaveClick : (Product) -> Unit = {}
) {
    fun isShowImage(): Boolean {
        return urlText.isNotBlank()
    }
}