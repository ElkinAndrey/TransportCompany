CREATE FUNCTION GetPropertyByTransportId (
	@transportId NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[transport_property].[name],
		[transport_transport_property].[content]
	FROM (
		SELECT * 
		FROM [transport_transport_property] 
		WHERE [transport_id] = @transportId
	) AS [transport_transport_property]
	LEFT JOIN [transport_property] ON 
		[transport_transport_property].[transport_property_id]=[transport_property].[transport_property_id]
);