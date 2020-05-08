CREATE TABLE [dbo].[Carts]
(
	[Id]					NVARCHAR(32)		NOT NULL,
	[ItemsCount]			INT					NOT NULL DEFAULT 0,
	[ItemsTotalPrice]		MONEY				NOT NULL DEFAULT 0
	CONSTRAINT [PK_Carts] PRIMARY KEY ([Id])
)
