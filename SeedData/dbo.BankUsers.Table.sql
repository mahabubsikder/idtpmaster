USE [IDTP_3]
GO
DELETE FROM TransactionFund
DBCC CHECKIDENT ('IDTP_3.dbo.TransactionFund',RESEED, 0)
DELETE FROM TransactionBill
DBCC CHECKIDENT ('IDTP_3.dbo.TransactionBill',RESEED, 0)
DELETE FROM BankUsers
DBCC CHECKIDENT ('IDTP_3.dbo.TransactionFund',RESEED, 0)

INSERT [dbo].[BankUsers] ([Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo]) VALUES (NULL, NULL, NULL, NULL, NULL, 0, N'11223344', N'Demo User', CAST(35750.00 AS Decimal(18, 2)), 2, N'01723753955')
INSERT [dbo].[BankUsers] ([Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [AccountNumber], [AccountName], [Balance], [EntityState], [ContactNo]) VALUES (NULL, NULL, NULL, NULL, NULL, 0, N'44332211', N'Saif Kamal', CAST(74000.00 AS Decimal(18, 2)), 2, N'01723753954')
