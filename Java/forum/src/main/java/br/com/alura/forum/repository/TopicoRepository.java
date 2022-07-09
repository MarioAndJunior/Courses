package br.com.alura.forum.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import br.com.alura.forum.modelo.Topico;

public interface TopicoRepository  extends JpaRepository<Topico, Long>{

	//Aqui ele monta a query de maneria automatica com base no nome do metodo, correspondendo a entidade/ relacionamento, caso haja ambiguidade em algum nome pode-se usar o underscore para separar as entidades
	List<Topico> findByCursoNome(String nomeCurso);
	
	//outra abordagem
	//@Query("SELECT t FROM Topico t WHERE t.curso.nome = :nomeCurso")
    //List<Topico> carregarPorNomeDoCurso(@Param("nomeCurso")(String nomeCurso);

}
