drop table if exists log_verificao_backup;
drop table if exists acao_no_sistema; 
drop table if exists  sistema;
drop table if exists  parametro;
drop table if exists usuario ;
drop table if exists  fabricante;

create table fabricante
(
  fab_num bigserial ,
  fab_name varchar(36) not null,
  fab_cnpj varchar(36),
  constraint fabricante_pkey primary key (fab_num)
);

insert into fabricante (fab_name, fab_cnpj) values ('E&L Produções de Software - Ltda','39.781.752/0001-72');
commit work;

create table usuario (
 usu_num bigserial,
 usu_nome varchar(50) not null,
 usu_login varchar(50) not null,
 usu_senha varchar(2048) not null,
 constraint usuario_pkey primary key ( usu_num )
 );

create table parametro(
  par_num bigserial,
  usu_num bigint not null, 
  par_local_backup varchar (1024) not null,
  par_local_move_backup varchar (1024) not null,
  par_manter_quantas_versoes bigint not null,
  par_extensao_backup varchar(5) not null,
  par_hora_de_verificacao time not null,
  par_modificacaoOuCriacao timestamp not null,  
  par_efetuar_verificacao boolean not null, 
  constraint parametros_pkey primary key (par_num),
  constraint fk_parametros_usuario foreign key (usu_num)
      references usuario(usu_num) 
      on update   restrict  on delete  restrict
 );
 
create table sistema
(
  sis_num bigserial,
  fab_num bigint not null,
  sis_nome varchar (50) not null, 
  constraint sistema_pkey primary key (sis_num),
  constraint fk_sistema_fabricante foreign key (fab_num)
      references fabricante (fab_num) 
      on update   restrict  on delete  restrict 

);
create table acao_no_sistema (
 acs_num bigserial,
 par_num bigint not null,
 sis_num bigint not null,
  constraint acao_no_sistema_pkey primary key ( acs_num),
 constraint fk_acao_no_sistema_parametro foreign key (par_num)
      references parametro(par_num) 
      on update   restrict  on delete  restrict,

 constraint fk_acao_no_sistema_sistema foreign key (sis_num)
      references sistema (sis_num) 
      on update   restrict  on delete  restrict
);
create table log_verificao_backup
(
  ver_num bigserial,
  sis_num bigint not null,
    constraint verificao_backup_pkey primary key (    ver_num  ),
  constraint fk_verificao_backup_sistema foreign key (sis_num)
      references sistema (sis_num)
      on update   restrict  on delete  restrict
);


insert into usuario ( usu_nome , usu_login, usu_senha  ) values ('patrik lima pereira', 'patrik','123456' ); 
insert into usuario ( usu_nome , usu_login, usu_senha  ) values ('francis lima pereira', 'patrik','123456' ); 
insert into usuario ( usu_nome , usu_login, usu_senha  ) values ('estelina lima de oliveira', 'patrik','123456' ); 
insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (1,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',4,'','04:05:06','2014-01-08 04:05:06',true);
insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (3,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',4,'','04:05:06','2015-01-08 04:05:06',true);
insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (2,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',4,'','04:05:06','2016-01-08 04:05:06',true);

insert into sistema (fab_num,  sis_nome ) values (1, 'protocolo') ;

insert into acao_no_sistema  (par_num,sis_num) values (1,1); 

insert into acao_no_sistema  (par_num,sis_num) values (2,1); 
insert into acao_no_sistema  (par_num,sis_num) values (3,1); 

commit work;

--outro insert

insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (3,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',6,'','04:15:06','2014-01-09 04:05:06',true);
insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (2,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',6,'','04:15:06','2015-01-09 04:05:06',true);
insert into parametro ( usu_num , par_local_backup,par_local_move_backup,par_manter_quantas_versoes , par_extensao_backup,  par_hora_de_verificacao,par_modificacaoOuCriacao, par_efetuar_verificacao ) 
values (1,'C:\Users\patrik\Documents\x','C:\Users\patrik\Documents\y',6,'','04:15:06','2016-01-09 04:05:06',true);

insert into sistema (fab_num,  sis_nome ) values (1, 'folha') ;

insert into acao_no_sistema  (par_num,sis_num) values (3,2); 

insert into acao_no_sistema  (par_num,sis_num) values (4,2); 
insert into acao_no_sistema  (par_num,sis_num) values (5,2); 

commit work;


/*

select p.*  from parametro p , sistema s, acao_no_sistema a
where  p.par_num = a.par_num
       and a.sis_num = s.sis_num
       and p.par_num = (select max (p.par_num) as "par_num"  from parametro p , sistema s, acao_no_sistema a
where  p.par_num = a.par_num
       and a.sis_num = s.sis_num);*/


