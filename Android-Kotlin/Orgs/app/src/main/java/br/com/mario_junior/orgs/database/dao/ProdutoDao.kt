package br.com.mario_junior.orgs.database.dao

import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import androidx.room.Update
import br.com.mario_junior.orgs.model.Produto
import kotlinx.coroutines.flow.Flow

@Dao
interface ProdutoDao {
    @Query("SELECT * FROM produto")
    /*suspend*/ fun buscaTodos() : Flow<List<Produto>>

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    /*suspend*/ fun salva(vararg produto: Produto)

    @Delete
    /*suspend*/ fun remove(produto: Produto)

    @Query("SELECT * FROM Produto WHERE id = :id")
    /*suspend*/ fun buscaPorId(id: Long) : Produto?
}