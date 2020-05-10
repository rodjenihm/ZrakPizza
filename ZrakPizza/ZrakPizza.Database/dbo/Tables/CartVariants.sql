CREATE TABLE [dbo].[CartVariants]
(
	[Id]						NVARCHAR(32)		NOT NULL,
	[CartId]					NVARCHAR(32)		NOT NULL,
	[ProductOptionId]			NVARCHAR(32)		NOT NULL,
	CONSTRAINT [PK_CartVariants]							PRIMARY KEY ([Id]),
	CONSTRAINT [FK_CartVariants_Carts_Id]					FOREIGN KEY ([CartId])					REFERENCES [dbo].[Carts] ([Id])				ON DELETE CASCADE,
	CONSTRAINT [FK_CartVariants_ProductOptions_Id]			FOREIGN KEY ([ProductOptionId])			REFERENCES [dbo].[ProductOptions] ([Id])	ON DELETE CASCADE
)
