-- Add a new column 'NewColumnName' to table 'TableName' in schema 'SchemaName'
IF OBJECT_ID('dbo.Predictions', 'U') IS NOT NULL
DROP TABLE dbo.Predictions
GO

CREATE TABLE dbo.Predictions
(
  Id INT NOT NULL IDENTITY PRIMARY KEY,
  Prediction VARCHAR(50) NOT NULL,
  Difficulty NUMERIC(4,3) NOT NULL,
  ImageUri VARCHAR(250) NOT NULL,
  CreatedBy VARCHAR(50) NOT NULL
);
GO
