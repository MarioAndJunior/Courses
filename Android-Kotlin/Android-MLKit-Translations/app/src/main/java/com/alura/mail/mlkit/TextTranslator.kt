package com.alura.mail.mlkit

import android.util.Log
import com.alura.mail.model.DownloadState
import com.alura.mail.model.Language
import com.alura.mail.model.LanguageModel
import com.alura.mail.util.FileUtil
import com.google.mlkit.common.model.DownloadConditions
import com.google.mlkit.common.model.RemoteModelManager
import com.google.mlkit.nl.languageid.LanguageIdentification
import com.google.mlkit.nl.languageid.LanguageIdentifier
import com.google.mlkit.nl.translate.TranslateLanguage
import com.google.mlkit.nl.translate.TranslateRemoteModel
import com.google.mlkit.nl.translate.Translation
import com.google.mlkit.nl.translate.TranslatorOptions


class TextTranslator(private val fileUtil: FileUtil) {

    fun languageIdentifier(
        text: String,
        onSuccess: (Language) -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val languageIdentifier = LanguageIdentification.getClient()
        languageIdentifier.identifyLanguage(text)
            .addOnSuccessListener { languageCode ->
                val languageName =
                    translatableLanguageModels[languageCode]
                        ?: LanguageIdentifier.UNDETERMINED_LANGUAGE_TAG
                if (languageName != LanguageIdentifier.UNDETERMINED_LANGUAGE_TAG) {
                    onSuccess(Language(name = languageName, code = languageCode))
                } else {
                    onFailure()
                }

            }
            .addOnFailureListener {
                languageIdentifier.close()
                onFailure()
            }
            .addOnCompleteListener {
                languageIdentifier.close()
            }
    }

    fun textTranslate(
        text: String,
        sourceLanguage: String,
        targetLanguage: String,
        onSuccess: (String) -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val options = TranslatorOptions.Builder()
            .setSourceLanguage(TranslateLanguage.fromLanguageTag(sourceLanguage).toString())
            .setTargetLanguage(TranslateLanguage.fromLanguageTag(targetLanguage).toString())
            .build()
        val translator = Translation.getClient(options)

        translator.translate(text)
            .addOnSuccessListener {
                Log.d("Tradutor", it)
                onSuccess(it)
            }
            .addOnFailureListener {
                Log.e("Tradutor", "error ${it.message}")
                translator.close()
                onFailure()
            }
            .addOnCompleteListener {
                translator.close()
            }
    }

    fun verifyDownloadModel(
        modelCode: String,
        onSuccess: () -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val modelManager = RemoteModelManager.getInstance()

        modelManager.getDownloadedModels(TranslateRemoteModel::class.java)
            .addOnSuccessListener { models ->
                if (models.any { it.language == modelCode }) {
                    onSuccess()
                } else {
                    onFailure()
                }
            }
            .addOnFailureListener {
                onFailure()
            }
    }

    fun downloadModel(
        modelName: String,
        onSuccess: () -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val modelManager = RemoteModelManager.getInstance()
        val model = TranslateRemoteModel.Builder(modelName).build()
        val conditions = DownloadConditions.Builder()
            .requireWifi()
            .build()
        modelManager.download(model, conditions)
            .addOnSuccessListener {
                Log.d("Tradutor", "Modelo $modelName baixado")
                onSuccess()
            }
            .addOnFailureListener {
                Log.e("Tradutor", "Erro baixando o modelo $modelName: ", it)
                onFailure()
            }
    }

    fun removeModel(
        modelName: String,
        onSuccess: () -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val modelManager = RemoteModelManager.getInstance()
        val model = TranslateRemoteModel.Builder(modelName).build()
        modelManager.deleteDownloadedModel(model)
            .addOnSuccessListener {
                Log.d("Tradutor", "Modelo $modelName excluido")
                onSuccess()
            }
            .addOnFailureListener {
                Log.e("Tradutor", "Erro excluindo o modelo $modelName: ", it)
                onFailure()
            }
    }

    fun getAllModels(): List<LanguageModel> {
        return TranslateLanguage.getAllLanguages().map {model ->
            LanguageModel(
                id = model,
                name = translatableLanguageModels[model] ?: model,
                downloadState = DownloadState.NOT_DOWNLOADED,
                size = fileUtil.getSizeModel(model)
            )
        }
    }

    fun getDownloadedModels(
        onSuccess: (List<LanguageModel>) -> Unit = {},
        onFailure: () -> Unit = {}
    ) {
        val modelManager = RemoteModelManager.getInstance()

        modelManager.getDownloadedModels(TranslateRemoteModel::class.java)
            .addOnSuccessListener { models ->
                val languageModels = mutableListOf<LanguageModel>()
                models.forEach { model ->
                    try {
                        languageModels.add (
                            LanguageModel(
                                id = model.language,
                                name = translatableLanguageModels[model.language] ?: model.language,
                                downloadState = DownloadState.DOWNLOADED,
                                size = fileUtil.getSizeModel(model.modelNameForBackend)
                            )
                        )

                        Log.d("Tradutor", "model: ${model.modelNameForBackend}")
                    } catch (e: Exception) {
                        Log.e("Tradutor", "error: ", e)
                    }
                }

                onSuccess(languageModels)
            }
            .addOnFailureListener {
                onFailure()
            }
    }
}


