ALTER TABLE [dbo].[campaign]
	ADD CONSTRAINT [campaign_category_fk]
	FOREIGN KEY (category_id)
	REFERENCES [category] (category_id)
