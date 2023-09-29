package br.com.mario_junior.orgs.ui.activity

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import br.com.mario_junior.orgs.databinding.ActivityProdutoDetalheBinding
import br.com.mario_junior.orgs.extensions.formataParaMoedaBrasileira
import br.com.mario_junior.orgs.extensions.tentaCarregarImagem
import br.com.mario_junior.orgs.model.Produto

class ProdutoDetalheActivity :
    AppCompatActivity() {
    private val binding by lazy {
        ActivityProdutoDetalheBinding.inflate(layoutInflater)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        tentaCarregarProduto()
    }

    private fun tentaCarregarProduto() {
        intent.getParcelableExtra<Produto>(CHAVE_PRODUTO)?.let { produtoCarregado ->
            preencheCampos(produtoCarregado)
        } ?: finish()
    }

    private fun preencheCampos(produtoCarregado: Produto) {
        with(binding) {
            activityProdutoDetalheImageview.tentaCarregarImagem(produtoCarregado.imagem)
            activityProdutoDetalheTitulo.text = produtoCarregado.nome
            activityProdutoDetalheDescricao.text = produtoCarregado.descricao
            activityProdutoDetalhePreco.text =
                produtoCarregado.valor.formataParaMoedaBrasileira()
        }
    }
}