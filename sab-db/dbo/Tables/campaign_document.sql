CREATE TABLE [dbo].[campaign_document]
(
	[id] [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE DEFAULT NEWID(), 
	[document] VARBINARY(MAX) NULL,
	[content_length] INT NULL,
	[content_type] VARCHAR(255) NOT NULL,
	[file_name] VARCHAR(512) NOT NULL,
	[campaign_id] INT NOT NULL
)
