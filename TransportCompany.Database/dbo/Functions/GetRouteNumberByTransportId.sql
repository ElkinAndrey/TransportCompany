CREATE FUNCTION GetRouteNumberByTransportId (
	@transportId BIGINT 
)
RETURNS TABLE
AS
RETURN
(
	SELECT [number] AS [route_number]
	FROM (
		SELECT TOP(1) [route_id]
		FROM [transport_route]
		WHERE [transport_route].[transport_id] = @transportId
	) AS [transport_route]
	LEFT JOIN [route] ON
		[route].[route_id] = [transport_route].[route_id]
);