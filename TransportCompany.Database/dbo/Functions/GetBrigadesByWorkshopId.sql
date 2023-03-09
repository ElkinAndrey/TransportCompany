CREATE FUNCTION GetBrigadesByWorkshopId (
	@workshopId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[brigade].[brigade_id]		AS [brigade_id],
		[brigade].[name]			AS [brigade_name],

		[person].[person_id]		AS [foreman_id],
		[person].[name]				AS [foreman_name],
		[person].[surname]			AS [foreman_surname],
		[person].[patronymic]		AS [foreman_patronymic],
		[person].[start]			AS [foreman_start],
		[person].[end]				AS [foreman_end],
		[person_position].[name]	AS [foreman_position]
	FROM (
		SELECT * 
		FROM [brigade]
		WHERE @workshopId = [brigade].[workshop_id]
	) AS [brigade]
	LEFT JOIN [person] ON 
		[brigade].[foreman_id]=[person].[person_id]
	LEFT JOIN [person_position] ON 
		[person_position].[person_position_id]=[person].[person_position_id]
);