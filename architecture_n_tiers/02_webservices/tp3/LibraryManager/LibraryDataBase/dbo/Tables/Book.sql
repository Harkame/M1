CREATE TABLE [dbo].[Book] (
    [isbn]   INT        IDENTITY (0, 1) NOT NULL,
    [title]  NCHAR (25) NULL,
    [author] NCHAR (25) NULL,
    [stock]  INT        NULL,
    [editor] NCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([isbn] ASC)
);

