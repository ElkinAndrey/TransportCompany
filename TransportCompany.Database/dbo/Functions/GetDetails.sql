CREATE FUNCTION GetDetails ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[detail].[detail_id] AS [detail_id],
		[detail].[name] AS [name]
	FROM 
		[detail]
);