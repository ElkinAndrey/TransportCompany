CREATE FUNCTION GetGarageFacilityCountByCategoryId (
	@categoryId SMALLINT = 0
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[name],
		[count]
	FROM (
		SELECT 
			[garage_facility].[garage_facility_category_id],
			COUNT(*) AS [count]
		FROM (
			SELECT DISTINCT 
				[workshop].[workshop_id],
				[garage_facility].[garage_facility_category_id]
			FROM (
				SELECT * 
				FROM [transport]
				WHERE 
					(@categoryId = 0 OR [transport_category_id] = @categoryId)
			) AS [transport]
			LEFT JOIN [brigade] ON 
				[transport].[brigade_id] = [brigade].[brigade_id]
			LEFT JOIN [workshop] ON 
				[workshop].[workshop_id] = [brigade].[workshop_id]
			LEFT JOIN [garage_facility] ON 
				[workshop].[garage_facility_id] = [garage_facility].[garage_facility_id]
		) AS [garage_facility]
		GROUP BY [garage_facility_category_id] 
	) AS [garage_facility]
	LEFT JOIN [garage_facility_category]
		ON [garage_facility].[garage_facility_category_id] = [garage_facility_category].[garage_facility_category_id]
);