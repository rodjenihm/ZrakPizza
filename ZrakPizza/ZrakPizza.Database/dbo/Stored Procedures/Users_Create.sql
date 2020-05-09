CREATE PROCEDURE [dbo].[Users_Create]
	@Id NVARCHAR(32),
	@UserName NVARCHAR(255),
	@Name NVARCHAR(255),
	@PasswordHash NVARCHAR(48)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Users]
	([Id], [UserName], [Name], [PasswordHash])
	VALUES
	(@Id, @UserName, @Name, @PasswordHash)
END
