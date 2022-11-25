integer
real
serial
numeric

varchar(n)
char(n)
text

boolean

date
time
timestamp 

CREATE TABLE aluno (
	id serial,
	nome varchar(255),
	cpf char(11),
	observacao text,
	idade integer,
	dinheiro numeric(10,2),
	altura real,
	ativo boolean,
	data_nascimento date,
	hora_aula time,
	matriculado_em timestamp
);

select * from aluno;

insert into aluno(
	nome, 
	cpf, 
	observacao,
	idade,
	dinheiro,
	altura,
	ativo,
	data_nascimento,
	hora_aula,
	matriculado_em
) 
values(
	'Mario', 
	'11111111111', 
	'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sed maximus nulla. Etiam venenatis velit sagittis magna laoreet dapibus. Morbi vel magna eget mi faucibus vulputate in ac est. In id dolor vitae nulla feugiat tempor. Nam aliquam rutrum imperdiet. Mauris diam dui, hendrerit sit amet leo eu, mollis lacinia diam. Nam vulputate ligula elementum faucibus mattis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum vitae nisl sem. Aenean odio diam, mattis non venenatis a, venenatis eu ante. Nullam consectetur ut metus a hendrerit. Morbi dapibus nunc at arcu imperdiet, sed rutrum est eleifend. Mauris sem erat, sollicitudin sit amet luctus eget, tristique ut mauris.',
	37,
	100.99,
	1.87,
	true,
	'1985-11-13',
	'17:30:00',
	'2022-11-14 11:03:30'
);

 select * 
	from aluno 
   where id = 1;
   
 update aluno 
	set nome = 'Nico', 
	cpf = '22222222222', 
	observacao = 'teste',
	idade = 38,
	dinheiro = 15.23,
	altura = 1.92,
	ativo = false,
	data_nascimento = '1980-01-15',
	hora_aula = '13:15:00',
	matriculado_em = '2022-10-30 15:05:00'
   where id = 1;
   
 select * 
	from aluno
   where nome = 'Nico';

 delete
	from aluno
   where nome = 'Nico';

 select * 
 	from aluno;
	
 select nome,
 		idade,
		matriculado_em
 	from aluno;
	
 select nome as "Nome do aluno",
 		idade,
		matriculado_em as quando_se_matriculou
 	from aluno;
	
select *
	from aluno;
	
insert into aluno (nome) values ('Vinicius Dias');
insert into aluno (nome) values ('Nico Steppat');
insert into aluno (nome) values ('João Roberto');
insert into aluno (nome) values ('Diego');

select *
	from aluno
   where nome <> 'Mario';
   
 select *
	from aluno
   where nome like '_ario';
   
 select *
	from aluno
   where nome like '% %';
   
 select *
	from aluno
   where nome like '%i%a%';
   
 select *
	from aluno
   where cpf is not null;
   
 select *
	from aluno
   where idade <= 37;
  
 select *
	from aluno
   where idade between 10 and 40;
   
select * from aluno where ativo = true;

select * from aluno where ativo is null;

 select *
	from aluno
   where nome like 'D%' and cpf is not null;
   
 select *
	from aluno
   where nome like 'Diego' 
   or nome like 'Mario'
   or nome like 'Nico%';
   
 select *
	from aluno
   where nome like '%%Steppat' 
   and nome like 'Nico%';
   
create table curso (
	id integer,
	nome varchar(255)
);

drop table curso;
create table curso (
	id integer not null unique,
	nome varchar(255) not null
);

create table curso (
	id integer not null primary key,
	nome varchar(255) not null
);

insert into curso (id, nome) values (null, null);
insert into curso (id, nome) values (1, null);
insert into curso (id, nome) values (null, 'HTML');

insert into curso (id, nome) values (1, 'HTML');
insert into curso (id, nome) values (2, 'Javascript');

select * from curso;
select * from aluno;

drop table aluno;

create table aluno(
	id serial primary key,
	nome varchar(255) not null
);

insert into aluno (nome) values ('Mario');
insert into aluno (nome) values ('Vinicius');

drop table aluno_curso;
select * from aluno_curso;
create table aluno_curso (
	aluno_id integer,
	curso_id integer,
	primary key (aluno_id, curso_id),
	
	foreign key (aluno_id)
	 references aluno (id),
	
	foreign key (curso_id)
	 references curso (id)
);

insert into aluno_curso(aluno_id, curso_id) values (1,1);
insert into aluno_curso(aluno_id, curso_id) values (2,1);
insert into aluno_curso(aluno_id, curso_id) values (3,1);

select * from aluno where id = 1;
select * from curso where id = 1;

select * from aluno where id = 2;
select * from curso where id = 2;

select * from aluno;
select * from curso;

select *
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
	join curso       on curso.id             = aluno_curso.curso_id;
	
select aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
	join curso       on curso.id             = aluno_curso.curso_id;

insert into aluno_curso (aluno_id, curso_id) values (2,2);

insert into aluno (nome) values ('Nico');
insert into curso (id, nome) values (3, 'css');


select aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	 from aluno
left join aluno_curso on aluno_curso.aluno_id = aluno.id
left join curso       on curso.id             = aluno_curso.curso_id;

select aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	  from aluno
right join aluno_curso on aluno_curso.aluno_id = aluno.id
right join curso       on curso.id             = aluno_curso.curso_id;

select aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	 from aluno
full join aluno_curso on aluno_curso.aluno_id = aluno.id
full join curso       on curso.id             = aluno_curso.curso_id;

select aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	  from aluno
cross join curso;

insert into aluno (nome) values ('João');

select * from aluno;
select * from curso;
select * from aluno_curso;

delete from aluno where id = 1;

drop table aluno_curso;
select * from aluno_curso;
create table aluno_curso (
	aluno_id integer,
	curso_id integer,
	primary key (aluno_id, curso_id),
	
	foreign key (aluno_id)
	 references aluno (id)
	on delete cascade
	on update cascade,
	
	foreign key (curso_id)
	 references curso (id)
);

insert into aluno_curso(aluno_id, curso_id) values (1,1);
insert into aluno_curso(aluno_id, curso_id) values (2,1);
insert into aluno_curso(aluno_id, curso_id) values (3,1);
insert into aluno_curso(aluno_id, curso_id) values (1,3);

update aluno
	set id = 10
	where id = 2;
	
insert into aluno (nome) values ('José');

update aluno
	set id = 10
	where id = 4;
	
select curso.id as "curso id",
	   aluno.id as "aluno id",
	   aluno.nome as "Nome do aluno",
	   curso.nome as "Curso matriculado"
	from aluno
	join aluno_curso on aluno_curso.aluno_id = aluno.id
	join curso       on curso.id             = aluno_curso.curso_id;
	
update aluno
	set id = 20
	where id = 2;
	
select * from aluno_curso;

create table funcionarios (
	id			serial		primary key,
	matricula	varchar(255),
	nome		varchar(255),
	sobrenome	varchar(255)
);

insert into funcionarios (matricula, nome, sobrenome) values ('M001', 'Diogo', 'Mascarenhas');
insert into funcionarios (matricula, nome, sobrenome) values ('M002', 'Vinicius', 'Dias');
insert into funcionarios (matricula, nome, sobrenome) values ('M003', 'Nico', 'Steppat');
insert into funcionarios (matricula, nome, sobrenome) values ('M004', 'Joao', 'Roberto');
insert into funcionarios (matricula, nome, sobrenome) values ('M005', 'Diogo', 'Mascarenhas');
insert into funcionarios (matricula, nome, sobrenome) values ('M006', 'Alberto', 'Martins');
insert into funcionarios (matricula, nome, sobrenome) values ('M007', 'Diogo', 'Oliveira');


select * 
	from funcionarios
	order by nome;
	
select * 
	from funcionarios
	order by nome desc;
	
select * 
	from funcionarios
	order by nome, matricula;
	
select * 
	from funcionarios
	order by 3, 4, 2;
	
select * 
	from funcionarios
	order by 4 desc, funcionarios.nome desc, 2 asc;
	
select * 
	from funcionarios
	order by nome
   limit 5;
   
select * 
   from funcionarios
	order by id
   limit 5
offset 5;

select * from funcionarios

select count (id)
	from funcionarios;
	
select count (id),
	sum (id),
	max (id),
	min (id),
	round (avg (id), 2)
	from funcionarios;

select 
		nome,
		sobrenome,
		count (id)
	from funcionarios
	group by nome, sobrenome
	order by nome;
	
select distinct
		nome,
		sobrenome
	from funcionarios

select curso.nome,
	count (aluno.id)
	from aluno
	join aluno_curso on aluno.id = aluno_curso.aluno_id
	join curso on curso.id = aluno_curso.curso_id
group by 1
order by 1

select * from aluno
select * from curso
select * from aluno_curso
insert into aluno (nome) values ('Nico')
insert into curso (id, nome) values (3, 'css')

insert into aluno_curso (aluno_id, curso_id) values (3,3)

--having deve ser usado com as funcoes, where com os campos / itens
select curso.nome,
		count(aluno.id)
	from curso
	left join aluno_curso on aluno_curso.curso_id = curso.id
	left join aluno on aluno.id = aluno_curso.aluno_id
	--where curso.nome = 'Javascript'
group by 1
	having count(aluno.id) =0
	
select nome,
	count(id)
	from funcionarios
	group by nome
	having count(id) > 1