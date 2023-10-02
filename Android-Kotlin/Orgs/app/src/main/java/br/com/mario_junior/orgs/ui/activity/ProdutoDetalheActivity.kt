package br.com.mario_junior.orgs.ui.activity

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.Menu
import android.view.MenuItem
import androidx.appcompat.app.AppCompatActivity
import br.com.mario_junior.orgs.R
import br.com.mario_junior.orgs.database.AppDatabase
import br.com.mario_junior.orgs.databinding.ActivityProdutoDetalheBinding
import br.com.mario_junior.orgs.extensions.formataParaMoedaBrasileira
import br.com.mario_junior.orgs.extensions.tentaCarregarImagem
import br.com.mario_junior.orgs.model.Produto
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

private const val TAG = "ProdutoDetalhes"

class ProdutoDetalheActivity :
    AppCompatActivity() {
    private var idProduto: Long = 0L
    private var produto: Produto? = null
    private val binding by lazy {
        ActivityProdutoDetalheBinding.inflate(layoutInflater)
    }

    private val produtoDao by lazy {
        AppDatabase.instancia(this).produtoDao()
    }
    private val scope = CoroutineScope(Dispatchers.IO)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        tentaCarregarProduto()
    }

    override fun onResume() {
        super.onResume()
        buscaProduto()
    }

    private fun buscaProduto() {
        scope.launch {
            produto = produtoDao.buscaPorId(idProduto)
            withContext(Dispatchers.Main) {
                produto?.let {
                    preencheCampos(it)
                } ?: finish()
            }
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.menu_detalhes_produto, menu)
        return super.onCreateOptionsMenu(menu)
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.menu_detalhes_produto_remover -> {
                Log.i(TAG, "onOptionsItemSelected: remover ${item.itemId}")
                scope.launch {
                    produto?.let { produtoDao.remove(it) }
                    finish()
                }
            }

            R.id.menu_detalhes_produto_editar -> {
                Log.i(TAG, "onOptionsItemSelected: editar ${item.itemId}")
                Intent(this, FormularioProdutoActivity::class.java).apply {
                    putExtra(CHAVE_PRODUTO_ID, idProduto)
                    startActivity(this)
                }
            }
        }

        return super.onOptionsItemSelected(item)
    }

    private fun tentaCarregarProduto() {
        idProduto = intent.getLongExtra(CHAVE_PRODUTO_ID, 0L)
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