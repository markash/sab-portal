CREATE TABLE [dbo].[campaign]
(
	[campaign_id] INT NOT NULL PRIMARY KEY IDENTITY,
	[category_id] INT NOT NULL DEFAULT(0),
	[territory_id] INT NOT NULL,
	[campaign_type_id] INT NOT NULL,
	[country_id] INT NOT NULL,
	[brand_id] INT NOT NULL,
	[title] VARCHAR(255) NOT NULL,
	[username] VARCHAR(255) NOT NULL,
	[email] VARCHAR(255) NOT NULL,
	[create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
