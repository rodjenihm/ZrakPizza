CREATE PROCEDURE [dbo].[CartVariants_DeleteAll]
	@CartId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	
	DELETE FROM [dbo].[CartVariants]
	WHERE [CartId] = @CartId

	UPDATE [dbo].[Carts]
	SET [ItemsCount] = 0,
		[ItemsTotalPrice] = 0
	WHERE [Id] = @CartId
END
