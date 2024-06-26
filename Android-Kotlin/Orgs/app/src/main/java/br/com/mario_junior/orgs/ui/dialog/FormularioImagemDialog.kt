package br.com.mario_junior.orgs.ui.dialog

import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import androidx.appcompat.app.AlertDialog
import br.com.mario_junior.orgs.databinding.FormularioImagemBinding

import br.com.mario_junior.orgs.extensions.tentaCarregarImagem

class FormularioImagemDialog(
    val context: Context
) {
    fun mostra(
        imagemPadrao: String? = null,
        quandoImagemCarregada: (imagem: String) -> Unit
    ) {
        val binding = FormularioImagemBinding
            .inflate(LayoutInflater.from(context)).apply {
                imagemPadrao?.let {
                    formularioImagemImageview.tentaCarregarImagem(it)
                    formularioImagemUrl.setText(it)
                }
                formularioImagemBotaoCarregar.setOnClickListener {
                    val url = formularioImagemUrl.text.toString()
                    formularioImagemImageview.tentaCarregarImagem(url)
                }
                AlertDialog.Builder(context)
                    .setView(root)
                    .setPositiveButton("Confirmar") { _, _ ->
                        val url = formularioImagemUrl.text.toString()
                        Log.i("FormularioImagemDialog", "mostra: $url")
                        quandoImagemCarregada(url)
                    }
                    .setNegativeButton("Cancelar") { _, _ ->
                    }
                    .show()
            }
    }
}