USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[TransactionType] ON 

INSERT [dbo].[TransactionType] ([Id], [TransactionTypeName], [Description], [EntityState]) VALUES (1, N'Send Money', N'This type of transaction defines sending money from one of our internal user to another internal user.', 1)
INSERT [dbo].[TransactionType] ([Id], [TransactionTypeName], [Description], [EntityState]) VALUES (2, N'Bill Payment', N'This type of transaction defines Paying to any external entity of our system such as DESCO.', 1)
INSERT [dbo].[TransactionType] ([Id], [TransactionTypeName], [Description], [EntityState]) VALUES (3, N'Fund Transfer', N'This type of transaction defines Fund Transfer between users of different banks', 1)
SET IDENTITY_INSERT [dbo].[TransactionType] OFF
