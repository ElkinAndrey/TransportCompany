CREATE FUNCTION GetRepairInformationByTransportId (
	@transportId BIGINT = 0,
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = ''
)
RETURNS TABLE
AS
RETURN
(		
	SELECT 
		COUNT ([repair].[repair_id]) AS [count],
		ISNULL(SUM ([repair].[price]), 0) AS [price]
	FROM (
		SELECT * 
		FROM [transport]
		WHERE @transportId = 0 OR [transport].[transport_id] = @transportId
	) AS [transport]
	INNER JOIN [repair] ON
		[repair].[transport_id] = [transport].[transport_id]
	WHERE 
		(@start = ''	OR	CONVERT(DATETIME, @start) <= [repair].[end])	AND		
		(@end = ''		OR	CONVERT(DATETIME, @end) >= [repair].[end])
);