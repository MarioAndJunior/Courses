package br.com.mario_junior.orgs.database

import android.content.Context
import android.util.Log
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.room.TypeConverters
import br.com.mario_junior.orgs.database.converter.Converters
import br.com.mario_junior.orgs.database.dao.ProdutoDao
import br.com.mario_junior.orgs.model.Produto

private const val TAG = "AppDatabase"

@Database(entities = [Produto::class], version = 1, exportSchema = true)
@TypeConverters(Converters::class)
abstract class AppDatabase : RoomDatabase() {
    abstract fun produtoDao(): ProdutoDao

    companion object {
        @Volatile
        private lateinit var db: AppDatabase

        fun instancia(context: Context): AppDatabase {
            if (::db.isInitialized) return db
            return Room.databaseBuilder(
                context,
                AppDatabase::class.java,
                "orgs.db"
            ).build().also {
                    db = it
                    Log.i(TAG, "instancia criada ")
                }
        }
    }
}