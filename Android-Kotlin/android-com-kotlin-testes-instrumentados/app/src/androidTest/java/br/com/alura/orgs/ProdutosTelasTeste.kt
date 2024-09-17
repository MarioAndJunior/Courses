package br.com.alura.orgs

import androidx.test.core.app.ActivityScenario.*
import androidx.test.espresso.Espresso.*
import androidx.test.espresso.action.ViewActions
import androidx.test.espresso.action.ViewActions.*
import androidx.test.espresso.assertion.ViewAssertions.*
import androidx.test.espresso.matcher.ViewMatchers.*
import androidx.test.ext.junit.rules.ActivityScenarioRule
import androidx.test.platform.app.InstrumentationRegistry
import br.com.alura.orgs.database.AppDatabase
import br.com.alura.orgs.ui.activity.ListaProdutosActivity
import org.junit.Before
import org.junit.Rule
import org.junit.Test

class ProdutosTelasTeste {
    @get:Rule
    val rule = ActivityScenarioRule(ListaProdutosActivity::class.java)

    @Before
    fun preparaAmbiente() {
        AppDatabase.instancia(
            InstrumentationRegistry.getInstrumentation().targetContext
        ).clearAllTables()
    }

    @Test
    fun deveMostrarONomeDoAplicativo() {
        onView(withText("Orgs")).check(matches(isDisplayed()))
    }

    @Test
    fun deveMostrarCamposNecessariosParaCriarUmProduto() {
        clicaNoFab()

        onView(withId(R.id.activity_formulario_produto_nome)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_produto_descricao)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_produto_descricao)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_produto_botao_salvar)).check(matches(isDisplayed()))
    }

    @Test
    fun deveCadastrarUmProdutoCorretamente() {
        clicaNoFab()

        preencheCamposDoFormulario("Banana", "Banana prata", "6.99")
        clicamSalvar()

        onView(withText("Banana")).check(matches(isDisplayed()))
    }

    @Test
    fun deveSerCapazDeEditarUmProduto() {
        clicaNoFab()
        preencheCamposDoFormulario("Banana nanica", "Da feira", "4.99")
        clicamSalvar()

        onView(withText("Banana nanica"))
            .perform(
            click()
        )

        onView(withId(R.id.menu_detalhes_produto_editar))
            .perform(click()
            )

        preencheCamposDoFormulario("Banana prata", "Da vendinha", "3.99")
        clicamSalvar()

        onView(withText("Banana prata")).check(matches(isDisplayed()))
    }

    private fun clicamSalvar() {
        onView(withId(R.id.activity_formulario_produto_botao_salvar))
            .perform(
                click()
            )
    }

    private fun preencheCamposDoFormulario(
        nome: String,
        descricao: String,
        preco: String
    ) {
        onView(withId(R.id.activity_formulario_produto_nome))
            .perform(
                replaceText(nome),
                ViewActions.closeSoftKeyboard()
            )
        onView(withId(R.id.activity_formulario_produto_descricao))
            .perform(
                replaceText(descricao),
                ViewActions.closeSoftKeyboard()
            )
        onView(withId(R.id.activity_formulario_produto_valor))
            .perform(
                replaceText(preco),
                ViewActions.closeSoftKeyboard()
            )
    }

    private fun clicaNoFab() {
        onView(withId(R.id.activity_lista_produtos_fab))
            .perform(
                click()
            )
    }

}