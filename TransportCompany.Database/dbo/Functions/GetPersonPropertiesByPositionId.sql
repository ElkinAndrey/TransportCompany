CREATE FUNCTION GetPersonPropertiesByPositionId (
	@positionId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		[person_property].[person_property_id] AS [property_id],
		[person_property].[name] AS [name],
		[person_property].[translation] AS [translation],
		[data_type].[name] AS [type]	
	FROM (
		SELECT *
		FROM [person_position_person_property]
		WHERE [person_position_person_property].[person_position_id] = @positionId 
	) AS [person_position_person_property]
	LEFT JOIN [person_property] ON
		[person_position_person_property].[person_property_id] = [person_property].[person_property_id]
	LEFT JOIN [data_type] ON
		[data_type].[data_type_id] = [person_property].[data_type_id]
);