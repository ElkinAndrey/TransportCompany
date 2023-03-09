CREATE FUNCTION GetBrigadeById (
	@brigadeId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[brigade].[brigade_id]					AS [brigade_id],
		[brigade].[brigade_name]				AS [brigade_name],

		[brigade].[foreman_id]					AS [foreman_id],
		[brigade].[foreman_name]				AS [foreman_name],
		[brigade].[foreman_surname]				AS [foreman_surname],
		[brigade].[foreman_patronymic]			AS [foreman_patronymic],
		[brigade].[foreman_start]				AS [foreman_start],
		[brigade].[foreman_end]					AS [foreman_end],
		[brigade].[foreman_position]			AS [foreman_position],

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
		SELECT 
			[brigade].[brigade_id]		AS [brigade_id],
			[brigade].[name]			AS [brigade_name],

			[person].[person_id]		AS [foreman_id],
			[person].[name]				AS [foreman_name],
			[person].[surname]			AS [foreman_surname],
			[person].[patronymic]		AS [foreman_patronymic],
			[person].[start]			AS [foreman_start],
			[person].[end]				AS [foreman_end],
			[person_position].[name]	AS [foreman_position],
			
			[brigade].[workshop_id]		AS [workshop_id]
		FROM (
			SELECT * 
			FROM [brigade]
			WHERE @brigadeId = [brigade].[brigade_id]
		) AS [brigade]
		LEFT JOIN [person] ON 
			[brigade].[foreman_id]=[person].[person_id]
		LEFT JOIN [person_position] ON 
			[person_position].[person_position_id]=[person].[person_position_id]
	) AS [brigade]
	LEFT JOIN [workshop] ON 
		[workshop].[workshop_id]=[brigade].[workshop_id]
	LEFT JOIN [person] ON 
		[workshop].[master_id]=[person].[person_id]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
	LEFT JOIN [garage_facility] ON 
		[garage_facility].[garage_facility_id]=[workshop].[garage_facility_id]
	LEFT JOIN [garage_facility_category] ON 
		[garage_facility].[garage_facility_category_id]=[garage_facility_category].[garage_facility_category_id]
);