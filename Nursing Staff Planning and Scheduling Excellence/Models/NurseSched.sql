   
SET QUOTED_IDENTIFIER OFF;
GO
USE [NursingStaff];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

SET IDENTITY_INSERT [dbo].[ShiftSchedule] ON 

INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (14, 9, CAST(N'2023-03-04T18:48:00.000' AS DateTime), CAST(N'2023-03-10T22:48:00.000' AS DateTime), CAST(N'18:48:00' AS Time), CAST(N'22:48:00' AS Time), 1)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (15, 9, CAST(N'2023-03-11T22:48:00.000' AS DateTime), CAST(N'2023-03-22T18:49:00.000' AS DateTime), CAST(N'22:48:00' AS Time), CAST(N'18:49:00' AS Time), 3)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (16, 9, CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'18:59:00' AS Time), CAST(N'18:59:00' AS Time), 2)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (17, 10, CAST(N'2023-03-04T18:59:00.000' AS DateTime), CAST(N'2023-03-29T18:59:00.000' AS DateTime), CAST(N'18:59:00' AS Time), CAST(N'18:59:00' AS Time), 1)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (18, 10, CAST(N'2023-03-04T19:00:00.000' AS DateTime), CAST(N'2023-03-30T21:00:00.000' AS DateTime), CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 3)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (21, 9, CAST(N'2023-03-04T19:26:00.000' AS DateTime), CAST(N'2023-03-04T19:26:00.000' AS DateTime), CAST(N'19:26:00' AS Time), CAST(N'19:26:00' AS Time), 2)
INSERT [dbo].[ShiftSchedule] ([Id], [UserId], [StartDate], [EndDate], [StartTime], [EndTime], [ShiftId]) VALUES (22, 9, CAST(N'2023-03-04T19:27:00.000' AS DateTime), CAST(N'2023-03-04T19:27:00.000' AS DateTime), CAST(N'19:27:00' AS Time), CAST(N'19:27:00' AS Time), 3)
SET IDENTITY_INSERT [dbo].[ShiftSchedule] OFF
GO