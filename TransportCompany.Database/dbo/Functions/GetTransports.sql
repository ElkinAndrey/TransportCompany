CREATE FUNCTION GetTransports (
	@offset BIGINT,
	@length BIGINT,
	@series NVARCHAR(MAX) = '',
	@number NVARCHAR(MAX) = '',
	@regionCode NVARCHAR(MAX) = '',
	@transportCountryId SMALLINT = 0,
	@transportCategoryId SMALLINT = 0,
	@startBuy NVARCHAR(MAX) = '',
	@endBuy NVARCHAR(MAX) = '',
	@startWriteOff NVARCHAR(MAX) = '',
	@endWriteOff NVARCHAR(MAX) = '',
	@brigadeId BIGINT = 0
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[transport].[transport_id],
		[transport_category].[name] AS [category],
		[transport].[series],
		[transport].[number],
		[transport].[region_code],
		[country].[country_code],
		[country].[deciphering_country],
		[transport].[start],
		[transport].[end],
		[transport].[mileage],
		[brand_company].[name] AS [manufacturer_company],
		[brand_model].[name] AS [transport_model], 
		[brand].[year_publishing]
	FROM (
		SELECT * 
		FROM [transport] 
		WHERE 
			(@series = ''				OR	[series] like '%' + @series + '%')				AND
			(@number = ''				OR	[number] like '%' + @number + '%')				AND
			(@regionCode = ''			OR	[region_code] like '%' + @regionCode + '%')		AND
			(@transportCategoryId = 0	OR	@transportCategoryId = [transport_category_id])	AND
			(@transportCountryId = 0	OR	@transportCountryId = [country_id])				AND
			(@startBuy = ''				OR	CONVERT(DATETIME, @startBuy) <= [start])		AND
			(@endBuy = ''				OR	CONVERT(DATETIME, @endBuy) >= [start])			AND			
			(@startWriteOff = ''		OR	CONVERT(DATETIME, @startWriteOff) <= [end])		AND
			(@endWriteOff = ''			OR	CONVERT(DATETIME, @endWriteOff) >= [end])		AND
			(@brigadeId = 0				OR	@brigadeId = [brigade_id])
	) AS [transport]
	LEFT JOIN [brand] ON 
		[transport].[brand_id]=[brand].[brand_id]
	LEFT JOIN [brand_model] ON 
		[brand].[brand_model_id]=[brand_model].[brand_model_id]
	LEFT JOIN [brand_company] ON 
		[brand_model].[brand_company_id]=[brand_company].[brand_company_id]
	LEFT JOIN [country] ON 
		[transport].[country_id]=[country].[country_id]
	LEFT JOIN [transport_category] ON 
		[transport].[transport_category_id]=[transport_category].[transport_category_id]
	ORDER BY [transport_id]
	OFFSET @offset ROW FETCH NEXT @length ROWS ONLY
);