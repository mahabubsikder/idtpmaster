USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [AccountNumber], [ContactNumber], [TotalPaidAmount], [TotalDueAmount], [EntityState]) VALUES (1, N'Fahmid Ahmed', N'11223344', N'01723753955', CAST(10461.00 AS Decimal(18, 2)), CAST(39.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Customer] ([Id], [Name], [AccountNumber], [ContactNumber], [TotalPaidAmount], [TotalDueAmount], [EntityState]) VALUES (2, N'Saif Kamal', N'44332211', N'01723753954', CAST(4345.00 AS Decimal(18, 2)), CAST(6155.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Customer] OFF
