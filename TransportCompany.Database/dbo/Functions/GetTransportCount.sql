CREATE FUNCTION GetTransportCount (
	@series NVARCHAR(MAX) = '',
	@number NVARCHAR(MAX) = '',
	@regionCode NVARCHAR(MAX) = '',
	@transportCountryId SMALLINT = 0,
	@transportCategoryId SMALLINT = 0,
	@startBuy NVARCHAR(MAX) = '',
	@endBuy NVARCHAR(MAX) = '',
	@startWriteOff NVARCHAR(MAX) = '',
	@endWriteOff NVARCHAR(MAX) = ''
)
RETURNS @TL TABLE(
	[count]   BIGINT NOT NULL
)
AS
BEGIN
	DECLARE @count BIGINT;

	SET @count = (
		SELECT COUNT([transport].[transport_id])
		FROM [transport]
		WHERE 
			(@series = ''				OR	[series] like '%' + @series + '%')				AND
			(@number = ''				OR	[number] like '%' + @number + '%')				AND
			(@regionCode = ''			OR	[region_code] like '%' + @regionCode + '%')		AND
			(@transportCategoryId = 0	OR	@transportCategoryId = [transport_category_id])	AND
			(@transportCountryId = 0	OR	@transportCountryId = [country_id])		AND
			(@startBuy = ''				OR	CONVERT(DATETIME, @startBuy) <= [start])		AND
			(@endBuy = ''				OR	CONVERT(DATETIME, @endBuy) >= [start])			AND			
			(@startWriteOff = ''		OR	CONVERT(DATETIME, @startWriteOff) <= [end])AND
			(@endWriteOff = ''			OR	CONVERT(DATETIME, @endWriteOff) >= [end])
	)

	INSERT INTO @TL ([count]) 
	VALUES (@count)
	RETURN
END;