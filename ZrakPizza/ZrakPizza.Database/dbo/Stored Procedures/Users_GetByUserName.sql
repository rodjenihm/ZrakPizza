CREATE PROCEDURE [dbo].[Users_GetByUserName]
	@UserName NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON

	SELECT
	u.[Id], u.[UserName], u.[Name], u.[PasswordHash]
	FROM [dbo].[Users] u
	WHERE [UserName] = @UserName
END