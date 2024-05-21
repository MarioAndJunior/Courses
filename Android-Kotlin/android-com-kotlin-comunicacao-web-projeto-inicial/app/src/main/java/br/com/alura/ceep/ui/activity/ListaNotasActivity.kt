package br.com.alura.ceep.ui.activity

import android.content.Intent
import android.graphics.drawable.ColorDrawable
import android.os.Bundle
import android.view.View.GONE
import android.view.View.VISIBLE
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.Lifecycle
import androidx.lifecycle.lifecycleScope
import androidx.lifecycle.repeatOnLifecycle
import br.com.alura.ceep.database.AppDatabase
import br.com.alura.ceep.databinding.ActivityListaNotasBinding
import br.com.alura.ceep.extensions.vaiPara
import br.com.alura.ceep.repository.NotaRepository
import br.com.alura.ceep.ui.recyclerview.adapter.ListaNotasAdapter
import br.com.alura.ceep.webclient.NotaWebClient
import kotlinx.coroutines.launch

class ListaNotasActivity : AppCompatActivity() {

    private val binding by lazy {
        ActivityListaNotasBinding.inflate(layoutInflater)
    }
    private val adapter by lazy {
        ListaNotasAdapter(this)
    }
    private val repository by lazy {
        NotaRepository(
            AppDatabase.instancia(this).notaDao(),
            NotaWebClient()
        )
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        configuraSwipeToRefresh()
        configuraFab()
        configuraRecyclerView()
        lifecycleScope.launch {
            launch {
                sincroniza()
            }
            repeatOnLifecycle(Lifecycle.State.STARTED) {
                buscaNotas()
            }
        }

        //retrofitSemCoroutines()
    }

    private fun configuraSwipeToRefresh() {
        binding.refresh.setOnRefreshListener {
            lifecycleScope.launch {
                sincroniza()
                binding.refresh.isRefreshing = false
            }
        }
    }

    private suspend fun sincroniza() {
        repository.sincroniza()
    }

    private fun configuraFab() {
        binding.activityListaNotasFab.setOnClickListener {
            Intent(this, FormNotaActivity::class.java).apply {
                startActivity(this)
            }
        }
    }

    private fun configuraRecyclerView() {
        binding.activityListaNotasRecyclerview.adapter = adapter
        adapter.quandoClicaNoItem = { nota ->
            vaiPara(FormNotaActivity::class.java) {
                putExtra(NOTA_ID, nota.id)
            }
        }
    }

    private suspend fun buscaNotas() {
        repository.buscaTodas()
            .collect { notasEncontradas ->
                binding.activityListaNotasMensagemSemNotas.visibility =
                    if (notasEncontradas.isEmpty()) {
                        binding.activityListaNotasRecyclerview.visibility = GONE
                        VISIBLE
                    } else {
                        binding.activityListaNotasRecyclerview.visibility = VISIBLE
                        adapter.atualiza(notasEncontradas)
                        GONE
                    }
            }
    }

    private fun retrofitSemCoroutines() {
        //        val call: Call<List<NotaResposta>> = RetrofitInicializador().notaService.buscaTodas()
        //Com coroutines manual (não recomendado)
        //        lifecycleScope.launch(Dispatchers.IO) {
        //            val resposta: Response<List<NotaResposta>> = call.execute()
        //
        //            resposta.body()?.let {
        //                val notas = it.map {
        //                    it.nota
        //                }
        //                Log.i("ListaNotas", "onCreate: $notas")
        //            }
        //        }

        //"Padrão Java"
        //        call.enqueue(object : Callback<List<NotaResposta>?> {
        //            override fun onResponse(
        //                call: Call<List<NotaResposta>?>,
        //                resposta: Response<List<NotaResposta>?>
        //            ) {
        //                resposta.body()?.let {
        //                    val notas = it.map {
        //                        it.nota
        //                    }
        //                    Log.i("ListaNotas", "onCreate: $notas")
        //                }
        //            }
        //
        //            override fun onFailure(call: Call<List<NotaResposta>?>, t: Throwable) {
        //                Log.e("ListaNotas", "onFailure: ", t)
        //            }
        //        })
    }
}