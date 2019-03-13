CREATE TABLE [dbo].[Rating]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Rate] TINYINT NOT NULL CHECK (Rate > 0 AND RATE < 11),
	[BookID] INT NOT NULL,
	CONSTRAINT [FK_dbo.Rating_dbo.Book_Id] FOREIGN KEY ([BookID])
		REFERENCES [dbo].[Book] ([Id]) 
)
