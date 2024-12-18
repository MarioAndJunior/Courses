package br.com.alura.meetups.fcm

import android.app.NotificationManager
import android.util.Log
import androidx.core.app.NotificationCompat
import androidx.core.graphics.drawable.toBitmap
import br.com.alura.meetups.R
import br.com.alura.meetups.model.Dispositivo
import br.com.alura.meetups.notifications.IDENTIFICADOR_DO_CANAL
import br.com.alura.meetups.notifications.Notificacao
import br.com.alura.meetups.preferences.FirebaseTokenPreferences
import br.com.alura.meetups.repository.DispositivoRepository
import coil.imageLoader
import coil.request.ImageRequest
import com.google.firebase.messaging.FirebaseMessagingService
import com.google.firebase.messaging.RemoteMessage
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import org.koin.android.ext.android.inject

private const val TAG = "MeetupsFCM"

class MeetupsFirebaseMessagingService: FirebaseMessagingService() {
    private val dispositivoRepository: DispositivoRepository by inject()
    private val preferences: FirebaseTokenPreferences by inject()

    override fun onNewToken(token: String) {
        super.onNewToken(token)
        Log.i(TAG, "onNewToken: $token")
        preferences.tokenNovo()
        dispositivoRepository.salva(Dispositivo(token = token))
    }

    override fun onMessageReceived(message: RemoteMessage) {
        super.onMessageReceived(message)
        Log.i(TAG, "onMessageReceived: recebeu notificacao: ${message.notification}")
        Log.i(TAG, "onMessageReceived: recebeu dados: ${message.data}")
        Notificacao(this).mostra(message.data)
    }
}