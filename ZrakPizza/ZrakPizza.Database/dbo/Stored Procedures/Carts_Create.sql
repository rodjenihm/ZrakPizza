CREATE PROCEDURE [dbo].[Carts_Create]
	@Id NVARCHAR(32),
	@ItemsCount INT,
	@ItemsTotalPrice MONEY
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Carts]
	([Id], [ItemsCount], [ItemsTotalPrice])
	VALUES
	(@Id, @ItemsCount, @ItemsTotalPrice)
END
