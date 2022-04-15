CREATE DATABASE Cinema
USE  Cinema

CREATE TABLE Films
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
ReleaseDate DATE NOT NULL,
)
 
CREATE TABLE Actors
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Surname NVARCHAR(50) NOT NULL,
Age INT CHECK(Age>0 AND Age<166) NOT NULL
)

CREATE TABLE Genres
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE ActorsOfFilm
(
Id INT IDENTITY PRIMARY KEY,
FilmId INT REFERENCES Films(Id) NOT NULL,
ActorId INT REFERENCES Actors(Id) NOT NULL
)

CREATE TABLE GenresOfFilm
(
Id INT IDENTITY PRIMARY KEY,
FilmId INT REFERENCES Films(Id)NOT NULL,
GenreId INT REFERENCES Genres(Id)NOT NULL
)

CREATE TABLE Customers
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50)NOT NULL,
Surname NVARCHAR(50)NOT NULL,
Age INT CHECK(Age>0)NOT NULL
)

CREATE TABLE Halls
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
SeatCount INT CHECK(SeatCount>0) NOT NULL
)

CREATE TABLE Seances
(
	Id INT IDENTITY PRIMARY KEY,
	StartTime TIME NOT NULL
)

CREATE TABLE Tickets
(
Id INT IDENTITY (1,1) PRIMARY KEY,
SoldDate DATETIME DEFAULT GETDATE(),
Price money not null,
Seat int not null,
SeanceId int references Seances(Id) not null,
HallId int references Halls(Id) not null,
CustomerId int references Customers(Id) not null,
FilmId int references Films(Id) not null
) 



INSERT INTO Films VALUES ('{name}',GETDATE())

SELECT name FROM sys.databases;

--islemir
--CREATE PROCEDURE TrancateAll
--as
--begin
--TRUNCATE TABLE Tickets
--TRUNCATE TABLE Seances
--TRUNCATE TABLE Halls
--TRUNCATE TABLE Customers
--TRUNCATE TABLE GenresOfFilm
--TRUNCATE TABLE ActorsOfFilm
--TRUNCATE TABLE Genres
--TRUNCATE TABLE Actors
--TRUNCATE TABLE Films
--end


--exec TrancateAll