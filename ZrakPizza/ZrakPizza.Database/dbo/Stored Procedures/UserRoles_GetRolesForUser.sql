CREATE PROCEDURE [dbo].[UserRoles_GetRolesForUser]
	@UserId NVARCHAR(32)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
	r.[Id], r.[Name]
	FROM [dbo].[UserRoles] u
	INNER JOIN [dbo].[Roles] r ON r.Id = u.RoleId 
	WHERE [UserId] = @UserId
END