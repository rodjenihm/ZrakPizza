CREATE TABLE [dbo].[Products]
(
	[Id]						NVARCHAR(32)	NOT NULL,
	[Name]						NVARCHAR(MAX)	NOT NULL,
	[Description]				NVARCHAR(MAX)	NOT NULL,
	[ImageUrl]					NVARCHAR(MAX)	NOT NULL,
	CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
)
