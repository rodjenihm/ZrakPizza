CREATE PROCEDURE [dbo].[Products_GetAllWithVariants]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
    p.*, c.Name as Category, pv.*
    FROM [dbo].[Products] p
    INNER JOIN [dbo].[ProductCategories] pc ON pc.ProductId = p.Id
    INNER JOIN [dbo].[Categories] c ON c.Id = pc.CategoryId
    INNER JOIN [dbo].[ProductVariantOptions] pv ON pv.ProductId = p.Id
END