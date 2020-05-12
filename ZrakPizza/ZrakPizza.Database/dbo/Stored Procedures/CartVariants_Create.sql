CREATE PROCEDURE [dbo].[CartVariants_Create]
	@Id NVARCHAR(32),
	@CartId NVARCHAR(32),
	@ProductOptionId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[CartVariants]
	([Id], [CartId], [ProductOptionId])
	VALUES
	(@Id, @CartId, @ProductOptionId)

	DECLARE @ItemPrice MONEY;

	SET @ItemPrice = (SELECT [Price] FROM [dbo].[ProductOptions] WHERE [Id] = @ProductOptionId)

	UPDATE [dbo].[Carts]
	SET [ItemsCount] = [ItemsCount] + 1,
		[ItemsTotalPrice] = [ItemsTotalPrice] + @ItemPrice
	WHERE [Id] = @CartId
END
