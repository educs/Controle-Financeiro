select * from dinheiro

insert into contas
values (1, '', 

insert into bens 
values (3, 0)

insert into dinheiro
values (1, 'Banco')

insert into carro
values (2, 'dwt3002', 'celta spirit 1.0')

insert into casa
values (3, 'Home', 0) 

select b.codigo, d.descricao from bens b
join dinheiro d
on b.codigo=d.codigo
union
select codigo, modelo from carro c
--JOIN bens b
--on b.codigo=c.codigo
union
select codigo, descricao from  casa ca
order by descricao

insert into contas 
values ('salário', 0, 1)

delete from contas

select * from contas