CREATE FUNCTION GetBrigadeByForemanId (
	@foremanId BIGINT
)
RETURNS TABLE
AS
RETURN
(		
	SELECT 
		[brigade].[brigade_id] AS [brigade_id],
		[brigade].[name] AS [brigade_name]
	FROM [brigade]
	WHERE @foremanId = [brigade].[foreman_id]
);