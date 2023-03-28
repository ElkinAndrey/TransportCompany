CREATE FUNCTION GetRepairByPersonIdAndTransportId (
	@personId BIGINT,	
	@transportId BIGINT,	
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = ''
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[detail].[name]			AS [detail],
		[action].[name]			AS [action],

		[repair].[repair_id]	AS [repair_id],
		[repair].[price]		AS [repair_full_price],
		[repair].[start]		AS [repair_start],
		[repair].[end]			AS [repair_end]
	FROM (
		SELECT 
			[repair].[repair_id]						AS [repair_id],
			[repair_person_detail_action].[detail_id]	AS [detail_id],
			[repair_person_detail_action].[action_id]	AS [action_id],
			[repair].[transport_id]						AS [transport_id],
			[repair].[price]							AS [price],
			[repair].[start]							AS [start],
			[repair].[end]								AS [end]
		FROM (
			SELECT * 
			FROM [repair_person_detail_action]
			WHERE [repair_person_detail_action].[person_id] = @personId
		) AS [repair_person_detail_action]
		LEFT JOIN [repair] ON
			[repair].[repair_id] = [repair_person_detail_action].[repair_id]
		WHERE 
			([repair].[transport_id] = @transportId)							AND
			(@start = ''	OR	CONVERT(DATETIME, @start) <= [repair].[end])	AND
			(@end = ''		OR	CONVERT(DATETIME, @end) >= [repair].[end])
	) AS [repair]
	LEFT JOIN [action] ON
		[action].[action_id] = [repair].[action_id]
	LEFT JOIN [detail] ON
		[detail].[detail_id] = [repair].[detail_id]
);