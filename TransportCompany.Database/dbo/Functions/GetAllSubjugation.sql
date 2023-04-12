CREATE FUNCTION GetAllSubjugation ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[region].[region_id] AS [region_id],
		[region].[name] AS [region_name],
		[workshop].[workshop_id] AS [workshop_id],
		[workshop].[name] AS [workshop_name],
		[brigade].[brigade_id] AS [brigade_id],
		[brigade].[name] AS [brigade_name],
		[person].[person_id] AS [person_id],
		[person].[name] AS [person_name],
		[person].[surname] AS [person_surname],
		[person].[patronymic] AS [person_patronymic]
	FROM [region]
	INNER JOIN [workshop] ON
		[workshop].[region_id] = [region].[region_id]
	INNER JOIN [brigade] ON
		[brigade].[workshop_id] = [workshop].[workshop_id]
	INNER JOIN [person] ON
		[person].[brigade_id] = [brigade].[brigade_id]
	ORDER BY [region].[region_id], [workshop].[workshop_id], [brigade].[brigade_id] ASC
	OFFSET 0 ROWS
);