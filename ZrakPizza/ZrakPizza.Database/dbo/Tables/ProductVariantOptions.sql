CREATE TABLE [dbo].[ProductVariantOptions]
(
	[Id]							NVARCHAR(32)	NOT NULL,
	[ProductId]						NVARCHAR(32)	NOT NULL,
	[Description]					NVARCHAR(MAX)	NOT NULL,
	[Price]							MONEY			NOT NULL,
	CONSTRAINT [PK_ProductVariantOptions]				PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ProductVariantOptions_Products_Id] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
)
