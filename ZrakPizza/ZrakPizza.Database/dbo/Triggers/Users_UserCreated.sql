CREATE TRIGGER Users_UserCreated ON [dbo].[Users]
FOR INSERT 
AS
BEGIN
	
	DECLARE @memberId NVARCHAR(32) = (
		SELECT [Id] FROM [dbo].[Roles] WHERE [Name] = 'member'
	)

	INSERT INTO [dbo].[UserRoles]
	([UserId], [RoleId])
	SELECT Id , @memberId
	FROM INSERTED
END