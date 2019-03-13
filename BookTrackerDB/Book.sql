CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR (50) NOT NULL,
	[AuthorID] INT NOT NULL,
	[Description] NVARCHAR (200),
	[PublishingDate] DATETIME, 
    [IsRead] BIT NOT NULL DEFAULT 0, 
	CONSTRAINT [FK_dbo.Book_dbo.Author_AuthorID] FOREIGN KEY ([AuthorID])
		REFERENCES [dbo].[Author] ([Id]),
)
