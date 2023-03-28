CREATE FUNCTION GetMileageByCategoryId (
	@categoryId BIGINT = 0,
	@start DATETIME = '',
	@end DATETIME = ''
)
RETURNS @TL TABLE(
	[mileage]   BIGINT NOT NULL
)
AS
BEGIN
	WITH [table] AS (
		SELECT 
			[mileage].[mileage_id],
			[mileage].[fixed_mileage],
			[mileage].[date],
			[mileage].[transport_id]
		FROM (
			SELECT *
			FROM [transport]
			WHERE (@categoryId = 0 OR [transport].[transport_category_id] = @categoryId)
		) AS [transport]
		INNER JOIN [mileage] ON
			[mileage].[transport_id] = [transport].[transport_id] AND
			(@start = '' OR CONVERT(DATETIME, @start) <= [mileage].[date]) AND
			(@end = '' OR CONVERT(DATETIME, @end) >= [mileage].[date])
	)

	INSERT INTO @TL ([mileage]) 
	SELECT	ISNULL(
				SUM ([mileageMax].[fixed_mileage]) + 
				SUM ([mileageMin].[fixed_mileage])
			, 0) AS [mileage]
	FROM (
		SELECT 
			[mileage].[mileage_id],
			[mileage].[fixed_mileage],
			[mileage].[date],
			[mileage].[transport_id]
		FROM [table] AS [mileage]
		WHERE [mileage].[date] = ( 
			SELECT MAX([mileage2].[date])
			FROM [table] [mileage2]
			WHERE [mileage].[transport_id] = [mileage2].[transport_id]
		)
	)
	AS [mileageMax]
	INNER JOIN (
		SELECT 
			[mileage].[mileage_id],
			-[mileage].[fixed_mileage] AS [fixed_mileage],
			[mileage].[date],
			[mileage].[transport_id]
		FROM [table] AS [mileage]
		WHERE [mileage].[date] = ( 
			SELECT MIN([mileage2].[date])
			FROM [table] [mileage2]
			WHERE [mileage].[transport_id] = [mileage2].[transport_id]
		)
	) AS [mileageMin] ON
		[mileageMax].[transport_id] = [mileageMin].[transport_id]
	RETURN
END;