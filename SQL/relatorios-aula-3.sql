select * from curso;
select * from categoria;

select * from curso where categoria_id = 1 or categoria_id = 2;
-- dá no mesmo que o acima
select * from curso where categoria_id in (1, 2);

select id from categoria where categoria.nome not like '% %';

-- subquery
select * from curso where categoria_id in (
	select id from categoria where categoria.nome not like '% %'
);

-- mais uma subquery
select categoria 
	from (
			select categoria.nome as categoria,
				count(curso.id) as categoria_com_mais_matriculas
			from categoria
			join curso on curso.categoria_id = categoria.id
		group by categoria
	) as categoria_cursos
	where categoria_com_mais_matriculas > 3; 

  SELECT curso.nome,
         COUNT(aluno_curso.aluno_id) numero_alunos
    FROM curso
    JOIN aluno_curso ON aluno_curso.curso_id = curso.id
GROUP BY 1
     HAVING COUNT(aluno_curso.aluno_id) > 2
ORDER BY numero_alunos DESC;

select t.curso,
		t.numero_alunos
	from(
		SELECT curso.nome as curso,
         COUNT(aluno_curso.aluno_id) numero_alunos
			FROM curso
			JOIN aluno_curso ON aluno_curso.curso_id = curso.id
		GROUP BY 1
		
	) as t
	where t.numero_alunos > 2
	ORDER BY t.numero_alunos DESC;