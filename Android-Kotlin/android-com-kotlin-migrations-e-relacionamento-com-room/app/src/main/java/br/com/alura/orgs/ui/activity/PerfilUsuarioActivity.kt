package br.com.alura.orgs.ui.activity

import android.os.Bundle
import androidx.lifecycle.lifecycleScope
import br.com.alura.orgs.databinding.ActivityPerfilUsuarioBinding
import kotlinx.coroutines.flow.collect
import kotlinx.coroutines.flow.filterNotNull
import kotlinx.coroutines.launch

class PerfilUsuarioActivity : UsuarioBaseActivity() {
    private val binding by lazy {
        ActivityPerfilUsuarioBinding.inflate(layoutInflater)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(binding.root)
        configuraUI()
        configuraBotaoSair()
    }

    private fun configuraUI() {
        lifecycleScope.launch {
            usuario
                .filterNotNull()
                .collect {
                    binding.activityPerfilUsuarioNomeUsuario.text = it.nome
                    binding.activityPerfilUsuarioUsuario.text = it.id
                }

        }
    }

    private fun configuraBotaoSair() {
        binding.activityPerfilUsuarioBtnSair.setOnClickListener {
            lifecycleScope.launch {
                deslogaUsuario()
            }
        }
    }
}