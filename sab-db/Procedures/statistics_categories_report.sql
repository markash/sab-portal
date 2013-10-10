CREATE PROCEDURE [dbo].[statistics_categories_report]
	@start date,
	@end date
AS
	declare @start_date date = coalesce(@start, '1970-01-01');
	declare @end_date date = coalesce(@end, dateadd(d, 1, getdate()));

	select
		ct.category_description [description],
		count(campaign_id) [upload_count]
	from campaign c
	inner join category ct on c.campaign_type_id = ct.category_id
	where c.create_ts >= @start_date
	  and c.create_ts <= @end_date  
	group by ct.category_description

