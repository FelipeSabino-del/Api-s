CREATE DATABASE Filmes_Tarde

USE Filmes_Tarde

CREATE TABLE Genero (
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (255)
);

CREATE TABLE Filmes (
	IdFilme INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255),
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero)
);

INSERT INTO Genero (Nome)
VALUES ('Drama'),('Ação');

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('A vida é bela',1),('Rambo',2)

SELECT * FROM Genero;
SELECT * FROM Filmes;
