CREATE FUNCTION GetTransportYearByModelId (
	@modelId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[brand].[brand_id] AS [brand_id],
		[brand].[year_publishing]
	FROM 
		[brand]
	WHERE 
		[brand].[brand_model_id] = @modelId
);