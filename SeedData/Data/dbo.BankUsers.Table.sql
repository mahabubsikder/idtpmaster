USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[BankUsers] ON 

INSERT [dbo].[BankUsers] ([Id], [CreatedOn], [ModifiedOn], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo], [CreatedBy], [ModifiedBy]) VALUES (1, NULL, NULL, N'11223344', N'Fahmid Ahmed', CAST(40050.00 AS Decimal(18, 2)), 2, N'01723753955', NULL, NULL)
INSERT [dbo].[BankUsers] ([Id], [CreatedOn], [ModifiedOn], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo], [CreatedBy], [ModifiedBy]) VALUES (2, NULL, NULL, N'44332211', N'Saif Kamal', CAST(57000.00 AS Decimal(18, 2)), 2, N'01723753954', NULL, NULL)
INSERT [dbo].[BankUsers] ([Id], [CreatedOn], [ModifiedOn], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo], [CreatedBy], [ModifiedBy]) VALUES (3, NULL, NULL, N'55556666', N'Nazifa Tasnim', CAST(50000.00 AS Decimal(18, 2)), 2, N'01723753953', NULL, NULL)
INSERT [dbo].[BankUsers] ([Id], [CreatedOn], [ModifiedOn], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo], [CreatedBy], [ModifiedBy]) VALUES (4, NULL, NULL, N'333555', N'DESCO-USER', CAST(50000.00 AS Decimal(18, 2)), 1, N'01787654321', NULL, NULL)
SET IDENTITY_INSERT [dbo].[BankUsers] OFF
