ALTER TABLE [dbo].[campaign]
	ADD CONSTRAINT [campaign_country_fk]
	FOREIGN KEY (country_id)
	REFERENCES [country] (country_id)
