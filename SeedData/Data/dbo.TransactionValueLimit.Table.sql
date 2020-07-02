USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[TransactionValueLimit] ON 

INSERT [dbo].[TransactionValueLimit] ([Id], [CreatedOn], [ModifiedOn], [Limit], [FinInstitutionInfoId], [TransactionTypeId], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (6, NULL, NULL, CAST(3000000.00 AS Decimal(18, 2)), 4, 3, 2, NULL, NULL)
INSERT [dbo].[TransactionValueLimit] ([Id], [CreatedOn], [ModifiedOn], [Limit], [FinInstitutionInfoId], [TransactionTypeId], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (7, NULL, NULL, CAST(500000.00 AS Decimal(18, 2)), 5, 3, 2, NULL, NULL)
INSERT [dbo].[TransactionValueLimit] ([Id], [CreatedOn], [ModifiedOn], [Limit], [FinInstitutionInfoId], [TransactionTypeId], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (14, NULL, NULL, CAST(500000.00 AS Decimal(18, 2)), 4, 1, 1, NULL, NULL)
INSERT [dbo].[TransactionValueLimit] ([Id], [CreatedOn], [ModifiedOn], [Limit], [FinInstitutionInfoId], [TransactionTypeId], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (30, NULL, NULL, CAST(250000.00 AS Decimal(18, 2)), 5, 1, 1, NULL, NULL)
INSERT [dbo].[TransactionValueLimit] ([Id], [CreatedOn], [ModifiedOn], [Limit], [FinInstitutionInfoId], [TransactionTypeId], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (36, NULL, NULL, CAST(600000.00 AS Decimal(18, 2)), 4, 2, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionValueLimit] OFF
