CREATE PROCEDURE [dbo].[upload_report]
	@start date,
	@end date
AS
	declare @start_date date = coalesce(@start, '1970-01-01');
	declare @end_date date = coalesce(@end, dateadd(d, 1, getdate()));

	select 
		u.username, 
		'' [country],
		count(*) [upload_count]
	from usage u
	where u.active = 1
	  and u.usage_type_id = 2
	  and u.create_ts >= @start_date
	  and u.create_ts <= @end_date 
	group by username

