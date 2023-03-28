CREATE FUNCTION GetRepairByPersonId (
	@personId BIGINT,	
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = ''
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[detail].[name] AS [detail],
		[action].[name] AS [action],

		[repair].[repair_id] AS [repair_id],
		[repair].[price] AS [repair_full_price],
		[repair].[start] AS [repair_start],
		[repair].[end] AS [repair_end],

		[transport].[transport_id] AS [transport_id],
		[transport_category].[name] AS [transport_category],
		[transport].[series] AS [transport_series],
		[transport].[number] AS [transport_number],
		[transport].[region_code] AS [transport_region_code],
		[country].[country_code] AS [transport_country_code],
		[country].[deciphering_country] AS [transport_deciphering_country],
		[transport].[start] AS [transport_start],
		[transport].[end] AS [transport_end]
	FROM (
		SELECT 
			[repair].[repair_id] AS [repair_id],
			[repair_person_detail_action].[detail_id] AS [detail_id],
			[repair_person_detail_action].[action_id] AS [action_id],
			[repair].[transport_id] AS [transport_id],
			[repair].[price] AS [price],
			[repair].[start] AS [start],
			[repair].[end] AS [end]
		FROM (
			SELECT * 
			FROM [repair_person_detail_action]
			WHERE [repair_person_detail_action].[person_id] = @personId
		) AS [repair_person_detail_action]
		LEFT JOIN [repair] ON
			[repair].[repair_id] = [repair_person_detail_action].[repair_id]
		WHERE 
			(@start = ''				OR	CONVERT(DATETIME, @start) <= [repair].[end])		AND
			(@end = ''					OR	CONVERT(DATETIME, @end) >= [repair].[end])
	) AS [repair]
	LEFT JOIN [transport] ON
		[repair].[transport_id] = [transport].[transport_id]
	LEFT JOIN [action] ON
		[action].[action_id] = [repair].[action_id]
	LEFT JOIN [detail] ON
		[detail].[detail_id] = [repair].[detail_id]
	LEFT JOIN [transport_category] ON
		[transport].[transport_category_id] = [transport_category].[transport_category_id]
	LEFT JOIN [country] ON
		[transport].[country_id] = [country].[country_id]
);