CREATE PROCEDURE [dbo].[Products_GetAllWithProductOptions]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
    p.*, c.Name as Category, po.*
    FROM [dbo].[Products] p
    INNER JOIN [dbo].[ProductCategories] pc ON pc.ProductId = p.Id
    INNER JOIN [dbo].[Categories] c ON c.Id = pc.CategoryId
    INNER JOIN [dbo].[ProductOptions] po ON po.ProductId = p.Id
END