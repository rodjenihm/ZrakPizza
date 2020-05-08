CREATE TABLE [dbo].[UserRoles]
(
	[UserId] NVARCHAR(32) NOT NULL,
	[RoleId] NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Users_Id] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_UserRoles_Roles_Id] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
)
