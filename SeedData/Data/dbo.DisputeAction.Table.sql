USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[DisputeAction] ON 

INSERT [dbo].[DisputeAction] ([Id], [Name], [EntityState]) VALUES (1, N'Refund', 1)
INSERT [dbo].[DisputeAction] ([Id], [Name], [EntityState]) VALUES (2, N'Hold', 1)
INSERT [dbo].[DisputeAction] ([Id], [Name], [EntityState]) VALUES (3, N'Re-Settlement', 1)
SET IDENTITY_INSERT [dbo].[DisputeAction] OFF
