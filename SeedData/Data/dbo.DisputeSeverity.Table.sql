USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[DisputeSeverity] ON 

INSERT [dbo].[DisputeSeverity] ([Id], [Name], [Description], [EntityState]) VALUES (1, N'High', NULL, 1)
INSERT [dbo].[DisputeSeverity] ([Id], [Name], [Description], [EntityState]) VALUES (2, N'Medium', NULL, 1)
INSERT [dbo].[DisputeSeverity] ([Id], [Name], [Description], [EntityState]) VALUES (3, N'Low', NULL, 1)
SET IDENTITY_INSERT [dbo].[DisputeSeverity] OFF
