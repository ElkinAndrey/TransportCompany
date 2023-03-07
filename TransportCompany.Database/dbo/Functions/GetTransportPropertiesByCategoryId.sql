CREATE FUNCTION GetTransportPropertiesByCategoryId (
	@categoryId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		[transport_property].[transport_property_id] AS [property_id],
		[transport_property].[name] AS [name],
		[transport_property].[translation] AS [translation],
		[data_type].[name] AS [type]	
	FROM (
		SELECT *
		FROM [transport_category_transport_property]
		WHERE [transport_category_transport_property].[transport_category_id] = @categoryId 
	) AS [transport_category_transport_property]
	LEFT JOIN [transport_property] ON
		[transport_category_transport_property].[transport_property_id] = [transport_property].[transport_property_id]
	LEFT JOIN [data_type] ON
		[data_type].[data_type_id] = [transport_property].[data_type_id]
);