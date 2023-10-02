package br.com.mario_junior.orgs.ui.activity

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.room.Room
import br.com.mario_junior.orgs.database.AppDatabase
import br.com.mario_junior.orgs.databinding.ActivityListaProdutosActivityBinding
import br.com.mario_junior.orgs.ui.recyclerView.adapter.ListaProdutosAdapter
import kotlinx.coroutines.CoroutineDispatcher
import kotlinx.coroutines.CoroutineExceptionHandler
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.MainScope
import kotlinx.coroutines.cancel
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.withContext

private const val TAG = "ListaProdutos"

class ListaProdutosActivity : AppCompatActivity() {

    private val adapter = ListaProdutosAdapter(this)
    private val binding by lazy {
        ActivityListaProdutosActivityBinding.inflate(layoutInflater)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        configuraRecyclerView()
        configuraFab()
    }

    private fun testeCoroutineBloqueante() {
        runBlocking {
            Log.i(TAG, "onCreate: runBlocking init")
            repeat(100) {
                launch {
                    Log.i(TAG, "onCreate: launch init $it")
                    delay(2000)
                    Log.i(TAG, "onCreate: launch finish $it")
                }
            }
            Log.i(TAG, "onCreate: runBlocking finish")
        }
    }

    override fun onResume() {
        super.onResume()
        val produtoDao = AppDatabase.instancia(this).produtoDao()
        val handler = CoroutineExceptionHandler { coroutineContext, throwable ->
            Toast.makeText(
                this@ListaProdutosActivity,
                throwable.message,
                Toast.LENGTH_SHORT
            ).show()
        }
        val scope = MainScope()
        scope.launch {
            repeat(1000) {
                Log.i(TAG, "onResume: coroutine está em execução $it")
                delay(1000)
            }
        }
        scope.cancel()
        scope.launch(handler) {

            val produtos = withContext(Dispatchers.IO) {
                produtoDao.buscaTodos()
            }
//            throw Exception("Deu ruim na coroutine")
            adapter.atualiza(produtos)
        }
    }

    private fun configuraFab() {
        val fab = binding.activityListaProdutosFab
        fab.setOnClickListener {
            vaiParaFormularioProduto()
        }
    }

    private fun vaiParaFormularioProduto() {
        val intent = Intent(this, FormularioProdutoActivity::class.java)
        startActivity(intent)
    }

    private fun configuraRecyclerView() {
        val recyclerView = binding.activityListaProdutosRecyclerView
        recyclerView.adapter = adapter
        adapter.quandoClicaNoItem = {
            val intent = Intent(
                this,
                ProdutoDetalheActivity::class.java
            ).apply {
                putExtra(CHAVE_PRODUTO_ID, it.id)
            }
            startActivity(intent)
        }
    }
}