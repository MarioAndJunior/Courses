package br.com.alura.aluraesporte.repository

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import br.com.alura.aluraesporte.model.Usuario
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseAuthInvalidCredentialsException
import com.google.firebase.auth.FirebaseAuthInvalidUserException
import com.google.firebase.auth.FirebaseAuthUserCollisionException
import com.google.firebase.auth.FirebaseAuthWeakPasswordException
import com.google.firebase.auth.FirebaseUser
import java.lang.Exception

private const val TAG = "FirebaseAuthRepository"

class FirebaseAuthRepository(private val firebaseAuth: FirebaseAuth) {
    fun desloga() {
        firebaseAuth.signOut()
    }

    fun cadastra(usuario: Usuario): LiveData<Resource<Boolean>> {
        val result = MutableLiveData<Resource<Boolean>>()
        try {
            firebaseAuth.createUserWithEmailAndPassword(
                usuario.email,
                usuario.senha
            )
                .addOnSuccessListener {
                    Log.i(TAG, "cadastra: Sucesso")
                    result.value = Resource(true)
                }
                .addOnFailureListener {
                    Log.e(TAG, "cadastra: Erro ", it)
                    val mensagem = devolveErroDeCadastro(it)
                    result.value = Resource(false, mensagem)
                }
        } catch (e: IllegalArgumentException) {
            result.value = Resource(false, "E-mail ou senha não pode ser vazio")
        }

        return result
    }

    private fun devolveErroDeCadastro(it: Exception): String {
        return when (it) {
            is FirebaseAuthWeakPasswordException -> "Senha precisa de pelo menos 6 dígitos"
            is FirebaseAuthInvalidCredentialsException -> "Email inválido"
            is FirebaseAuthUserCollisionException -> "E-mail já cadastrado. Tente outro"
            else -> "Erro desconhecido"
        }
    }

    private fun devolveErroDeAutenticacao(it: Exception?): String {
        return when (it) {
            is FirebaseAuthInvalidUserException, is FirebaseAuthInvalidCredentialsException -> "E-mail ou senha incorretos"
            else -> "Erro desconhecido"
        }
    }

    fun estaLogado(): Boolean {
        val currentUser: FirebaseUser? = firebaseAuth.currentUser
        return currentUser != null
    }

    fun autentica(usuario: Usuario): LiveData<Resource<Boolean>> {
        val liveData = MutableLiveData<Resource<Boolean>>()
        try {
            firebaseAuth.signInWithEmailAndPassword(
                usuario.email,
                usuario.senha
            )
                .addOnCompleteListener { task ->
                    if (task.isSuccessful) {
                        liveData.value = Resource(true)
                    } else {
                        Log.e(TAG, "autentica: ", task.exception)
                        liveData.value = Resource(false, devolveErroDeAutenticacao(task.exception))
                    }
                }
        } catch (e: IllegalArgumentException) {
            liveData.value = Resource(false, "E-mail ou senha não pode ser vazio")
        }

        return liveData
    }

    fun usuario(): LiveData<Usuario> {
        val liveData = MutableLiveData<Usuario>()
        firebaseAuth.currentUser?.let { firebaseUser ->
            firebaseUser.email?.let { email ->
                liveData.value = Usuario(email)
            }
        }
        return liveData
    }
}