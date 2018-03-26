CREATE TABLE [dbo].[Book]
(
	[isbn] INT NOT NULL PRIMARY KEY IDENTITY (0, 1),
	[title] NCHAR(25) NULL, 
    [author] NCHAR(25) NULL, 
    [stock] INT NULL, 
    [editor] NCHAR(25) NULL
)
