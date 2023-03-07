CREATE FUNCTION GetPersonPositions ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[person_position].[person_position_id] AS [position_id],
		[person_position].[name] AS [name]
	FROM 
		[person_position]
);