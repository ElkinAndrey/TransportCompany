CREATE FUNCTION GetMileageByTransportId (
	@transportId BIGINT,
	@start DATETIME = '',
	@end DATETIME = ''
)
RETURNS @TL TABLE(
	[miliage]   INT NOT NULL
)
AS
BEGIN
	WITH [table] AS (
		SELECT *
		FROM [mileage]
		WHERE 
			(@transportId = [mileage].[transport_id]) AND
			(@start = '' OR CONVERT(DATETIME, @start) <= [mileage].[date]) AND
			(@end = '' OR CONVERT(DATETIME, @end) >= [mileage].[date])
	)

	INSERT INTO @TL
	SELECT	ISNULL(
				MAX ([mileage].[fixed_mileage]) -
				MIN ([mileage].[fixed_mileage])
			, 0) AS [mileage]
	FROM [table] AS [mileage]
	WHERE [mileage].[date] = ( 
		SELECT MAX([mileage2].[date])
		FROM [table] AS [mileage2]
		WHERE [mileage].[transport_id] = [mileage2].[transport_id]
	) OR [mileage].[date] = ( 
		SELECT MIN([mileage2].[date])
		FROM [table] AS [mileage2]
		WHERE [mileage].[transport_id] = [mileage2].[transport_id]
	)
	RETURN
END;