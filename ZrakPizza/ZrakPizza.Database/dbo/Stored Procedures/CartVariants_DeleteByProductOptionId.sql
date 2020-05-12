CREATE PROCEDURE [dbo].[CartVariants_DeleteByProductOptionId]
	@CartId NVARCHAR(32),
	@ProductOptionId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	IF EXISTS (SELECT [CartId], [ProductOptionId] FROM [dbo].[CartVariants] WHERE [CartId] = @CartId AND [ProductOptionId] = @ProductOptionId)
	BEGIN
		DELETE TOP(1) FROM [dbo].[CartVariants]
		WHERE [CartId] = @CartId AND [ProductOptionId] = @ProductOptionId;

		DECLARE @ItemPrice MONEY;

		SET @ItemPrice = (SELECT [Price] FROM [dbo].[ProductOptions] WHERE [Id] = @ProductOptionId)

		UPDATE [dbo].[Carts]
		SET [ItemsCount] = [ItemsCount] - 1,
			[ItemsTotalPrice] = [ItemsTotalPrice] - @ItemPrice
		WHERE [Id] = @CartId
	END
	ELSE
		PRINT 'No such product in given cart'
END
