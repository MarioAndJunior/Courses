package br.com.alura.aluraesporte.ui.fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.lifecycle.Observer
import br.com.alura.aluraesporte.R
import br.com.alura.aluraesporte.ui.viewmodel.MinhaContaViewModel
import kotlinx.android.synthetic.main.fragment_minha_conta.minha_conta_email
import org.koin.androidx.viewmodel.ext.android.viewModel

class MinhaContaFragment : BaseFragment() {
    private val viewModel: MinhaContaViewModel by viewModel()
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_minha_conta, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        viewModel.usuario.observe(viewLifecycleOwner, Observer {
            it?.let {
                minha_conta_email.text = it.email
            }
        })
    }
}