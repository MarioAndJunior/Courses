CREATE SCHEMA teste;

CREATE TABLE teste.cursos_programacao (
    id_curso INTEGER PRIMARY KEY,
    nome_curso VARCHAR(255) NOT NULL
);

INSERT INTO teste.cursos_programacao
SELECT academico.curso.id,
       academico.curso.nome
  FROM academico.curso
 WHERE categoria_id = 2;

 SELECT * FROM teste.cursos_programacao;


UPDATE teste.cursos_programacao SET nome_curso = nome
	FROM academico.curso WHERE testes.cursos_programacao.id_curso = academico.curso.id
   AND academico.curso_id < 10;

SELECT * FROM academico.curso ORDER BY 1;


BEGIN;
DELETE FROM teste.cursos_programacao;
ROLLBACK;

SELECT * FROM teste.cursos_programacao;

BEGIN;
DELETE FROM teste.cursos_programacao WHERE id_curso = 60;
COMMIT;

SELECT * FROM teste.cursos_programacao;