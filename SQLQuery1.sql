CREATE TABLE [dbo].[Events] (
    [Id]          INT                NOT NULL,
    [Name]        VARCHAR (30)       NOT NULL,
    [Description] VARCHAR (50)       NOT NULL,
    [Place]       VARCHAR (30)       NOT NULL,
    [Date]        DATETIME  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);