ALTER TABLE [dbo].[campaign]
	ADD CONSTRAINT [campaign_campaign_type_fk]
	FOREIGN KEY (campaign_type_id)
	REFERENCES [campaign_type] (campaign_type_id)
