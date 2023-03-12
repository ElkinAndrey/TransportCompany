CREATE FUNCTION GetCargoTransportations (
	@length BIGINT,
	@transportId NVARCHAR(MAX),
	@start NVARCHAR(MAX) = '',
	@end NVARCHAR(MAX) = ''
)
RETURNS TABLE
AS
RETURN
(
	SELECT TOP(@length)
		[cargo_transportation_id],
		[price],
		[additional_information],
		[start],
		[end]
	FROM [cargo_transportation]
	WHERE 
		(@transportId = [transport_id]) AND
		(@start = ''	OR	CONVERT(DATETIME, @start) <= [end])	AND		
		(@end = ''		OR	CONVERT(DATETIME, @end) >= [end])
);