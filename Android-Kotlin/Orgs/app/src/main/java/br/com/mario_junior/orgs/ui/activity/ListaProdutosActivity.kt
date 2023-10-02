package br.com.mario_junior.orgs.ui.activity

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import br.com.mario_junior.orgs.database.AppDatabase
import br.com.mario_junior.orgs.databinding.ActivityListaProdutosActivityBinding
import br.com.mario_junior.orgs.ui.recyclerView.adapter.ListaProdutosAdapter
import kotlinx.coroutines.CoroutineExceptionHandler
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.delay
import kotlinx.coroutines.flow.collect
import kotlinx.coroutines.flow.flow
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import kotlinx.coroutines.withContext

private const val TAG = "ListaProdutos"

class ListaProdutosActivity : AppCompatActivity() {

    private val adapter = ListaProdutosAdapter(this)
    private val binding by lazy {
        ActivityListaProdutosActivityBinding.inflate(layoutInflater)
    }

    //Sem o lifecycle
    //private val job = Job()

    private val dao by lazy {
        AppDatabase.instancia(this).produtoDao()
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        configuraRecyclerView()
        configuraFab()
        lifecycleScope.launch {
            dao.buscaTodos().collect {
                    produtos -> adapter.atualiza(produtos)
            }
        }
//        exemploDeFlow()
    }

    private fun exemploDeFlow() {
        val fluxoDeNumeros = flow<Int> {
            repeat(100) {
                emit(it)
                delay(1000)
            }
        }

        lifecycleScope.launch {
            fluxoDeNumeros.collect { numero ->
                Log.i(TAG, "onCreate: $numero")

            }
        }
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

//        val handler = montaHandlerNaMao()

//        val scope = MainScope()
//        testeCicloCoroutines(scope)
//        testeExceptionCoroutine(scope, handler)

//        scope.launch {
//            val produtos = buscaTodosProdutos()
//            adapter.atualiza(produtos)
//        }
    }

    //Sem a biblioteca do Room + corountine "-ktx"
    private suspend fun buscaTodosProdutos() =
        withContext(Dispatchers.IO) {
            dao.buscaTodos().collect()
        }

//    mais verboso
//    private suspend fun buscaTodosProdutos(): List<Produto> {
//        val produtos = withContext(Dispatchers.IO) {
//            dao.buscaTodos()
//        }
//        return produtos
//    }

//    private fun testeExceptionCoroutine(
//        scope: CoroutineScope,
//        handler: CoroutineExceptionHandler,
//    ) {
//        scope.launch(handler) {
//            val produtos = buscaTodosProdutos()
//            throw Exception("Deu ruim na coroutine")
//            adapter.atualiza(produtos)
//        }
//    }

    private fun testeCicloCoroutines(scope: CoroutineScope) {
        scope.launch(/*job*/) {
            Log.i(TAG, "onResume: contexto da coroutine $coroutineContext")
            repeat(1000) {
                Log.i(TAG, "onResume: coroutine está em execução $it")
                delay(1000)
                //                job.cancel()
            }

//        job.cancel()
//        scope.cancel() // Evitar cancelamento de escopo
        }
    }

    private fun montaHandlerNaMao(): CoroutineExceptionHandler {
        val handler = CoroutineExceptionHandler { coroutineContext, throwable ->
            Toast.makeText(
                this@ListaProdutosActivity,
                throwable.message,
                Toast.LENGTH_SHORT
            ).show()
        }
        return handler
    }

//    override fun onDestroy() {
//        super.onDestroy()
//        //Sem o lifecycle tem que destruir na mão
//        //job.cancel()
//    }

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