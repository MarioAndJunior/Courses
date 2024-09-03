package br.com.alura.alugames.data

import br.com.alura.alugames.modelo.Jogo
import br.com.alura.alugames.utilitario.toEntity
import br.com.alura.alugames.utilitario.toModel
import javax.persistence.EntityManager

class JogosDAO(manager: EntityManager) : DAO<Jogo, JogoEntity>(manager, JogoEntity::class.java) {
    override fun toEntity(objeto: Jogo): JogoEntity {
       return objeto.toEntity()
    }

    override fun toModel(entity: JogoEntity): Jogo {
        return entity.toModel()
    }

    //Modo roots com JDBC
//    fun getJogos(): List<Jogo> {
//        val listaJogos = mutableListOf<Jogo>()
//
//        val conexao = Banco.obterConexao()
//
//        conexao?.let {
//            try {
//                val statement = conexao.createStatement()
//                val resultado = statement.executeQuery("select * from Jogos")
//
//                while (resultado.next()) {
//                    val id = resultado.getInt("id")
//                    val titulo = resultado.getString("titulo")
//                    val capa = resultado.getString("capa")
//                    val descricao = resultado.getString("descricao")
//                    val preco = resultado.getDouble("preco")
//
//                    val jogo = Jogo(
//                        titulo, capa, preco, descricao, id
//                    )
//
//                    listaJogos.add(jogo)
//                }
//                statement.close()
//            } finally {
//                it.close()
//            }
//        }
//
//        return listaJogos
//    }
//
//    fun adicionarJogo(jogo: Jogo) {
//        val conexao = Banco.obterConexao()
//        val insert = "INSERT INTO JOGOS (TITULO, CAPA, PRECO, DESCRICAO) VALUES (?, ?, ?, ?)"
//
//        conexao?.let {
//            try {
//                val statement = conexao.prepareStatement(insert)
//                statement.setString(1, jogo.titulo)
//                statement.setString(2, jogo.capa)
//                statement.setDouble(3, jogo.preco)
//                statement.setString(4, jogo.descricao)
//
//                statement.executeUpdate()
//                statement.close()
//            } finally {
//                it.close()
//            }
//        }
//    }
}