IF(NOT EXISTS(SELECT 1 FROM [QuoteQuizDB].[dbo].[QuoteTypes]))
BEGIN
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[QuoteTypes] ON 
INSERT [QuoteQuizDB].[dbo].[QuoteTypes] ([Id], [QuoteTypeName]) VALUES (1, N'BINARY')
INSERT [QuoteQuizDB].[dbo].[QuoteTypes] ([Id], [QuoteTypeName]) VALUES (2, N'MULTIPLE_CHOICE')
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[QuoteTypes] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [QuoteQuizDB].[dbo].[UserTypes]))
BEGIN
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[UserTypes] ON 
INSERT [QuoteQuizDB].[dbo].[UserTypes] ([Id], [UserTypeDesc]) VALUES (1, N'PLAYER')
INSERT [QuoteQuizDB].[dbo].[UserTypes] ([Id], [UserTypeDesc]) VALUES (2, N'ADMIN')
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[UserTypes] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [QuoteQuizDB].[dbo].[Quotes]))
BEGIN
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Quotes] ON 
INSERT [QuoteQuizDB].[dbo].[Quotes] ([Id],[QuoteTypeId], [QuoteText]) VALUES (1, 1, N'The way to get started is to quit talking and begin doing.')
INSERT [QuoteQuizDB].[dbo].[Quotes] ([Id], [QuoteTypeId], [QuoteText]) VALUES (2, 2,N'If life were predictable it would cease to be life, and be without flavor.')
INSERT [QuoteQuizDB].[dbo].[Quotes] ([Id],[QuoteTypeId], [QuoteText]) VALUES (3, 1, N'Life is what happens when you are busy making other plans')
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Quotes] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [QuoteQuizDB].[dbo].[Answers]))
BEGIN
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Answers] ON 
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (1,N'Walt Disney', 1, 1)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (2, N'Steve Jobs', 1, 0)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id], [AnswerText], [QuoteId], [IsCorrect]) VALUES (3,N'Steve Jobs', 2, 0)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (4, N'Eleanor Roosevelt',2, 1)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (5, N'James Cameron', 2, 0)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (6,N'John Lennon', 3, 1)
INSERT [QuoteQuizDB].[dbo].[Answers] ([Id],[AnswerText], [QuoteId], [IsCorrect]) VALUES (7, N'Oprah Winfrey', 3, 0)

SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Answers] OFF
END
GO


IF(NOT EXISTS(SELECT 1 FROM [QuoteQuizDB].[dbo].[Users]))
BEGIN
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Users] ON 
INSERT [QuoteQuizDB].[dbo].[Users] ([Id], [FirstName], [LastName], [Username],[Password],[UserTypeId], [IsActive],[CurrentQuoteModeId] ) VALUES (1, N'A', N'B',N'ab@gmail.com', N'cGFyb2xpMTIzNA==', 1, 1, 2)
INSERT [QuoteQuizDB].[dbo].[Users] ([Id], [FirstName], [LastName], [Username],[Password],[UserTypeId], [IsActive],[CurrentQuoteModeId] ) VALUES (2, N'C', N'D', N'cd@gmail.com', N'cGFyb2xpMTIzNA==', 2, 1, 2)
SET IDENTITY_INSERT [QuoteQuizDB].[dbo].[Users] OFF
END
GO