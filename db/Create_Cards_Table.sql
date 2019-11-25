IF OBJECT_ID('dbo.Cards', 'U') IS NOT NULL
DROP TABLE dbo.Cards
GO

CREATE TABLE dbo.Cards
(
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  Difficulty DEC(4,3) NOT NULL,
  GeneratedBy varchar(50) NULL,
  fk_BoardId int FOREIGN KEY REFERENCES Boards(Id)
);
GO
