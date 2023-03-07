CREATE FUNCTION GetPersonById (
	@personId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[person].[person_id],
		[person].[name],
		[person].[surname],
		[person].[patronymic],
		[person].[start],
		[person].[end],
		[person_position].[name] AS [position],
		[person_position].[person_position_id] AS [position_id]
	FROM (
		SELECT * 
		FROM [person] 
		WHERE @personId = [person].[person_id]
	) AS [person]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
);