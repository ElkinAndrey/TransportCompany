﻿
CREATE FUNCTION GetDetailsByTransportId (
	@transportId SMALLINT = 0,
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = '',
	@details [smallint_list] READONLY
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[detail].[name] AS [name],
		[delail_count].[count] AS [count]
	FROM (
		SELECT 
			[repair_person_detail_action].[detail_id],
			COUNT_BIG(*) AS [count]

		FROM (
			SELECT [repair].[repair_id]
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
		) AS [repair]
		INNER JOIN [repair_person_detail_action] ON 
			[repair_person_detail_action].[repair_id] = [repair].[repair_id]
		WHERE [repair_person_detail_action].[detail_id] IN (SELECT [smallint] FROM @details)
		GROUP BY [repair_person_detail_action].[detail_id]
	) AS [delail_count]
	LEFT JOIN [detail] ON
		[detail].[detail_id] = [delail_count].[detail_id]
);