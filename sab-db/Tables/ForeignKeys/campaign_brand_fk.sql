ALTER TABLE [dbo].[campaign]
	ADD CONSTRAINT [campaign_brand_fk]
	FOREIGN KEY (brand_id)
	REFERENCES [brand] (brand_id)
