USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[IdentityType] ON 

INSERT [dbo].[IdentityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (2, NULL, NULL, N'NID', 1, NULL, NULL)
INSERT [dbo].[IdentityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (3, NULL, NULL, N'TIN', 1, NULL, NULL)
INSERT [dbo].[IdentityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (4, NULL, NULL, N'BIN', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[IdentityType] OFF
