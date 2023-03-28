CREATE FUNCTION GetRepairInformationByCategoryId (
	@categoryId SMALLINT = 0,
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
		SELECT [transport].[transport_id]
		FROM [transport]
		WHERE (@categoryId = 0 OR [transport].[transport_category_id] = @categoryId)
	) AS [transport]
	INNER JOIN [repair] ON
		[repair].[transport_id] = [transport].[transport_id]
	WHERE 
		(@start = ''	OR	CONVERT(DATETIME, @start) <= [end])	AND		
		(@end = ''		OR	CONVERT(DATETIME, @end) >= [end])
);