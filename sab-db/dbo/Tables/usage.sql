CREATE TABLE [dbo].[usage]
(
	[usage_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[username] VARCHAR(255) NOT NULL,
	[email] VARCHAR(255) NOT NULL,
	[usage_type_id] INT NOT NULL, 
	[active] BIT NULL DEFAULT(1),
	[create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
