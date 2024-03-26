package br.com.alura.alugames.modelo

import br.com.alura.alugames.utilitario.formatoComDuasCasasDecimais

sealed class Plano(val tipo: String) {
    open fun obterValor(aluguel: Aluguel) : Double {
        return (aluguel.jogo.preco * aluguel.periodo.emDias).formatoComDuasCasasDecimais()
    }
}