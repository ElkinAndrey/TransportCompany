CREATE FUNCTION GetRepairInformationByBrandId (
	@brandId BIGINT = 0,
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = ''
)
RETURNS TABLE
AS
RETURN
(		
	SELECT 
		COUNT_BIG ([repair].[repair_id]) AS [count],
		ISNULL(SUM ([repair].[price]), 0) AS [price]
	FROM (
		SELECT * 
		FROM [transport]
		WHERE @brandId = 0 OR [transport].[brand_id] = @brandId
	) AS [transport]
	INNER JOIN [repair] ON
		[repair].[transport_id] = [transport].[transport_id]
	WHERE 
		(@start = ''	OR	CONVERT(DATETIME, @start) <= [repair].[end])	AND		
		(@end = ''		OR	CONVERT(DATETIME, @end) >= [repair].[end])
);