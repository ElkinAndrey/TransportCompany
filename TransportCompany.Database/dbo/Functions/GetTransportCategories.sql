CREATE FUNCTION GetTransportCategories ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[transport_category].[transport_category_id] AS [category_id],
		[transport_category].[name] AS [name]
	FROM 
		[transport_category]
);