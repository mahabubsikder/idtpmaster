/****** Script for SelectTopNRows command from SSMS  ******/


USE [IDTP_3]
GO
Declare @db Varchar(100) = 'IDTP_3';
Declare @fin Varchar(100) = (Select CONCAT(@db,'.dbo.FinancialInstitution'));
Declare @branch Varchar(100) = (Select CONCAT(@db,'.dbo.Branches'));

Truncate Table ParticipantDebitCap;
Delete From Branches
DBCC CHECKIDENT (@branch,RESEED, 0)
Delete From SuspenseTransaction;
DELETE FROM Banks;
DELETE FROM FinancialInstitution
DBCC CHECKIDENT (@fin,RESEED, 0)

SET IDENTITY_INSERT [dbo].[FinancialInstitution] ON 
INSERT [dbo].[FinancialInstitution] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [LoginId], [InstitutionName], [TIN], [BIN], [Email], [ContactNo], [ContactPersonName], [ContactPersonDesignation], [ContactPersonOffice], [ContactPersonNID], [ContactPersonMobile], [ContactPersonEmail], [Password], [PasswordSalt], [EntityState]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 0, N'ebl123', N'Eastern Bank Ltd.', N'162537165', N'324576154761', N'ebl@gmail.com', N'01982765423', N'Arif Hasan', N'Manager', N'Central', N'231313', N'01716254234', N'arif@gmail.com', N'3430333437323638324237313335333637393242414b324d7857564f374a652b352b444261684c377447306139566f3d', N'@4rh+q56y+', 1)
INSERT [dbo].[FinancialInstitution] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [LoginId], [InstitutionName], [TIN], [BIN], [Email], [ContactNo], [ContactPersonName], [ContactPersonDesignation], [ContactPersonOffice], [ContactPersonNID], [ContactPersonMobile], [ContactPersonEmail], [Password], [PasswordSalt], [EntityState]) VALUES (2, NULL, NULL, NULL, NULL, NULL, 0, N'brac123', N'Brac Bank Ltd.', N'35642537165', N'123576154761', N'brac@gmail.com', N'01982735423', N'Asif Hasan', N'Manager', N'Central', N'231313', N'01716254234', N'asif@gmail.com', N'363537333632364536323642343035323733343856787467795265553644346a4465704b68666374644164444739733d', N'esbnbk@RsH', 1)
INSERT [dbo].[FinancialInstitution] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [LoginId], [InstitutionName], [TIN], [BIN], [Email], [ContactNo], [ContactPersonName], [ContactPersonDesignation], [ContactPersonOffice], [ContactPersonNID], [ContactPersonMobile], [ContactPersonEmail], [Password], [PasswordSalt], [EntityState]) VALUES (3, NULL, NULL, NULL, NULL, NULL, 0, N'dhakabank', N'Dhaka Bank Ltd', N'112233', N'221122', N'dbl@gmail.com', N'01723753954', N'Saif Kamal', N'GM', N'Orion', N'654321', N'01723753925', N'saifx2y@gmail.com', N'35303635344534333339363432413444353434305a69346d3247677a786162356936333135356a3741324a336c316b3d', N'PeNC9d*MT@', 1)
INSERT [dbo].[FinancialInstitution] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [LoginId], [InstitutionName], [TIN], [BIN], [Email], [ContactNo], [ContactPersonName], [ContactPersonDesignation], [ContactPersonOffice], [ContactPersonNID], [ContactPersonMobile], [ContactPersonEmail], [Password], [PasswordSalt], [EntityState]) VALUES (4, NULL, NULL, NULL, NULL, NULL, 0, N'dbbl123', N'Dutch Bangla Bank Ltd', N'223322', N'553322', N'dbbl@gmail.com', N'01723753954', N'Saif Kamal Chowdhury', N'Intern', N'Orion', N'654321', N'01723753925', N'saifx2y@gmail.com', N'3236323936323442343935373330323537353242687343576f613263624254616d766d37494a2f387a6b677a6462673d', N'&)bKIW0%u+', 1)
SET IDENTITY_INSERT [dbo].[FinancialInstitution] OFF

INSERT [dbo].[Banks] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [SwiftBic], [SuspenseAccount], [CbaccountNo], [EntityState]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 0, N'EBLDBDBH', N'425621', N'432651', 1)
INSERT [dbo].[Banks] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [SwiftBic], [SuspenseAccount], [CbaccountNo], [EntityState]) VALUES (2, NULL, NULL, NULL, NULL, NULL, 0, N'BRAKBDDH', N'875621', N'552651', 1)


SET IDENTITY_INSERT [dbo].[Branches] ON 
INSERT [dbo].[Branches] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [BankId], [BranchName], [RoutingNumber], [EntityState]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 0, 1, N'Gulshan', N'0987665765', 1)
INSERT [dbo].[Branches] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [BankId], [BranchName], [RoutingNumber], [EntityState]) VALUES (2, NULL, NULL, NULL, NULL, NULL, 0, 2, N'Gulshan', N'0987665765', 1)
INSERT [dbo].[Branches] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [BankId], [BranchName], [RoutingNumber], [EntityState]) VALUES (3, NULL, NULL, NULL, NULL, NULL, 0, 1, N'Dhanmondi', N'0987665765', 1)
INSERT [dbo].[Branches] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [BankId], [BranchName], [RoutingNumber], [EntityState]) VALUES (4, NULL, NULL, NULL, NULL, NULL, 0, 2, N'Mohakhali', N'0987665765', 1)
SET IDENTITY_INSERT [dbo].[Branches] Off


INSERT [dbo].[ParticipantDebitCap] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [NetDebitCap], [EntityState], [SettlementStatus]) VALUES (1, NULL, NULL, NULL, NULL, NULL, 0, CAST(97250.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[ParticipantDebitCap] ([Id], [Created_UserId], [CreatedOn], [Modified_UserId], [ModifiedOn], [ExtendedProperties], [RecordHash], [NetDebitCap], [EntityState], [SettlementStatus]) VALUES (2, NULL, NULL, NULL, NULL, NULL, 0, CAST(102500.00 AS Decimal(18, 2)), 2, 1)
