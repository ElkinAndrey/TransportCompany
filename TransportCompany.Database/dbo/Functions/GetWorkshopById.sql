CREATE FUNCTION GetWorkshopById (
	@workshopId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[workshop].[workshop_id]				AS [workshop_id],
		[workshop].[workshop_name]				AS [workshop_name],

		[workshop].[master_id]					AS [master_id],
		[workshop].[master_name]				AS [master_name],
		[workshop].[master_surname]				AS [master_surname],
		[workshop].[master_patronymic]			AS [master_patronymic],
		[workshop].[master_start]				AS [master_start],
		[workshop].[master_end]					AS [master_end],
		[workshop].[master_position]			AS [master_position],

		[workshop].[garage_facility_id]			AS [garage_facility_id],
		[workshop].[garage_facility_address]	AS [garage_facility_address],
		[workshop].[garage_facility_category]	AS [garage_facility_category],

		[region].[region_id]					AS [region_id], 
		[region].[name]							AS [region_name],
		
		[person].[person_id]					AS [region_chief_id],
		[person].[name]							AS [region_chief_name],
		[person].[surname]						AS [region_chief_surname],
		[person].[patronymic]					AS [region_chief_patronymic],
		[person].[start]						AS [region_chief_start],
		[person].[end]							AS [region_chief_end],
		[person_position].[name]				AS [region_chief_position]
	FROM (
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
			[garage_facility_category].[name]		AS [garage_facility_category],

			[workshop].[region_id]					AS [region_id]
		FROM (
			SELECT * 
			FROM [workshop]
			WHERE 
				@workshopId = [workshop].[workshop_id]
		) AS [workshop]
		LEFT JOIN [person] ON 
			[workshop].[master_id]=[person].[person_id]
		LEFT JOIN [person_position] ON 
			[person].[person_position_id]=[person_position].[person_position_id]
		LEFT JOIN [garage_facility] ON 
			[garage_facility].[garage_facility_id]=[workshop].[garage_facility_id]
		LEFT JOIN [garage_facility_category] ON 
			[garage_facility].[garage_facility_category_id]=[garage_facility_category].[garage_facility_category_id]
	) AS [workshop]
	LEFT JOIN [region] ON 
		[region].[region_id]=[workshop].[region_id]
	LEFT JOIN [person] ON 
		[person].[person_id]=[region].[region_chief_id]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
);