USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[TransactionStatus] ON 

INSERT [dbo].[TransactionStatus] ([Id], [TransactionStatusName], [Description], [EntityState]) VALUES (1, N'Success', N'Transaction Status for Successful Transaction', 1)
INSERT [dbo].[TransactionStatus] ([Id], [TransactionStatusName], [Description], [EntityState]) VALUES (2, N'Failed', N'Transaction Status for Failed Transaction', 1)
SET IDENTITY_INSERT [dbo].[TransactionStatus] OFF
