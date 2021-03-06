USE [eLearning]
GO
SET IDENTITY_INSERT [dbo].[CourseRating] ON 

INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (1, 1, 1, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (2, 1, 2, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (3, 1, 3, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (4, 2, 1, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (5, 2, 2, 2)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (6, 2, 3, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (7, 1, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (8, 1, 5, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (9, 2, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (10, 2, 5, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (14, 5, 1, 1)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (15, 5, 2, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (16, 5, 3, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (17, 5, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (18, 5, 5, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (19, 6, 1, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (20, 6, 2, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (21, 6, 3, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (22, 6, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (23, 6, 5, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (24, 7, 1, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (25, 7, 2, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (26, 7, 3, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (27, 7, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (28, 7, 5, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (29, 9, 1, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (30, 9, 2, 2)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (31, 9, 3, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (32, 9, 4, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (33, 9, 5, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (35, 17, 1, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (36, 17, 2, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (37, 17, 3, 3)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (38, 17, 4, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (39, 17, 5, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (40, 18, 1, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (41, 18, 2, 4)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (42, 18, 3, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (43, 18, 4, 5)
INSERT [dbo].[CourseRating] ([Id], [CourseId], [StudentId], [Rating]) VALUES (44, 18, 5, 4)
SET IDENTITY_INSERT [dbo].[CourseRating] OFF

SET IDENTITY_INSERT [dbo].[StudentLineItem] OFF 
INSERT INTO [dbo].[StudentLineItem] ([StudentId],[CurriculaLineItemId],[CompletionDate]) VALUES (7, 21, '2019-04-17T11:01:00');
INSERT INTO [dbo].[StudentLineItem] ([StudentId],[CurriculaLineItemId],[CompletionDate]) VALUES (7, 22, '2019-04-17T12:02:00');
INSERT INTO [dbo].[StudentLineItem] ([StudentId],[CurriculaLineItemId],[CompletionDate]) VALUES (7, 23, '2019-04-17T13:03:00');
INSERT INTO [dbo].[StudentLineItem] ([StudentId],[CurriculaLineItemId],[CompletionDate]) VALUES (7, 24, '2019-04-17T14:04:00');
SET IDENTITY_INSERT [dbo].[StudentLineItem] ON




SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Username]
      ,[Email]
      ,[Hash]
      ,[RoleId]
      ,[Salt]
	    FROM [eLearning].[dbo].[User]
		
		
SET IDENTITY_INSERT [dbo].[User] OFF 
INSERT INTO [dbo].[User] ([Id],[FirstName],[LastName],[Username],[Email],[Hash],[RoleId],[Salt]) VALUES ( 6, N'', N'', N'', N'', N'', 2, );