USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[BillCategory] ON 

INSERT [dbo].[BillCategory] ([Id], [CategoryName], [CategoryDescription], [EntityState]) VALUES (2, N'Electricity', NULL, 1)
INSERT [dbo].[BillCategory] ([Id], [CategoryName], [CategoryDescription], [EntityState]) VALUES (3, N'Gas', NULL, 1)
INSERT [dbo].[BillCategory] ([Id], [CategoryName], [CategoryDescription], [EntityState]) VALUES (4, N'Water', NULL, 1)
INSERT [dbo].[BillCategory] ([Id], [CategoryName], [CategoryDescription], [EntityState]) VALUES (5, N'Telephone', NULL, 1)
SET IDENTITY_INSERT [dbo].[BillCategory] OFF
