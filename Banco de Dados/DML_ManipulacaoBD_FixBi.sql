INSERT INTO USUARIOS VALUES ('Mecânico', 'daniel@fixbi.com', '12345')
,('Ciclista', 'mariana@fixbi.com',	'12346')
,('Ciclista', 'suely@fixbi.com',	'12347')
,('Ciclista', 'correia@fixbi.com','12348')

SELECT * FROM USUARIOS

INSERT INTO MECANICOS VALUES (1,'Daniel Roncaglia',	'(11)9999-1000','Especialista em câmbios')

SELECT * FROM MECANICOS

SET IDENTITY_INSERT CICLISTAS ON 

INSERT INTO CICLISTAS (ID_CICLISTA,ID_USUARIO,NOME_CICLISTA,TELEFONE_CICLISTA,INFORMACOES_CICLISTA) VALUES 
(1,2, 'Mariana Roncaglia','(11)9999-9999','Tem uma bicicleta cagueira')
,(2, 3, 'Suely Roncaglia','(11)9999-1001','É ciclista iniciante')
,(3, 4, 'José Correia','(11)9999-1002','Possui uma MTB')

SELECT * FROM CICLISTAS

INSERT INTO ATENDIMENTOS VALUES 
(2,	3,'2019-06-26T15:00:00','Pneu furado','Realizada')
,(3,3,'2019-06-27T16:00:00','Regulagem de freio',	'Agendada')
,(1,3,'2019-06-28T17:00:00','Troca de câmbio','Cancelada')

SELECT * FROM ATENDIMENTOS