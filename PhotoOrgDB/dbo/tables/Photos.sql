CREATE TABLE [dbo].[Photos]
(
    [id] int not null primary key IDENTITY,
    [path] NVARCHAR(250) NOT NULL, 
    [location] NVARCHAR(50) NOT NULL, 
    [dateTaken] DATETIME NOT NULL, 
    [people] NVARCHAR(50) NULL, 
    [imageName] NCHAR(50) NOT NULL
)
