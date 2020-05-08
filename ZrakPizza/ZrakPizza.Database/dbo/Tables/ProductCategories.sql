CREATE TABLE [dbo].[ProductCategories]
(
	[ProductId]							NVARCHAR(32) NOT NULL,
	[CategoryId]						NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([ProductId], [CategoryId]),
	CONSTRAINT [FK_ProductCategories_Products_Id] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_ProductCategories_Categories_Id] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE CASCADE
)
