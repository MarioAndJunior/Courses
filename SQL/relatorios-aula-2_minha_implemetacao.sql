update categoria set nome = 'Ciência de Dados' where id =4;

select nome from categoria where id = 4;

select * from aluno;
select curso_id from aluno_curso;

select *
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
	join curso on curso.id = aluno_curso.curso_id;

select  aluno.primeiro_nome,
		aluno.ultimo_nome,
		count(curso.id) numero_cursos
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
	join curso on curso.id = aluno_curso.curso_id
group by 1, 2
order by numero_cursos desc;

-- query para se obter os nomes dos alunos matriculados em mais cursos em oredem decrescente (relatório)
select  aluno.primeiro_nome,
		aluno.ultimo_nome,
		count(aluno_curso.curso_id) numero_cursos
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
group by 1, 2
order by numero_cursos desc;

-- cursos com mais alunos matriculados
select  curso.nome,
		count(aluno_curso.curso_id) numero_matriculados
	from curso
	join aluno_curso on aluno_curso.curso_id = curso.id
group by 1
order by numero_matriculados desc
	limit 1;

-- categorias com mais alunos matriculados
select categoria.nome,
		count(aluno_curso.curso_id) categoria_com_mais_matriculas
	from categoria
	join curso on curso.categoria_id = categoria.id
	join aluno_curso on aluno_curso.curso_id = curso.id
group by 1
order by categoria_com_mais_matriculas desc
	limit 1;

-- cursos com ao menos algum curso matriculado
select *
	from curso
	join aluno_curso on aluno_curso.curso_id = curso.id;