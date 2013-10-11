ALTER TABLE [dbo].[campaign]
	ADD CONSTRAINT [campaign_territory_fk]
	FOREIGN KEY (territory_id)
	REFERENCES [territory] (territory_id)
