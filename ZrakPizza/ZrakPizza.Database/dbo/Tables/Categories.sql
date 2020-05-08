CREATE TABLE [dbo].[Categories]
(
	[Id]						NVARCHAR(32)	NOT NULL,
	[Name]						NVARCHAR(255)	NOT NULL
	CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
)
