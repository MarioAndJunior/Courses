select (primeiro_nome || ' ' || ultimo_nome) as nome_completo from aluno;

select 'Mario' || ' ' || 'Junior';

-- anula tudo
select 'Mario' || ' ' || NULL;

-- ignora os null
select concat('Mario', ' ', NULL);

select bit_length('mario');
select char_length('mario');

-- obter a idade das pessoas
-- na unha
select (primeiro_nome || ' ' || ultimo_nome) as nome_completo, 
		(now()::DATE - data_nascimento) /365 as idade 
	from aluno;
	
-- com funcao
select (primeiro_nome || ' ' || ultimo_nome) as nome_completo, 
		extract(year from age(data_nascimento)) as idade 
	from aluno;
	
select ceiling(100.99);
select pi();
select @ -143243;

select now()::time;
select to_char(now(), 'DD/MM/YYYY');
select to_char(now(), 'DD MONTH YYYY');
select to_char(128.3::real, '999D99');

-- consultar documentacao https://www.postgresql.org/docs/current/functions.html