CREATE TABLE [dbo].[category]
(
	[category_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [category_description] VARCHAR(50) NOT NULL, 
	[active] BIT NULL DEFAULT(1),
    [create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
