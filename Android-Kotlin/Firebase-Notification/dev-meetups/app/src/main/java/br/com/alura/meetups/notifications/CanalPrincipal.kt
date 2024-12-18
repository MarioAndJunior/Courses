package br.com.alura.meetups.notifications

import android.app.NotificationChannel
import android.app.NotificationManager
import android.content.Context
import android.os.Build
import br.com.alura.meetups.R

const val IDENTIFICADOR_DO_CANAL = "9eef8c73-78e2-4575-adf3-e6fc0725783e"
class CanalPrincipal(
    private val context: Context,
    private val manager: NotificationManager
) {
    fun criaCanal() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            val name = context.getString(R.string.channel_name)
            val descriptionText = context.getString(R.string.channel_description)
            val importance = NotificationManager.IMPORTANCE_DEFAULT
            val mChannel = NotificationChannel(IDENTIFICADOR_DO_CANAL, name, importance)
            mChannel.description = descriptionText

            manager.createNotificationChannel(mChannel)
        }
    }
}