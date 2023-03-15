-- views servem para nomear consultas
-- cuidado com performance

-- sem view
select categoria
	from (
			select categoria.nome as categoria,
				count(curso.id) as numero_cursos
			from categoria
			join curso on curso.categoria_id = categoria.id
		group by categoria
	) as categoria_cursos
	where numero_cursos >= 3;
	
create view vw_cursos_por_categoria as select categoria.nome as categoria,
			count(curso.id) as numero_cursos
		from categoria
		join curso on curso.categoria_id = categoria.id
	group by categoria;
	
select * from vw_cursos_por_categoria;

-- com view
select categoria
	from vw_cursos_por_categoria as categoria_cursos
	where numero_cursos >= 3;
	
create view vw_cursos_programacao as select nome from curso where categoria_id = 2;

select * from vw_cursos_programacao;
select * from vw_cursos_programacao where nome = 'C++';

select categoria.id as categoria, vw_cursos_por_categoria.*
	from vw_cursos_por_categoria
	join categoria on categoria.nome = vw_cursos_por_categoria.categoria;