CREATE FUNCTION GetRouteByTransportId (
	@transportId BIGINT 
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[stop].[name] AS [stop_name],
		[stop].[location] AS [stop_location]
	FROM (
		SELECT 
			[route].[route_id],
			[route_stop].[link_number],
			[route_stop].[stop_id]
		FROM (
			SELECT TOP(1) [route_id]
			FROM [transport_route]
			WHERE [transport_route].[transport_id] = @transportId
		) AS [route]
		LEFT JOIN [route_stop] ON
			[route_stop].[route_id] = [route].[route_id]
	) AS [route_stop]
	LEFT JOIN [stop] ON
		[stop].[stop_id] = [route_stop].[stop_id]
	ORDER BY [route_stop].[link_number] ASC
	OFFSET 0 ROWS
);