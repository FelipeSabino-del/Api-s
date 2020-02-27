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
VALUES ('Drama'),('A��o');

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('A vida � bela',1),('Rambo',2)

SELECT * FROM Genero;
SELECT * FROM Filmes;

SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE IdFilme = 1;

SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE Titulo LIKE '%a%' ORDER BY Titulo DESC;




