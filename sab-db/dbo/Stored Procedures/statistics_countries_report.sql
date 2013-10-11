CREATE PROCEDURE [dbo].[statistics_countries_report]
	@start date,
	@end date
AS
	declare @start_date date = coalesce(@start, '1970-01-01');
	declare @end_date date = coalesce(@end, dateadd(d, 1, getdate()));

	select
		ct.country_description [description],
		count(campaign_id) [upload_count]
	from campaign c
	inner join country ct on c.country_id = ct.country_id
	where c.create_ts >= @start_date
	  and c.create_ts <= @end_date  
	group by ct.country_description

