CREATE FUNCTION GetTransportById (
	@transportId BIGINT
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
		WHERE @transportId = [transport].[transport_id]
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
);