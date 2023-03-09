CREATE FUNCTION GetWorkshopByMasterId (
	@masterId BIGINT
)
RETURNS TABLE
AS
RETURN
(		
	SELECT 
		[workshop].[workshop_id] AS [workshop_id],
		[workshop].[name] AS [workshop_name]
	FROM [workshop]
	WHERE @masterId = [workshop].[master_id]
);