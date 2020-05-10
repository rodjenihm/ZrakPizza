CREATE TABLE [dbo].[ProductOptions]
(
	[Id]							NVARCHAR(32)	NOT NULL,
	[ProductId]						NVARCHAR(32)	NOT NULL,
	[Description]					NVARCHAR(MAX)	NOT NULL,
	[Price]							MONEY			NOT NULL,
	CONSTRAINT [PK_ProductOptions]				PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ProductOptions_Products_Id] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
)
