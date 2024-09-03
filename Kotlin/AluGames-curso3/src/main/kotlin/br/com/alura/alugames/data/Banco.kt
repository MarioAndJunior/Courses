package br.com.alura.alugames.data

import javax.persistence.EntityManager
import javax.persistence.EntityManagerFactory
import javax.persistence.Persistence

object Banco {
    //modo roots na unha com JDBC
//    fun obterConexao(): Connection? {
//        return try {
//            DriverManager.getConnection("jdbc:mysql://localhost:3306/alugames", "root", "root")
//        } catch (e: SQLException) {
//            e.printStackTrace()
//            null
//        }
//    }

    // aqui usa ORM (JPA)
    fun getEntityManager(): EntityManager {
        val factory: EntityManagerFactory = Persistence.createEntityManagerFactory("alugames")

        return factory.createEntityManager()
    }
}