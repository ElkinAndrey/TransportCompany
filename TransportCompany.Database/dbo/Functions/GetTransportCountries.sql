CREATE FUNCTION GetTransportCountries ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[country].[country_id] AS [country_id],
		[country].[country_code] AS [country_code],
		[country].[deciphering_country] AS [deciphering_country]
	FROM 
		[country]
);