USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[Disbursements] ON 

INSERT [dbo].[Disbursements] ([Id], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SenderVID], [Amount], [ReferenceNo], [DeviceLocationInfoId], [EntityState], [Criteria]) VALUES (28, NULL, CAST(N'2020-06-28T15:06:35.9459998' AS DateTime2), NULL, NULL, N'MDMRVID', 500, N'ASDF45567', 81, 1, N'Salary')
SET IDENTITY_INSERT [dbo].[Disbursements] OFF
