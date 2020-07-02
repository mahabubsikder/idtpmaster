USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[PayeeDetails] ON 

INSERT [dbo].[PayeeDetails] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [VID], [Name], [Basic], [TotalAllowance], [TotalDeductions], [EntityState]) VALUES (1, NULL, NULL, NULL, NULL, N'SampleReceiverVID1', N'Receiver 1', 30000, 25000, 5000, 1)
INSERT [dbo].[PayeeDetails] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [VID], [Name], [Basic], [TotalAllowance], [TotalDeductions], [EntityState]) VALUES (2, NULL, NULL, NULL, NULL, N'SampleReceiverVID2', N'Receiver 2', 35000, 25000, 10000, 1)
INSERT [dbo].[PayeeDetails] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [VID], [Name], [Basic], [TotalAllowance], [TotalDeductions], [EntityState]) VALUES (3, NULL, NULL, NULL, NULL, N'SampleReceiverVID3', N'Receiver 3', 50000, 25000, 5000, 1)
INSERT [dbo].[PayeeDetails] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [VID], [Name], [Basic], [TotalAllowance], [TotalDeductions], [EntityState]) VALUES (4, NULL, NULL, NULL, NULL, N'SampleReceiverVID4', N'Receiver 4', 20000, 15000, 5000, 1)
INSERT [dbo].[PayeeDetails] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [VID], [Name], [Basic], [TotalAllowance], [TotalDeductions], [EntityState]) VALUES (5, NULL, NULL, NULL, NULL, N'SampleReceiverVID5', N'Receiver 5', 80000, 70000, 50000, 1)
SET IDENTITY_INSERT [dbo].[PayeeDetails] OFF
