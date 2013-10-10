ALTER TABLE [dbo].[usage]
	ADD CONSTRAINT [usage_usage_type_fk]
	FOREIGN KEY (usage_type_id)
	REFERENCES [usage_type] (usage_type_id)
