CREATE DATABASE bdGamePlatform
GO
USE bdGamePlatform

CREATE TABLE tbPlayer (
	id int primary key identity(1,1),
	usuario varchar(50) not null,
	senha varchar(50) not null,
	email varchar(100) not null,
	vitorias int not null,
	derrotas int not null,
)

SELECT * FROM tbPlayer

SELECT * FROM tbPlayer 
	where email = 'deru@gmail.com'