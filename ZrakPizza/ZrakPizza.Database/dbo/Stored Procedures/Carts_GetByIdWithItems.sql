CREATE PROCEDURE [dbo].[Carts_GetByIdWithItems]
	@Id NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
	c.[Id], c.[ItemsCount], c.[ItemsTotalPrice],
	cv.[ProductOptionId] as Id,
	p.[Name], p.[Description], p.[ImageUrl],
	ca.[Name] as Category,
	po.[Description] as VariantDescription, po.[Price]
	FROM [dbo].[Carts] c
	LEFT JOIN [dbo].[CartVariants] cv ON cv.CartId = c.Id
	LEFT JOIN [dbo].[ProductOptions] po ON po.Id = cv.ProductOptionId
	LEFT JOIN [dbo].[Products] p ON p.Id = po.ProductId
	LEFT JOIN [dbo].[ProductCategories] pc ON pc.ProductId = p.Id
	LEFT JOIN [dbo].[Categories] ca ON ca.Id = pc.CategoryId
 	WHERE c.[Id] = @Id
END