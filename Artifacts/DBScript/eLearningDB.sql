USE [master]
GO
/****** Object:  Database [eLearning]    Script Date: 4/18/2019 6:26:32 PM ******/
CREATE DATABASE [eLearning]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eLearning', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\eLearning.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eLearning_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\eLearning_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [eLearning] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eLearning].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eLearning] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eLearning] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eLearning] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eLearning] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eLearning] SET ARITHABORT OFF 
GO
ALTER DATABASE [eLearning] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eLearning] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eLearning] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eLearning] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eLearning] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eLearning] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eLearning] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eLearning] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eLearning] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eLearning] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eLearning] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eLearning] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eLearning] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eLearning] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eLearning] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eLearning] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eLearning] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eLearning] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eLearning] SET  MULTI_USER 
GO
ALTER DATABASE [eLearning] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eLearning] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eLearning] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eLearning] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eLearning] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eLearning] SET QUERY_STORE = OFF
GO
USE [eLearning]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/18/2019 6:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/18/2019 6:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[EstimatedDuration] [int] NULL,
	[TeacherId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Image] [varchar](1000) NULL,
 CONSTRAINT [Course_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseImages]    Script Date: 4/18/2019 6:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](500) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseRating]    Script Date: 4/18/2019 6:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseRating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Rating] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curricula]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curricula](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[CourseSession] [int] NOT NULL,
	[Description] [varchar](max) NOT NULL,
 CONSTRAINT [Curricula_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurriculaLineItem]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurriculaLineItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurriculaId] [int] NOT NULL,
	[CurriculaTypeId] [int] NOT NULL,
	[Description] [varchar](max) NULL,
	[LineItem] [int] NULL,
	[URL] [varchar](255) NULL,
	[FileName] [varchar](255) NULL,
 CONSTRAINT [CurriculaLineItems_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurriculaType]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurriculaType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [CurriculaType_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurriculaLineItemId] [int] NOT NULL,
	[Name] [varchar](200) NULL,
	[Description] [varchar](max) NULL,
	[URL] [varchar](255) NULL,
 CONSTRAINT [Quiz_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizQuestion]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizQuestion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuizId] [int] NOT NULL,
	[QuestionNumber] [int] NULL,
	[Question] [varchar](max) NULL,
	[AnswerA] [varchar](50) NULL,
	[AnswerB] [varchar](50) NULL,
	[AnswerC] [varchar](50) NULL,
	[AnswerD] [varchar](50) NULL,
	[AnswerE] [varchar](50) NULL,
	[CorrectAnswer] [char](1) NULL,
 CONSTRAINT [QuizQuestions_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[UserId] [int] NULL,
	[RegistrationDate] [date] NULL,
	[CompletionDate] [date] NULL,
	[Grade] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentLineItem]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentLineItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CurriculaLineItemId] [int] NULL,
	[CompletionDate] [date] NULL,
	[Grade] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/18/2019 6:26:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Hash] [varchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Salt] [varchar](50) NOT NULL,
 CONSTRAINT [PK_VendUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (1, N'Development', N'Courses having to do with computer software development')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (2, N'Business', N'Courses about Running a business')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (3, N'Office Productivity', N'Courses about making your office more productive')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (4, N'Design', N'Courses about interior or exterior design')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (5, N'Marketing', N'Courses about how to market your business')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (6, N'Lifestyle', N'Couses about how people live')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (7, N'Finance', N'Courses about personal finance')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (8, N'Crafts', N'Courses about various craft projects')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (9, N'Culinary', N'Courses about cooking')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (10, N'Accounting', N'Courses about accounting practices')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (11, N'Leadership', N'Courses about Leadership')
INSERT [dbo].[Category] ([Id], [Name], [Description]) VALUES (12, N'Writing', N'Courses about how to improve your writing')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (1, N'HTML and CSS Master Class', N'HTML and CSS Web Development Masterclass  is a Introductory course to Web development where i explain to you the main concepts of HTML language and relation with CSS, that leads you to perfect websites ()


 HTML is a power language that will help you develop mobile application,  websites, and work with other languages like JavaScript or PHP that allow you to create dynamic pages.
', 90, 1, 1, N'HTML.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (2, N'Introduction To Javascript - Arrays', N'Learn how to store data in JavaScript with arrays.', 210, 1, 1, N'javascript1.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (5, N'New Course - Better Name', N'This is a new course description.  And a better description.', 185, 1, 2, N'garbagecan.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (6, N'English as a Second Language', N'This is the second attempt to add a new course.', 166, 1, 3, N'esl.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (7, N'Massage 101', N'How to get started as a masseuse', 26, 4, 11, N'massage.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (9, N'Cooking For Dummies', N'Smart people need not register', 90, 1, 9, N'cooking.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (17, N'Modern Software Design', N'This is a course about Modern Software Design', 12, 4, 1, N'ModernSoftwareDesign.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (18, N'Chemistry and You', N'A simple chemistry course', 100, 5, 8, N'chemistry.png')
INSERT [dbo].[Course] ([Id], [Name], [Description], [EstimatedDuration], [TeacherId], [CategoryId], [Image]) VALUES (20, N'asdf', N'Test 11 - 11', 324, 4, 4, N'helloquence-61189-unsplash.jpg')
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseImages] ON 

INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (2, N'Chemistry', N'chemistry.png')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (3, N'Cooking', N'cooking.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (4, N'Course', N'Course1.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (5, N'Child Development', N'course2.png')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (6, N'New Course Default', N'coursedefault.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (7, N'Unselected Default', N'helloquence-61189-unsplash.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (8, N'HTML', N'HTML.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (9, N'Jack Russel', N'Jack1.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (10, N'Javascript', N'Javascript1.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (11, N'Massage', N'massage.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (12, N'Software Design', N'ModernSoftwareDesign.jpg')
INSERT [dbo].[CourseImages] ([Id], [Title], [URL]) VALUES (13, N'Physics', N'physics.jpg')
SET IDENTITY_INSERT [dbo].[CourseImages] OFF
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
SET IDENTITY_INSERT [dbo].[Curricula] ON 

INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (2, 1, 1, N'Introduction')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (3, 1, 2, N'Code Editor')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (4, 1, 3, N'HTML Structure')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (5, 1, 4, N'HTML Attributes')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (6, 1, 5, N'Creating your first Web Page')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (7, 2, 1, N'Array Introduction')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (8, 2, 2, N'Create An Array')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (9, 2, 3, N'Accessing Elements')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (10, 2, 4, N'Updating Elements')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (11, 2, 5, N'Arrays with Let and Const')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (12, 2, 6, N'The .Length Property')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (13, 2, 7, N'The .Push Method')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (14, 2, 8, N'The .Pop Method')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (15, 2, 9, N'More Array Methods')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (16, 2, 10, N'Arrays and Functions')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (17, 1, 6, N'New Curricula')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (18, 1, 7, N'Second Addition')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (19, 1, 8, N'Test 8')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (21, 1, 9, N'Test 9')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (22, 1, 10, N'test 10')
INSERT [dbo].[Curricula] ([Id], [CourseId], [CourseSession], [Description]) VALUES (23, 1, 11, N'Test 11 - 11')
SET IDENTITY_INSERT [dbo].[Curricula] OFF
SET IDENTITY_INSERT [dbo].[CurriculaLineItem] ON 

INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (1, 2, 2, N'HTML and CSS Web Development Masterclass  is a Introductory course to Web development where i explain to you the main concepts of HTML language and relation with CSS, that leads you to perfect websites ()


 HTML is a power language that will help you develop mobile application,  websites, and work with other languages like JavaScript or PHP that allow you to create dinamic pages.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (2, 3, 2, N'In this lesson you''ll learn about the various code editors', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (3, 4, 2, N'In this lesson you''ll learn about the various structures for HTML syntax', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (4, 5, 2, N'In this lesson you''ll learn about the attributes to an HTML element', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (5, 6, 2, N'In this lesson you''ll create your first web page', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (6, 7, 2, N'Organizing and storing data is a foundational concept of programming.

One way we organize data in real life is by making lists. Let’s make one here:

New Year''s Resolutions:
1. Keep a journal 
2. Take a falconry class
3. Learn to juggle
Let’s now write this list in JavaScript, as an array:

let newYearsResolutions = [''Keep a journal'', ''Take a falconry class'', ''Learn to juggle''];
Arrays are JavaScript’s way of making lists. Arrays can store any data types (including strings, numbers, and booleans). Like lists, arrays are ordered, meaning each item has a numbered position.

Here’s an array of the concepts we’ll cover:

let concepts = [''creating arrays'', ''array structures'', ''array manipulation'']
By the end of this lesson you’ll have another tool under your belt that helps you manage chunks of data!', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (7, 8, 2, N'One way we can create an array is to use an array literal. An array literal creates an array by wrapping items in square brackets []. Remember from the previous exercise, arrays can store any data type — we can have an array that holds all the same data types or an array that holds different data types.

Diagram outlining an array literal that has 3 separate elements, a comma separates each element (a string, a number, and a boolean) and the elements are wrapped with square brackets
Let’s take a closer look at the syntax in the array example:

The array is represented by the square brackets [] and the content inside.
Each content item inside an array is called an element.
There are three different elements inside the array.
Each element inside the array is a different data type.
We can also save an array to a variable. You may have noticed we did this in the previous exercise:

let newYearsResolutions = [''Keep a journal'', ''Take a falconry class'', ''Learn to juggle''];
Let’s practice by making an array of our own.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (8, 9, 2, N'Each element in an array has a numbered position known as its index. We can access individual items using their index, which is similar to referencing an item in a list based on the item’s position.

Arrays in JavaScript are zero-indexed, meaning the positions start counting from 0 rather than 1. Therefore, the first item in an array will be at position 0. Let’s see how we could access an element in an array:

Diagram outlining how to access the property of an array using the index of the element
In the code snippet above:

cities is an array that has three elements.
We’re using bracket notation, [] with the index after the name of the array to access the element.
cities[0] will access the element at index 0 in the array cities. You can think of cities[0] as accessing the space in memory that holds the string ''New York''.
You can also access individual characters in a string using bracket notation and the index. For instance, you can write:

const hello = ''Hello World'';
console.log(hello[6]);
// Output: W
The console will display W since it is the character that is at index 6.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (9, 10, 2, N'In the previous exercise, you learned how to access elements inside an array or a string by using an index. Once you have access to an element in an array, you can update its value.

let seasons = [''Winter'', ''Spring'', ''Summer'', ''Fall''];

seasons[3] = ''Autumn'';
console.log(seasons); 
//Output: [''Winter'', ''Spring'', ''Summer'', ''Autumn'']
In the example above, the seasons array contained the names of the four seasons.

However, we decided that we preferred to say ''Autumn'' instead of ''Fall''.

The line, seasons[3] = ''Autumn''; tells our program to change the item at index 3 of the seasons array to be ''Autumn'' instead of what is already there.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (10, 11, 2, N'You may recall that you can declare variables with both the let and const keywords. Variables declared with let can be reassigned.

Variables declared with the const keyword cannot be reassigned. However, elements in an array declared with const remain mutable. Meaning that we can change the contents of a const array, but cannot reassign a new array or a different value.

The instructions below will illustrate this concept more clearly. Pay close attention to the similarities and differences between the condiments array and the utensils array as you complete the steps.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (11, 12, 2, N'One of an array’s built-in properties is length and it returns the number of items in the array. We access the .length property just like we do with strings. Check the example below:

const newYearsResolutions = [''Keep a journal'', ''Take a falconry class''];

console.log(newYearsResolutions.length);
// Output: 2
In the example above, we log newYearsResolutions.length to the console using the following steps:

We use dot notation, chaining a period with the property name to the array, to access the length property of the newYearsResolutions array.
Then we log the length of newYearsResolution to the console.
Since newYearsResolution has two elements, so 2 would be logged to the console.
When we want to know how many elements are in an array, we can access the .length property.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (12, 13, 2, N'Let’s learn about some built-in JavaScript methods that make working with arrays easier. These methods are specifically called on arrays to make common tasks, like adding and removing elements, more straightforward.

One method, .push() allows us to add items to the end of an array. Here is an example of how this is used:

const itemTracker = [''item 0'', ''item 1'', ''item 2''];

itemTracker.push(''item 3'', ''item 4'');

console.log(itemTracker); 
// Output: [''item 0'', ''item 1'', ''item 2'', ''item 3'', ''item 4''];
So, how does .push() work?

We access the push method by using dot notation, connecting push to itemTracker with a period.
Then we call it like a function. That’s because .push() is a function and one that JavaScript allows us to use right on an array.
.push() can take a single argument or multiple arguments separated by commas. In this case, we’re adding two elements: ''item 3'' and ''item 4'' to itemTracker.
Notice that .push() changes, or mutates, itemTracker. You might also see .push() referred to as a destructive array method since it changes the initial array.
If you’re looking for a method that will mutate an array by adding elements to it, then .push() is the method for you!', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (13, 14, 2, N'Another array method, .pop(), removes the last item of an array.

const newItemTracker = [''item 0'', ''item 1'', ''item 2''];

const removed = newItemTracker.pop();

console.log(newItemTracker); 
// Output: [ ''item 0'', ''item 1'' ]
console.log(removed);
// Output: item 2
In the example above, calling .pop() on the newItemTracker array removed item 2 from the end.
.pop() does not take any arguments, it simply removes the last element of newItemTracker.
.pop() returns the value of the last element. In the example, we store the returned value in a variable removed to be used for later.
.pop() is a method that mutates the initial array.
When you need to mutate an array by removing the last element, use .pop().', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (14, 15, 2, N'There are many more array methods than just .push() and .pop(). You can read about all of the array methods that exist on the Mozilla Developer Network (MDN) array documentation.

.pop() and .push() mutate the array on which they’re called. However, there are times that we don’t want to mutate the original array and we can use non-mutating array methods. Be sure to check MDN to understand the behavior of the method you are using.

Some arrays methods that are available to JavaScript developers include: .join(), .slice(), .splice(), .shift(), .unshift(), and .concat() amongst many others. Using these built-in methods make it easier to do some common tasks when working with arrays.

Below, we will explore some methods that we have not learned yet. We will use these methods to edit a grocery list. As you complete the steps, you can consult the MDN documentation to learn what each method does!', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (15, 16, 2, N'Throughout the lesson we went over arrays being mutable, or changeable. Well what happens if we try to change an array inside a function? Does the array keep the change after the function call or is it scoped to inside the function?

Take a look at the following example where we call .push() on an array inside a function. Recall, the .push() method mutates, or changes, an array:

const flowers = [''peony'', ''daffodil'', ''marigold''];

function addFlower(arr) {
  arr.push(''lily'');
}

addFlower(flowers);

console.log(flowers); // Output: [''peony'', ''daffodil'', ''marigold'', ''lily'']
Let’s go over what happened in the example:

The flowers array that has 3 elements.
The function addFlower() has a parameter of arr uses .push() to add a ''lily'' element into arr.
We call addFlower() with an argument of flowers which will execute the code inside addFlower.
We check the value of flowers and it now includes the ''lily'' element! The array was mutated!
So when you pass an array into a function, if the array is mutated inside the function, that change will be maintained outside the function as well. You might also see this concept explained as pass-by-reference since what we’re actually passing the function is a reference to where the variable memory is stored and changing the memory.', 1, NULL, NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (16, 2, 1, N'Easy Fullscreen Landing Page With HTML & CSS', 2, N'https://www.youtube.com/watch?v=hVdTQWASliE', NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (17, 3, 1, N'My Top 5 Free Text Editors For Web Development', 2, N'https://www.youtube.com/watch?v=AJnhqf5IRC4', NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (18, 4, 1, N'Understanding HTML Structure', 2, N'https://www.youtube.com/watch?v=mSWDA0N97Jg', NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (19, 5, 1, N'HTML Tags, Attribures, and Elements', 2, N'https://www.youtube.com/watch?v=vNOyRZIkC7o', NULL)
INSERT [dbo].[CurriculaLineItem] ([Id], [CurriculaId], [CurriculaTypeId], [Description], [LineItem], [URL], [FileName]) VALUES (20, 6, 1, N'HTML Tutorial for Beginners - 01 - Creating the first web page', 2, N'https://www.youtube.com/watch?v=-USAeFpVf_A', NULL)
SET IDENTITY_INSERT [dbo].[CurriculaLineItem] OFF
SET IDENTITY_INSERT [dbo].[CurriculaType] ON 

INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (1, N'Video')
INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (2, N'Text')
INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (3, N'Homework')
INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (4, N'URL')
INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (5, N'FTP')
INSERT [dbo].[CurriculaType] ([Id], [Name]) VALUES (6, N'Quiz')
SET IDENTITY_INSERT [dbo].[CurriculaType] OFF
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([Id], [CurriculaLineItemId], [Name], [Description], [URL]) VALUES (1, 4, N'HTML Element Attribute Quiz', N'This quiz will cover how much you have retained about HTML element attributes', NULL)
SET IDENTITY_INSERT [dbo].[Quiz] OFF
SET IDENTITY_INSERT [dbo].[QuizQuestion] ON 

INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (1, 1, 1, N'What does the "style" attribute do?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (2, 1, 2, N'Can you create a custom element attribute or do you have to use only the ones that come in the HTML specification?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (3, 1, 3, N'What attribute do you use to set the location of an image on an <img> tag?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (4, 1, 4, N'What attribute do you use to set the location of a URL on an anchor tag?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (5, 1, 5, N'What does the type attribute do on an <input> tag?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (6, 1, 6, N'Can an element have more than one attribute?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (7, 1, 7, N'Which HTML attribute specifies an alternate text for an image, if the image cannot be displayed?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (8, 1, 8, N'Are "onblur" and "onfocus" element attributes?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (9, 1, 9, N'In HTML, which attribute is used to specify that an input field must be filled out?', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuizQuestion] ([Id], [QuizId], [QuestionNumber], [Question], [AnswerA], [AnswerB], [AnswerC], [AnswerD], [AnswerE], [CorrectAnswer]) VALUES (10, 1, 10, N'Are attributes necessary to create a working HTML document?', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QuizQuestion] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Teacher')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Student')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[StudentCourse] ON 

INSERT [dbo].[StudentCourse] ([Id], [CourseId], [UserId], [RegistrationDate], [CompletionDate], [Grade]) VALUES (1, 1, 1, CAST(N'1900-01-01' AS Date), NULL, NULL)
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [UserId], [RegistrationDate], [CompletionDate], [Grade]) VALUES (2, 1, 2, CAST(N'2000-02-02' AS Date), NULL, NULL)
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [UserId], [RegistrationDate], [CompletionDate], [Grade]) VALUES (3, 1, 3, CAST(N'2003-03-03' AS Date), CAST(N'2004-03-05' AS Date), NULL)
INSERT [dbo].[StudentCourse] ([Id], [CourseId], [UserId], [RegistrationDate], [CompletionDate], [Grade]) VALUES (4, 1, 4, CAST(N'2004-04-04' AS Date), CAST(N'2004-05-05' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[StudentCourse] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (1, N'Fake', N'Teacher', N'fteacher', N'fteacher@rubberduck.com', N'2345', 1, N'12345')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (2, N'Brian', N'Pleshek', N'bpleshek', N'bpleshekncr@rubberduck.com', N'FdT0dvdSPuAaIvZy9hYTGUhj+AQ=', 1, N'C9r+mo/hBVrMYd56Oypv1w==')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (3, N'Brian', N'Pleshek', N'bp', N'bpleshekncr@yellowduck.com', N'egEhuBruvWooxdKFBDv/VaeoQpY=', 2, N'0VHqUKxnuKUKZ8DoCXZcYw==')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (4, N'Brian', N'Pleshek', N'bpteacher', N'bpleshekncr@rubberducky.com', N'u00hOTs5MXZ24IXeNOi8xkOZuJY=', 1, N'ORlFWIiV8w+5OthvkbOIqA==')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (5, N'Albert', N'Einstein', N'aeinstein', N'fasterthanlight@rubberduck.com', N'qG58qj+qEV3nLoysjSYuuTZ+UjI=', 1, N'Hcr3ST94TCjnHUBBbXvsWA==')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (6, N'Wil', N'Ohmsford', N'wohmsford', N'wohmsford@duck.com', N'asd;lfkj', 2, N'asd;fisafljk')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (7, N'Morgan', N'Leah', N'mleah', N'mleah@duck.com', N'fsdjk', 2, N'fsjkl')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (8, N'Garet', N'Jax', N'gjax', N'gjax@duck.com', N'fsajji', 2, N'fdasjkdfsa')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (9, N'Brin', N'Ohmsford', N'bohmsford', N'bohmsford@duck.com', N'feau', 2, N'faje')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (10, N'Walker', N'Boh', N'wboh', N'wboh@duck.com', N'fsdkfe', 2, N'fasd')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (11, N'Wren', N'Elessedil', N'welessedil', N'welessedil@duck.com', N'fewoi', 2, N'vrouw')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (12, N'Mara', N'Acoma', N'macoma', N'macoma@duck.com', N'vw', 2, N'vdn')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (13, N'Erland', N'conDoin', N'econdoin', N'econdoin@duck.com', N'vwun', 2, N'efawiubhi')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (14, N'Erik', N'von Darkmoor', N'vonDarkmoor', N'vonDarkmoor@duck.com', N'rviw', 2, N'mcudwh')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (15, N'Lysle', N'Rigger', N'lrigger', N'lrigger@duck.com', N'vreouh', 2, N'eioqj')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (16, N'Pug', N'Crydee', N'pcrydee', N'pcrydee@duck.com', N'veqhou', 2, N'eoif')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (17, N'Miranda', N'Crydee', N'mcrydee', N'mcrydee@duck.com', N'vreqoo', 2, N'weofc')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (18, N'Will', N'Farrel', N'wfarrel', N'wfarrel@duck.com', N'gvrejio', 2, N'vrjeio')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (19, N'Bruce', N'Willis', N'bwillis', N'bwillis@duck.com', N'vrsli', 2, N'wekjf')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (20, N'Luke', N'Skywalker', N'lskywalker', N'lskywalker@duck.com', N'oivgre', 2, N'fweikj')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (21, N'Han', N'Solo', N'hsolo', N'hsolo@duck.com', N'veoli', 2, N'sdlfj')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (22, N'Wilhuff', N'Tarkin', N'wtarkin', N'wtarkin@duck.com', N'lkvw', 2, N'wsef')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (23, N'Wedge', N'Antilles', N'wantilles', N'wantilles@duck.com', N'vswe', 2, N'fvslk')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (24, N'Jean-Luc', N'Picard', N'jpicard', N'jpicard@duck.com', N'werj', 2, N'salkfj')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (25, N'Wesley', N'Crusher', N'wcrusher', N'wcrusher@duck.com', N'olijsdef', 2, N'cwsieuh')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (26, N'Katherine', N'Pulaski', N'kpulaski', N'kpulaski@duck.com', N'efw', 2, N'cfskej')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (27, N'Ro', N'Laren', N'rlaren', N'rlaren@duck.com', N'lkisdf', 2, N'welj')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (28, N'Lwaxana', N'Troi', N'ltroi', N'ltroi@duck.com', N'uiwe', 2, N'skuef')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Email], [Hash], [RoleId], [Salt]) VALUES (29, N'Tasha', N'Yar', N'tyar', N'tyar@duck.com', N'etis', 2, N'fslkj')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_Image]  DEFAULT ('helloquence-61189-unsplash.jpg') FOR [Image]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Category]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_User]
GO
ALTER TABLE [dbo].[CourseRating]  WITH CHECK ADD  CONSTRAINT [FK_CourseRating_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseRating] CHECK CONSTRAINT [FK_CourseRating_Course]
GO
ALTER TABLE [dbo].[CourseRating]  WITH CHECK ADD  CONSTRAINT [FK_CourseRating_User] FOREIGN KEY([StudentId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CourseRating] CHECK CONSTRAINT [FK_CourseRating_User]
GO
ALTER TABLE [dbo].[Curricula]  WITH CHECK ADD  CONSTRAINT [FK_Curricula_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Curricula] CHECK CONSTRAINT [FK_Curricula_Course]
GO
ALTER TABLE [dbo].[CurriculaLineItem]  WITH CHECK ADD  CONSTRAINT [FK_CurriculaLineItems_Curricula] FOREIGN KEY([CurriculaId])
REFERENCES [dbo].[Curricula] ([Id])
GO
ALTER TABLE [dbo].[CurriculaLineItem] CHECK CONSTRAINT [FK_CurriculaLineItems_Curricula]
GO
ALTER TABLE [dbo].[CurriculaLineItem]  WITH CHECK ADD  CONSTRAINT [FK_CurriculaLineItems_CurriculaType] FOREIGN KEY([CurriculaTypeId])
REFERENCES [dbo].[CurriculaType] ([Id])
GO
ALTER TABLE [dbo].[CurriculaLineItem] CHECK CONSTRAINT [FK_CurriculaLineItems_CurriculaType]
GO
ALTER TABLE [dbo].[QuizQuestion]  WITH CHECK ADD  CONSTRAINT [FK_QuizQuestions_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quiz] ([Id])
GO
ALTER TABLE [dbo].[QuizQuestion] CHECK CONSTRAINT [FK_QuizQuestions_Quiz]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StudentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_StudentLineItem_CurriculaLineItem] FOREIGN KEY([CurriculaLineItemId])
REFERENCES [dbo].[CurriculaLineItem] ([Id])
GO
ALTER TABLE [dbo].[StudentLineItem] CHECK CONSTRAINT [FK_StudentLineItem_CurriculaLineItem]
GO
ALTER TABLE [dbo].[StudentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_StudentLineItem_User] FOREIGN KEY([StudentId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StudentLineItem] CHECK CONSTRAINT [FK_StudentLineItem_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_RoleItem] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_RoleItem]
GO
USE [master]
GO
ALTER DATABASE [eLearning] SET  READ_WRITE 
GO
