CREATE PROCEDURE [dbo].[statistics_campaign_types_report]
	@start date,
	@end date
AS
	declare @start_date date = coalesce(@start, '1970-01-01');
	declare @end_date date = coalesce(@end, dateadd(d, 1, getdate()));

	select
		ct.campaign_type_description [description],
		count(campaign_id) [upload_count]
	from campaign c
	inner join campaign_type ct on c.campaign_type_id = ct.campaign_type_id
	where c.create_ts >= @start_date
	  and c.create_ts <= @end_date  
	group by ct.campaign_type_description

