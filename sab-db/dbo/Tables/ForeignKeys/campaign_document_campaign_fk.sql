ALTER TABLE [dbo].[campaign_document]
	ADD CONSTRAINT [campaign_document_campaign_fk]
	FOREIGN KEY (campaign_id)
	REFERENCES [campaign] (campaign_id)
