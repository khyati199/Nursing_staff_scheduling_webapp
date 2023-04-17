
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2023 17:51:37
-- Generated from EDMX file: D:\Users\Acer\Desktop\Nursing-Staff-master\Nursing-Staff-master\Nursing Staff Planning and Scheduling Excellence\Models\Nurse.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NursingStaff];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MaritalStatus_MaritalStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaritalStatus] DROP CONSTRAINT [FK_MaritalStatus_MaritalStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Gender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Gender];
GO
IF OBJECT_ID(N'[dbo].[FK_User_MaritalStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_MaritalStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Gender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gender];
GO
IF OBJECT_ID(N'[dbo].[MaritalStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaritalStatus];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[ShiftSchedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShiftSchedule];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Gender'
CREATE TABLE [dbo].[Gender] (
    [GenderId] int IDENTITY(1,1) NOT NULL,
    [GenderName] nvarchar(50)  NULL
);
GO

-- Creating table 'MaritalStatus'
CREATE TABLE [dbo].[MaritalStatus] (
    [MaritalStatusId] int IDENTITY(1,1) NOT NULL,
    [MaritalStatusName] nvarchar(50)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL
);
GO

-- Creating table 'ShiftSchedule'
CREATE TABLE [dbo].[ShiftSchedule] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [StartTime] time  NULL,
    [EndTime] time  NULL,
    [ShiftId] int  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [MaritalStatusId] int  NOT NULL,
    [DOB] datetime  NULL,
    [Sex] int  NULL,
    [Address] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [Province] nvarchar(50)  NULL,
    [ZipCode] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [HomePhone] nvarchar(50)  NULL,
    [CellPhone] nvarchar(50)  NULL,
    [UserRole] int  NULL,
    [AccessLevel] int  NULL,
    [Specialization] nvarchar(50)  NULL,
    [FullName] nvarchar(50)  NULL,
    [Image] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [Fax] nvarchar(50)  NULL,
    [NurseCertification] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GenderId] in table 'Gender'
ALTER TABLE [dbo].[Gender]
ADD CONSTRAINT [PK_Gender]
    PRIMARY KEY CLUSTERED ([GenderId] ASC);
GO

-- Creating primary key on [MaritalStatusId] in table 'MaritalStatus'
ALTER TABLE [dbo].[MaritalStatus]
ADD CONSTRAINT [PK_MaritalStatus]
    PRIMARY KEY CLUSTERED ([MaritalStatusId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Id] in table 'ShiftSchedule'
ALTER TABLE [dbo].[ShiftSchedule]
ADD CONSTRAINT [PK_ShiftSchedule]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Sex] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Gender]
    FOREIGN KEY ([Sex])
    REFERENCES [dbo].[Gender]
        ([GenderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Gender'
CREATE INDEX [IX_FK_User_Gender]
ON [dbo].[User]
    ([Sex]);
GO

-- Creating foreign key on [MaritalStatusId] in table 'MaritalStatus'
ALTER TABLE [dbo].[MaritalStatus]
ADD CONSTRAINT [FK_MaritalStatus_MaritalStatus]
    FOREIGN KEY ([MaritalStatusId])
    REFERENCES [dbo].[MaritalStatus]
        ([MaritalStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaritalStatusId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_MaritalStatus]
    FOREIGN KEY ([MaritalStatusId])
    REFERENCES [dbo].[MaritalStatus]
        ([MaritalStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_MaritalStatus'
CREATE INDEX [IX_FK_User_MaritalStatus]
ON [dbo].[User]
    ([MaritalStatusId]);
GO

-- Creating foreign key on [UserRole] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([UserRole])
    REFERENCES [dbo].[Role]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[User]
    ([UserRole]);
GO

GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (1, N'Male')
INSERT [dbo].[Gender] ([GenderId], [GenderName]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

INSERT [dbo].[MaritalStatus] ([MaritalStatusId], [MaritalStatusName]) VALUES (1, N'Single')
INSERT [dbo].[MaritalStatus] ([MaritalStatusId], [MaritalStatusName]) VALUES (2, N'Married')
INSERT [dbo].[MaritalStatus] ([MaritalStatusId], [MaritalStatusName]) VALUES (3, N'Divorce')
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[Role] OFF
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------