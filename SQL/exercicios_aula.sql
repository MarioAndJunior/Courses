CREATE SCHEMA academico;

CREATE TABLE academico.aluno (
    id SERIAL PRIMARY KEY,
    primeiro_nome VARCHAR(255) NOT NULL,
    ultimo_nome VARCHAR(255) NOT NULL,
    data_nascimento DATE NOT NULL
);


CREATE TABLE academico.categoria (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE academico.curso (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    categoria_id INTEGER NOT NULL REFERENCES academico.categoria(id)
);


CREATE TABLE academico.aluno_curso (
    aluno_id INTEGER NOT NULL REFERENCES academico.aluno(id),
    curso_id INTEGER NOT NULL REFERENCES academico.curso(id),
    PRIMARY KEY (aluno_id, curso_id)
);

DROP TABLE a;

CREATE TEMPORARY TABLE a (
	coluna varchar(255) NOT NULL CHECK(coluna <> '')
);

CREATE TEMPORARY TABLE a (
	coluna1 varchar(255) NOT NULL CHECK(coluna1 <> ''),
	coluna2 VARCHAR(255) NOT NULL,
	UNIQUE (coluna1, coluna2)
);

INSERT INTO a VALUES ('Mario');
INSERT INTO a VALUES ('a', 'b');
SELECT * FROM a;

ALTER TABLE a RENAME TO teste;
SELECT * FROM teste;

ALTER TABLE teste RENAME coluna1 TO primeira_coluna;
ALTER TABLE teste RENAME coluna2 TO segunda_coluna;
ALTER TABLE teste ADD COLUMN terceira_coluna VARCHAR(255);


CREATE TEMPORARY TABLE cursos_programacao (
	id_curso INTEGER PRIMARY KEY,
	nome_curso VARCHAR(255) NOT NULL
);

INSERT INTO cursos_programacao
SELECT academico.curso.id,
		academico.curso.nome
  FROM academico.curso
  JOIN academico.categoria ON academico.categoria.id = academico.curso.categoria_id
 WHERE categoria_id = 2;
 
 SELECT * FROM cursos_programacao;
 
 CREATE SCHEMA teste;
 CREATE TABLE teste.cursos_programacao (
	id_curso INTEGER PRIMARY KEY,
	nome_curso VARCHAR(255) NOT NULL
);

INSERT INTO teste.cursos_programacao
SELECT academico.curso.id,
		academico.curso.nome
  FROM academico.curso
  JOIN academico.categoria ON academico.categoria.id = academico.curso.categoria_id
 WHERE categoria_id = 2;
 
SELECT * FROM teste.cursos_programacao;

UPDATE teste.cursos_programacao SET nome_curso = nome
	FROM academico.curso WHERE teste.cursos_programacao.id_curso = academico.curso.id;
	
SELECT * FROM teste.cursos_programacao ORDER BY 1;

UPDATE academico.curso SET nome = 'PHP Básico' WHERE id = 4;


DELETE FROM academico.curso
      USING academico.categoria
      WHERE academico.categoria.id = curso.categoria_id
        AND academico.categoria.nome = 'Teste';

SELECT * FROM teste.cursos_programacao;

BEGIN;	
DELETE FROM teste.cursos_programacao;
ROLLBACK;

BEGIN;	
DELETE FROM teste.cursos_programacao 
	WHERE id_curso = 4;
ROLLBACK;

BEGIN;	
DELETE FROM teste.cursos_programacao 
	WHERE id_curso = 4;
COMMIT;
DROP TABLE auto;

CREATE TEMPORARY TABLE auto(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(30) NOT NULL);

CREATE TEMPORARY TABLE auto(
	id SERIAL PRIMARY KEY DEFAULT,
	nome VARCHAR(30) NOT NULL);	
	
INSERT INTO auto (nome) VALUES 	('Mario Junior');
INSERT INTO auto (id, nome) VALUES 	(4, 'Mario Junior');
INSERT INTO auto (nome) VALUES 	('Outro');

SELECT * FROM auto;
 