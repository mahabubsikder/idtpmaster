USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[IDTPPermission] ON 

INSERT [dbo].[IDTPPermission] ([Id], [PermissionName], [Description], [EntityState]) VALUES (1, N'Can-Send-Money', N'This permission allows to Send Money', 1)
INSERT [dbo].[IDTPPermission] ([Id], [PermissionName], [Description], [EntityState]) VALUES (3, N'Can-login', N'This is a login permission', 1)
SET IDENTITY_INSERT [dbo].[IDTPPermission] OFF
