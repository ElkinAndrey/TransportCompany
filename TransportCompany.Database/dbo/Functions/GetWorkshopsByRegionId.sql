CREATE FUNCTION GetWorkshopsByRegionId (
	@regionId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[workshop].[workshop_id]				AS [workshop_id],
		[workshop].[name]						AS [workshop_name],

		[person].[person_id]					AS [master_id],
		[person].[name]							AS [master_name],
		[person].[surname]						AS [master_surname],
		[person].[patronymic]					AS [master_patronymic],
		[person].[start]						AS [master_start],
		[person].[end]							AS [master_end],
		[person_position].[name]				AS [master_position],

		[garage_facility].[garage_facility_id]	AS [garage_facility_id],
		[garage_facility].[address]				AS [garage_facility_address],
		[garage_facility_category].[name]		AS [garage_facility_category]
	FROM (
		SELECT * 
		FROM [workshop]
		WHERE 
			@regionId = [workshop].[region_id]
	) AS [workshop]
	LEFT JOIN [person] ON 
		[workshop].[master_id]=[person].[person_id]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
	LEFT JOIN [garage_facility] ON 
		[garage_facility].[garage_facility_id]=[workshop].[garage_facility_id]
	LEFT JOIN [garage_facility_category] ON 
		[garage_facility].[garage_facility_category_id]=[garage_facility_category].[garage_facility_category_id]
);