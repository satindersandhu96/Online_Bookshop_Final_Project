INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1908a51d-ce3c-4335-b2ef-b7b397409461', N'shop_admin', N'shop_admin', N'70c5174b-99f1-4f6b-905b-a8721ceea54c')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6e9dddfe-9a77-480c-9460-f28a22e5fb23', N'reader', N'reader', N'59b17dcd-69f5-433e-8c24-bafd8638176c')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'abb99e28-5c09-4d27-a55b-a34ed675d4dc', N'admin@books.com', N'ADMIN@BOOKS.COM', N'admin@books.com', N'ADMIN@BOOKS.COM', 1, N'AQAAAAEAACcQAAAAEBq7tUdlE7LR3OLGaw05IoKA9tFqRSxfIMgX2yHIwFlRBmO/AriXggfWj/CVU2tApA==', N'IQWK2TNHZJRZFW6BRM7HFI6YNTNCUCV7', N'045be724-1b7b-4e1d-902c-141412289c5f', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ca877cb1-7fda-4afd-b73f-161137cc0fce', N'sam@books.com', N'SAM@BOOKS.COM', N'sam@books.com', N'SAM@BOOKS.COM', 1, N'AQAAAAEAACcQAAAAEM26pyPu++wOOBpQAWKQzdlg7yoLztsEK+930Dt5BxXVFaaj5FuBNb3x52qZqEHiTA==', N'RKGLYF6VMS5QXCIYVLZ67EBPLRVECD4Z', N'3f911baa-30f1-437e-8a11-d3b8b94e4984', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'abb99e28-5c09-4d27-a55b-a34ed675d4dc', N'1908a51d-ce3c-4335-b2ef-b7b397409461')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ca877cb1-7fda-4afd-b73f-161137cc0fce', N'6e9dddfe-9a77-480c-9460-f28a22e5fb23')
SET IDENTITY_INSERT [dbo].[Book] ON
INSERT INTO [dbo].[Book] ([Id], [BookTitle], [Price], [ImageUrl]) VALUES (1, N'Java Programming', CAST(85.00 AS Decimal(18, 2)), N'java_programming.jpg')
INSERT INTO [dbo].[Book] ([Id], [BookTitle], [Price], [ImageUrl]) VALUES (2, N'Coders At Work', CAST(90.00 AS Decimal(18, 2)), N'coders_at_work.jpg')
INSERT INTO [dbo].[Book] ([Id], [BookTitle], [Price], [ImageUrl]) VALUES (3, N'Engineering Mathematics', CAST(120.00 AS Decimal(18, 2)), N'engineering_maths.jpg')
INSERT INTO [dbo].[Book] ([Id], [BookTitle], [Price], [ImageUrl]) VALUES (4, N'Electrical Engineering', CAST(95.00 AS Decimal(18, 2)), N'electrical_engineering.jpg')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Reader] ON
INSERT INTO [dbo].[Reader] ([Id], [Name], [Email]) VALUES (1, N'Sam Kent', N'sam@books.com')
SET IDENTITY_INSERT [dbo].[Reader] OFF
SET IDENTITY_INSERT [dbo].[BookSalesRecord] ON
INSERT INTO [dbo].[BookSalesRecord] ([Id], [BookId], [ReaderId], [OrderId]) VALUES (1, 1, 1, N'2020_05_08_1')
INSERT INTO [dbo].[BookSalesRecord] ([Id], [BookId], [ReaderId], [OrderId]) VALUES (2, 3, 1, N'2020_05_08_1')
SET IDENTITY_INSERT [dbo].[BookSalesRecord] OFF
