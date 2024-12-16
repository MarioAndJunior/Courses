package br.com.alura.orgs

import androidx.test.core.app.ActivityScenario.*
import androidx.test.espresso.Espresso.*
import androidx.test.espresso.action.ViewActions
import androidx.test.espresso.action.ViewActions.*
import androidx.test.espresso.assertion.ViewAssertions.*
import androidx.test.espresso.matcher.ViewMatchers.*
import br.com.alura.orgs.ui.activity.FormularioCadastroUsuarioActivity
import br.com.alura.orgs.ui.activity.LoginActivity
import org.junit.Test

class UsuariosTelasTest {
    @Test
    fun deveMostrarONomeDoAplicativo() {
        launch(LoginActivity::class.java)
        onView(withText("Orgs")).check(matches(isDisplayed()))
    }

    @Test
    fun deveConterCamposNecessariosParaLogar() {
        launch(LoginActivity::class.java)

        onView(withId(R.id.activity_login_usuario)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_login_senha)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_login_botao_entrar)).check(matches(isDisplayed()))
    }

    @Test
    fun deveConterCamposNecessariosParaCadastro() {
        launch(FormularioCadastroUsuarioActivity::class.java)

        onView(withId(R.id.activity_formulario_cadastro_usuario)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_cadastro_email)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_cadastro_senha)).check(matches(isDisplayed()))
        onView(withId(R.id.activity_formulario_cadastro_botao_cadastrar)).check(matches(isDisplayed()))
    }

    @Test
    fun deveLogarUsuarioCorretamente() {
        launch(LoginActivity::class.java)

        onView(withId(R.id.activity_login_usuario)).perform(
            typeText("User"),
            ViewActions.closeSoftKeyboard()
        )

        onView(withId(R.id.activity_login_senha)).perform(
            typeText("MyPassword"),
            ViewActions.closeSoftKeyboard()
        )
        onView(withId(R.id.activity_login_botao_entrar)).perform(
            click()
        )
    }

    @Test
    fun deveCadastrarUsuarioCorretamente() {
        launch(FormularioCadastroUsuarioActivity::class.java)

        onView(withId(R.id.activity_formulario_cadastro_usuario)).perform(
            typeText("User"),
            ViewActions.closeSoftKeyboard()
        )

        onView(withId(R.id.activity_formulario_cadastro_email)).perform(
            typeText("usuario@usuario.com"),
            ViewActions.closeSoftKeyboard()
        )

        onView(withId(R.id.activity_formulario_cadastro_senha)).perform(
            typeText("MyPassword"),
            ViewActions.closeSoftKeyboard()
        )

        onView(withId(R.id.activity_formulario_cadastro_botao_cadastrar)).perform(
            click()
        )
    }
}