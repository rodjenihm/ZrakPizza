CREATE TABLE [dbo].[ProductVariants]
(
	[Id]							NVARCHAR(32)	NOT NULL,
	[ProductId]						NVARCHAR(32)	NOT NULL,
	[Description]					NVARCHAR(MAX)	NOT NULL,
	[Price]							MONEY			NOT NULL,
	CONSTRAINT [PK_ProductVariants]				PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ProductVariants_Products_Id] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
)
