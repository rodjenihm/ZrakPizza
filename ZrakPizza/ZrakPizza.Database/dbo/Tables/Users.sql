CREATE TABLE [dbo].[Users]
(
	[Id]					NVARCHAR(32)	NOT NULL,
	[UserName]				NVARCHAR(255)	NOT NULL,
	[Name]					NVARCHAR(255)			,
	[PasswordHash]			NVARCHAR(48)	NOT NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
)

GO

CREATE UNIQUE INDEX [IX_Users_UserName] ON [dbo].[Users] ([UserName])
