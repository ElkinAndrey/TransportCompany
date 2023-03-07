CREATE FUNCTION GetPropertyByPersonId (
	@personId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[person_property].[name],
		[person_person_property].[content]
	FROM (
		SELECT * 
		FROM [person_person_property] 
		WHERE [person_id] = @personId
	) AS [person_person_property]
	LEFT JOIN [person_property] ON 
		[person_person_property].[person_property_id]=[person_property].[person_property_id]
);