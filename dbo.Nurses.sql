CREATE TABLE [dbo].[Nurses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (MAX) NULL,	
    [LastName] NVARCHAR(MAX) NULL, 
    [Email]       NVARCHAR (MAX) NOT NULL,
    [WorkTypesId] INT            NULL,
    [HoursWorked] INT            NULL,
    CONSTRAINT [PK_dbo.Nurses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Nurses_dbo.WorkTypes_WorkTypesId] FOREIGN KEY ([WorkTypesId]) REFERENCES [dbo].[WorkTypes] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_WorkTypesId]
    ON [dbo].[Nurses]([WorkTypesId] ASC);

