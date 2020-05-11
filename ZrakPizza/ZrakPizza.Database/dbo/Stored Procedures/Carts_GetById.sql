CREATE PROCEDURE [dbo].[Carts_GetById]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
	c.[Id], c.[ItemsCount], c.[ItemsTotalPrice]
	FROM [dbo].[Carts] c
	WHERE [Id] = @Id
END