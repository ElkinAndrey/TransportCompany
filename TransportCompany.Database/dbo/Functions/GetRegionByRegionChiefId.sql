CREATE FUNCTION GetRegionByRegionChiefId (
	@regionChiefId BIGINT
)
RETURNS TABLE
AS
RETURN
(		
	SELECT 
		[region].[region_id] AS [region_id],
		[region].[name] AS [region_name]
	FROM [region]
	WHERE @regionChiefId = [region].[region_chief_id]
);