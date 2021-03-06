﻿CREATE TABLE [dbo].[usage_type]
(
	[usage_type_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [usage_type_description] VARCHAR(50) NOT NULL, 
	[active] BIT NULL DEFAULT(1),
    [create_ts] DATETIME NULL DEFAULT GETDATE(), 
    [update_ts] DATETIME NULL
)
