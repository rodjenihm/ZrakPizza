CREATE PROCEDURE [dbo].[Products_GetAll]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
    p.*, c.Name as Category
    FROM [dbo].[Products] p
    INNER JOIN [dbo].[ProductCategories] pc ON pc.ProductId = p.Id
    INNER JOIN [dbo].[Categories] c ON c.Id = pc.CategoryId
END