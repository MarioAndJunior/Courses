CREATE TEMPORARY TABLE auto (
        id SERIAL PRIMARY KEY,
        nome VARCHAR(30) NOT NULL
);

INSERT INTO auto (nome) VALUES ('Vinicius Dias');
INSERT INTO auto (id, nome) VALUES (2, 'Vinicius Dias');
INSERT INTO auto (id, nome) VALUES ('Outro nome');

SELECT * FROM auto;



CREATE SEQUENCE eu_criei;

DROP TABLE auto;

CREATE TEMPORARY TABLE auto (
        id INTEGER PRIMARY KEY DEFAULT eu_criei,
        nome VARCHAR(30) NOT NULL
);

SELECT CURRVAL ('eu_criei');
SELECT NEXTVAL ('eu_criei');

DROP TABLE auto;

CREATE TEMPORARY TABLE auto (
        id INTEGER PRIMARY KEY DEFAULT NEXTVAL ('eu_criei'),
        nome VARCHAR(30) NOT NULL
);

INSERT INTO auto (nome) VALUES ('Vinicius Dias');
INSERT INTO auto (id, nome) VALUES (2, 'Vinicius Dias');
INSERT INTO auto (id, nome) VALUES ('Outro nome');

SELECT * FROM auto;




CREATE TEMPORARY TABLE filme(
        id SERIAL PRIMARY KEY,
        nome VARCHAR (255) NOT NULL,
        classificacao VARCHAR(255) CHECK (classificacao IN ('LIVRE', '12_ANOS', '14_ANOS', '16_ANOS', '18_ANOS'))
);


DROP TABLE filme;
CREATE TEMPORARY TABLE filme(
        id SERIAL PRIMARY KEY,
        nome VARCHAR (255) NOT NULL,
        classificacao ENUM ('LIVRE', '12_ANOS','14_ANOS', '16_ANOS', '18_ANOS');
);


CREATE TYPE CLASSIFICACAO AS ENUM ('LIVRE', '12_ANOS','14_ANOS', '16_ANOS', '18_ANOS');

DROP TABLE filme;
CREATE TEMPORARY TABLE filme (
        id SERIAL PRIMARY KEY,
        nome VARCHAR (255) NOT NULL,
        classificacao CLASSIFICACAO
);


INSERT INTO filme (nome, classificacao) VALUES ('Um filme qualquer', 'Teste');

INSERT INTO filme (nome, classificacao) VALUES ('Um filme qualquer', '18_ANOS');

SELECT * FROM filme;