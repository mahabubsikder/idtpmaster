USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[EntityType] ON 

INSERT [dbo].[EntityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (1, NULL, NULL, N'Individual', 1, NULL, NULL)
INSERT [dbo].[EntityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (2, NULL, NULL, N'Business', 1, NULL, NULL)
INSERT [dbo].[EntityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (3, NULL, NULL, N'Financial Institution', 1, NULL, NULL)
INSERT [dbo].[EntityType] ([Id], [CreatedOn], [ModifiedOn], [Type], [EntityState], [CreatedBy], [ModifiedBy]) VALUES (4, NULL, NULL, N'GovernmentEntity', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[EntityType] OFF
