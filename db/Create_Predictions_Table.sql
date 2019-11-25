IF OBJECT_ID('dbo.Predictions', 'U') IS NOT NULL
DROP TABLE dbo.Predictions
GO

CREATE TABLE dbo.Predictions
(
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  Prediction VARCHAR(50) NOT NULL,
  Difficulty tinyint NOT NULL,
  ImageUri VARCHAR(250) NOT NULL,
  CreatedBy VARCHAR(50) NOT NULL,
  fk_BoardId int FOREIGN KEY REFERENCES Boards(Id),
  fk_CardId int FOREIGN KEY REFERENCES Cards(Id)
);
GO
