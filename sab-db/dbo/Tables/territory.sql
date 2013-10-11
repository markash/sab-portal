CREATE TABLE [dbo].[territory]
(
	[territory_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [territory_description] VARCHAR(50) NOT NULL, 
	[active] BIT NULL DEFAULT(1),
    [create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
