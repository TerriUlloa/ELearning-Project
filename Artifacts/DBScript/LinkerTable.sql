create table [dbo].[UserCourse] (
[Id] [int] IDENTITY(1,1) NOT NULL,
[CourseId] [int] NOT NULL,
[UserId] [int] NOT Null,
CONSTRAINT [UserCourse_pk] PRIMARY KEY CLUSTERED
(
	[Id] Asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_Course_Id] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_Course_Id]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_User_Id] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_Course_Id]
GO