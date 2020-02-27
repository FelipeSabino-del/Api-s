-- Cria o banco de dados Filmes
CREATE DATABASE Filmes_Tarde;
GO

-- Define o banco de dados que será utilizado
USE Filmes_Tarde;
GO

-- Cria a tabela Generos
CREATE TABLE Genero(
	IdGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (255) NOT NULL UNIQUE
);
GO

-- Cria a tabela Filmes
CREATE TABLE Filmes(
	IdFilme		INT PRIMARY KEY IDENTITY
	,Titulo		VARCHAR (255) NOT NULL UNIQUE
	,IdGenero	INT FOREIGN KEY REFERENCES Genero (IdGenero)
);
GO

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Senha VARCHAR (255) NOT NULL,
	Permissao VARCHAR (255) NOT NULL
);

INSERT INTO Genero (Nome)
VALUES ('Drama'),('Ação');

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('A vida é bela',1),('Rambo',2);

INSERT INTO Usuarios (Email, Senha, Permissao)
VALUES ('felipe@email.com','123','comum'), ('adm@email.com','adm123','administrador');

TRUNCATE TABLE Usuarios;

SELECT * FROM Genero;
SELECT * FROM Filmes;
SELECT * FROM Usuarios;

SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE IdFilme = 1;

SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE Titulo LIKE '%a%' ORDER BY Titulo DESC;

SELECT IdUsuario, Email, Senha, Permissao FROM Usuarios WHERE Email = @Email AND Senha = @Senha;





