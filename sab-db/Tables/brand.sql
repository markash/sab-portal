CREATE TABLE [dbo].[brand]
(
	[brand_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [brand_description] VARCHAR(50) NOT NULL, 
	[active] BIT NULL DEFAULT(1),
    [create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
