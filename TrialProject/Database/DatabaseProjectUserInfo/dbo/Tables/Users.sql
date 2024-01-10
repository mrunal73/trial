CREATE TABLE [dbo].[Users] (
    [Username]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [Passwordhash] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);


GO

