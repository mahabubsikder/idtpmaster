USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[PaymentAuthorization] ON 

INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (1, NULL, CAST(N'2020-06-21T07:18:20.1166667' AS DateTime2), NULL, NULL, 1, 1, 5000, N'', 0, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (2, NULL, CAST(N'2020-06-21T07:18:20.1166667' AS DateTime2), NULL, NULL, 1, 2, 5000, N'', 0, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (3, NULL, CAST(N'2020-06-21T07:18:20.1166667' AS DateTime2), NULL, NULL, 1, 2, 5000, N'', 1, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (4, NULL, CAST(N'2020-06-21T07:18:20.1166667' AS DateTime2), NULL, CAST(N'2020-06-18T23:24:35.0427524' AS DateTime2), 1, 2, 5000, N'', 1, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (5, NULL, CAST(N'2020-06-21T07:18:20.1166667' AS DateTime2), NULL, CAST(N'2020-06-18T23:24:37.4898031' AS DateTime2), 1, 2, 5000, N'', 1, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (6, NULL, CAST(N'2020-06-22T18:14:18.5947904' AS DateTime2), NULL, CAST(N'2020-06-22T18:14:18.5948578' AS DateTime2), 1, 2, 5000, N'', 1, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (7, NULL, CAST(N'2020-06-24T15:35:37.9569998' AS DateTime2), NULL, CAST(N'2020-06-24T15:35:37.9570452' AS DateTime2), 1, 2, 5000, N'', 1, 1)
INSERT [dbo].[PaymentAuthorization] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderId], [ReceiverId], [Amount], [OtherInfo], [Status], [EntityState]) VALUES (8, NULL, CAST(N'2020-06-25T16:37:31.9946670' AS DateTime2), NULL, CAST(N'2020-06-25T16:37:31.9946797' AS DateTime2), 1, 2, 5000, N'', 1, 1)
SET IDENTITY_INSERT [dbo].[PaymentAuthorization] OFF
