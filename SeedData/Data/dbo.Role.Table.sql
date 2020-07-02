USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName], [Description], [EntityState]) VALUES (1, N'User-Role', N'Role for user', 1)
INSERT [dbo].[Role] ([Id], [RoleName], [Description], [EntityState]) VALUES (2, N'Admin-Role', N'Role for Admin', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
