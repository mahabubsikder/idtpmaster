USE [IDTPDatabase]
GO
SET IDENTITY_INSERT [dbo].[TransactionBill] ON 

INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (1, NULL, NULL, 1, N'DESCO', CAST(N'2020-06-14T20:08:30.5489893' AS DateTime2), CAST(440.00 AS Decimal(18, 2)), 1, N'EBLD20200614200829', N'0127665765', N'DESCOa78b31', 1, NULL, NULL, 2)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (2, NULL, NULL, 1, N'DESCO', CAST(N'2020-06-14T21:03:26.9818823' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 1, N'EBLD20200614210325', N'0127665765', N'DESCO41397a', 1, NULL, NULL, 2)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (3, NULL, NULL, 1, N'DESCO', CAST(N'2020-06-14T21:09:51.4056927' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 2, N'BRAK20200614210951', N'0327665765', N'DESCO689896', 1, NULL, NULL, 2)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (4, NULL, NULL, 2, N'TITAS', CAST(N'2020-06-16T00:33:29.6911684' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), 1, N'EBLD20200616003328', N'0987665765', N'DESCOe81ea0', 1, NULL, NULL, 3)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (5, NULL, NULL, 2, N'TITAS', CAST(N'2020-06-16T00:33:29.6911684' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), 1, N'EBLD20200616003328', N'0987665765', N'GAS123', 1, NULL, NULL, 3)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (6, NULL, NULL, 2, N'WASA', CAST(N'2020-06-16T00:33:29.6911684' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), 1, N'EBLD20200616003328', N'0987665765', N'WATER7577', 1, NULL, NULL, 4)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (7, NULL, NULL, 2, N'WASA', CAST(N'2020-06-16T00:33:29.6911684' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), 1, N'EBLD20200616003328', N'0987665765', N'DESCOe81ea0', 1, NULL, NULL, 4)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (8, NULL, NULL, 2, N'BTCL', CAST(N'2020-06-16T00:33:29.6911684' AS DateTime2), CAST(2000.00 AS Decimal(18, 2)), 1, N'EBLD20200616003328', N'0987665765', N'BTCL78493', 1, NULL, NULL, 5)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (12, NULL, NULL, 2, N'BTCL', CAST(N'2020-06-16T00:53:29.6911684' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 1, N'EBLD20200616005328', N'098766765', N'BTCL6545', 1, NULL, NULL, 5)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (13, NULL, NULL, 2, N'DESCO', CAST(N'2020-06-17T15:54:41.3195129' AS DateTime2), CAST(525.00 AS Decimal(18, 2)), 2, N'BRAK20200617155439', N'0327665765', N'DESCO753163', 1, NULL, NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (14, CAST(N'2020-06-17T15:57:55.0934006' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-17T15:57:50.8429753' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 1, N'EBLD20200617155749', N'0127665765', N'DESCOfa8b38', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (15, CAST(N'2020-06-17T17:28:39.9125500' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-17T17:28:35.8174521' AS DateTime2), CAST(650.00 AS Decimal(18, 2)), 2, N'BRAK20200617172834', N'0327665765', N'DESCOafe1ab', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (16, CAST(N'2020-06-17T17:29:06.3323683' AS DateTime2), NULL, 2, N'DESCO', CAST(N'2020-06-17T17:29:05.3401177' AS DateTime2), CAST(750.00 AS Decimal(18, 2)), 1, N'EBLD20200617172905', N'0987665765', N'DESCO160ce7', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (17, CAST(N'2020-06-17T18:29:39.6243941' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-17T18:29:32.6828234' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 2, N'BRAK20200617182905', N'0327665765', N'DESCOf19d11', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (18, CAST(N'2020-06-17T20:13:42.7937480' AS DateTime2), NULL, 2, N'DESCO', CAST(N'2020-06-17T20:13:38.5642436' AS DateTime2), CAST(750.00 AS Decimal(18, 2)), 1, N'EBLD20200617201337', N'0127665765', N'DESCO8211c5', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (19, CAST(N'2020-06-18T14:16:53.7860637' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-18T14:16:44.8853479' AS DateTime2), CAST(200.00 AS Decimal(18, 2)), 1, N'EBLD20200618141643', N'0987665765', N'DESCO624651', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (20, CAST(N'2020-06-18T14:18:13.9823798' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-18T14:18:11.3011331' AS DateTime2), CAST(45.00 AS Decimal(18, 2)), 1, N'EBLD20200618141810', N'0987665765', N'DESCO18c61f', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (21, CAST(N'2020-06-18T14:19:31.4077965' AS DateTime2), NULL, 2, N'DESCO', CAST(N'2020-06-18T14:19:30.1409257' AS DateTime2), CAST(25.00 AS Decimal(18, 2)), 1, N'EBLD20200618141929', N'0987665765', N'DESCOec6b11', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (22, CAST(N'2020-06-18T16:37:02.8573780' AS DateTime2), NULL, 2, N'DESCO', CAST(N'2020-06-18T16:36:57.2565083' AS DateTime2), CAST(500.00 AS Decimal(18, 2)), 1, N'EBLD20200618163655', N'0127665765', N'DESCObb73b0', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (23, CAST(N'2020-06-18T16:38:05.3886743' AS DateTime2), NULL, 2, N'DESCO', CAST(N'2020-06-18T16:38:03.4452646' AS DateTime2), CAST(200.00 AS Decimal(18, 2)), 1, N'EBLD20200618163803', N'0127665765', N'DESCOdf1889', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (24, CAST(N'2020-06-18T18:23:32.5620517' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-18T18:23:25.5261256' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 2, N'BRAK20200618182323', N'0327665765', N'DESCO0db0af', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (25, CAST(N'2020-06-18T18:30:42.6490895' AS DateTime2), NULL, 1, N'DESCO', CAST(N'2020-06-18T18:30:34.2225627' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 2, N'BRAK20200618183032', N'0327665765', N'DESCO3cba3a', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (26, CAST(N'2020-06-18T19:26:08.8610599' AS DateTime2), CAST(N'2020-06-18T19:26:08.8612330' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-18T19:26:00.8900240' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 1, N'EBLD20200618192559', N'0127665765', N'DESCO76e959', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (27, CAST(N'2020-06-21T15:06:23.5616242' AS DateTime2), CAST(N'2020-06-21T15:06:23.5617004' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-21T15:06:18.7857242' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 1, N'EBLD20200621150614', N'0127665765', N'DESCO35bde8', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (28, CAST(N'2020-06-21T16:44:10.5278818' AS DateTime2), CAST(N'2020-06-21T16:44:10.5279470' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-21T16:44:08.5293462' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 1, N'EBLD20200621164404', N'0127665765', N'DESCOdb0bcb', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (29, CAST(N'2020-06-21T17:26:11.8642346' AS DateTime2), CAST(N'2020-06-21T17:26:11.8643451' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-21T17:26:07.8272840' AS DateTime2), CAST(200.00 AS Decimal(18, 2)), 1, N'EBLD20200621172559', N'0987665765', N'DESCOa31d06', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (30, CAST(N'2020-06-21T21:18:06.3973826' AS DateTime2), CAST(N'2020-06-21T21:18:06.3974810' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-21T21:18:04.2850456' AS DateTime2), CAST(850.00 AS Decimal(18, 2)), 1, N'EBLD20200621211800', N'0127665765', N'DESCO68930a', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (31, CAST(N'2020-06-22T12:59:10.4531640' AS DateTime2), CAST(N'2020-06-22T12:59:10.4532347' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-22T12:59:08.3627322' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 2, N'BRAK20200622125903', N'0327665765', N'DESCO7bcf26', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (32, CAST(N'2020-06-22T12:59:48.5976980' AS DateTime2), CAST(N'2020-06-22T12:59:48.5977023' AS DateTime2), 2, N'DESCO', CAST(N'2020-06-22T12:59:47.5466125' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 1, N'EBLD20200622125947', N'0127665765', N'DESCOe6a825', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (33, CAST(N'2020-06-22T15:26:44.8624754' AS DateTime2), CAST(N'2020-06-22T15:26:44.8625425' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-22T15:26:42.6498727' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 1, N'EBLD20200622152638', N'0127665765', N'DESCO620eec', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (34, CAST(N'2020-06-22T15:49:15.7393517' AS DateTime2), CAST(N'2020-06-22T15:49:15.7393593' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-22T15:49:14.3106962' AS DateTime2), CAST(220.00 AS Decimal(18, 2)), 1, N'EBLD20200622154913', N'0127665765', N'DESCO0ba514', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (35, CAST(N'2020-06-22T18:03:59.5622576' AS DateTime2), CAST(N'2020-06-22T18:03:59.5623203' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-22T18:03:57.5690106' AS DateTime2), CAST(500.00 AS Decimal(18, 2)), 2, N'BRAK20200622180353', N'0327665765', N'DESCO9404c1', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (36, CAST(N'2020-06-23T15:20:53.1631166' AS DateTime2), CAST(N'2020-06-23T15:20:53.1631594' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-23T15:20:40.3948482' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 2, N'BRAK20200623212017', N'0327665765', N'DESCO77333b', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (37, CAST(N'2020-06-24T15:18:33.3188325' AS DateTime2), CAST(N'2020-06-24T15:18:33.3188420' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-24T15:18:05.4043379' AS DateTime2), CAST(515.00 AS Decimal(18, 2)), 1, N'EBLD20200624211800', N'0987665765', N'DESCO762bc1', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (38, CAST(N'2020-06-25T07:47:32.4166022' AS DateTime2), CAST(N'2020-06-25T07:47:32.4166077' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T07:47:07.8146054' AS DateTime2), CAST(606.00 AS Decimal(18, 2)), 2, N'BRAK20200625134701', N'0327665765', N'DESCO176a76', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (39, CAST(N'2020-06-25T07:49:04.6033672' AS DateTime2), CAST(N'2020-06-25T07:49:04.6033693' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T07:49:04.3750712' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 1, N'EBLD20200625134858', N'0127665765', N'DESCOdb83b7', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (40, CAST(N'2020-06-25T07:55:54.5213894' AS DateTime2), CAST(N'2020-06-25T07:55:54.5213913' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T07:55:54.2245071' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 2, N'BRAK20200625135548', N'0327665765', N'DESCObc291c', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (41, CAST(N'2020-06-25T07:56:28.3011298' AS DateTime2), CAST(N'2020-06-25T07:56:28.3011314' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T07:56:27.9839818' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 3, N'DBBL20200625135622', N'0577665565', N'DESCO614c7d', 1, N'Dutch-Bangla Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (42, CAST(N'2020-06-25T07:58:29.1269616' AS DateTime2), CAST(N'2020-06-25T07:58:29.1269635' AS DateTime2), 2, N'DESCO', CAST(N'2020-06-25T07:58:28.8067217' AS DateTime2), CAST(650.00 AS Decimal(18, 2)), 3, N'DBBL20200625135822', N'0577665599', N'DESCOcfaa7e', 1, N'Dutch-Bangla Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (43, CAST(N'2020-06-25T07:59:53.2288672' AS DateTime2), CAST(N'2020-06-25T07:59:53.2288691' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T07:59:52.8958115' AS DateTime2), CAST(445.00 AS Decimal(18, 2)), 1, N'EBLD20200625135946', N'0127665765', N'DESCOb9e333', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (44, CAST(N'2020-06-25T14:35:05.7690964' AS DateTime2), CAST(N'2020-06-25T14:35:05.7691027' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T14:35:04.0354866' AS DateTime2), CAST(750.00 AS Decimal(18, 2)), 1, N'EBLD20200625203500', N'0987665765', N'DESCOc2b1bc', 1, N'Eastern Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (45, CAST(N'2020-06-25T16:52:09.4131123' AS DateTime2), CAST(N'2020-06-25T16:52:09.4131197' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-25T16:52:08.0683658' AS DateTime2), CAST(750.00 AS Decimal(18, 2)), 2, N'BRAK20200625225205', N'0327665765', N'DESCO52de58', 1, N'Brac Bank Ltd.', NULL, NULL)
INSERT [dbo].[TransactionBill] ([Id], [CreatedOn], [ModifiedOn], [SenderId], [ReceiverName], [TransactionDate], [Amount], [SenderBankId], [TransactionId], [SendingBankRoutingNo], [BillReferenceId], [EntityState], [CreatedBy], [ModifiedBy], [BillCategoryId]) VALUES (46, CAST(N'2020-06-28T13:45:04.8960319' AS DateTime2), CAST(N'2020-06-28T13:45:04.8960345' AS DateTime2), 1, N'DESCO', CAST(N'2020-06-28T13:44:56.0414509' AS DateTime2), CAST(200.00 AS Decimal(18, 2)), 4, N'SBL120200628134452', N'0577885599', N'DESCO3660e1', 1, N'Sample Bank 1', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionBill] OFF
