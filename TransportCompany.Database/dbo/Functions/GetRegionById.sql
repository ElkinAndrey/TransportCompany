CREATE FUNCTION GetRegionById (
	@regionId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[region].[region_id]		AS [region_id],
		[region].[name]				AS [region_name],
		
		[person].[person_id]		AS [region_chief_id],
		[person].[name]				AS [region_chief_name],
		[person].[surname]			AS [region_chief_surname],
		[person].[patronymic]		AS [region_chief_patronymic],
		[person].[start]			AS [region_chief_start],
		[person].[end]				AS [region_chief_end],
		[person_position].[name]	AS [region_chief_position]
	FROM (
		SELECT *
		FROM [region]
		WHERE 
			@regionId = [region].[region_id]
	) AS [region]
	LEFT JOIN [person] ON 
		[person].[person_id]=[region].[region_chief_id]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
);