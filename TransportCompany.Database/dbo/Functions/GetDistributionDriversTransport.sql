CREATE FUNCTION GetDistributionDriversTransport()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[transport].[transport_id],
		[transport].[series],
		[transport].[number],
		[transport].[region_code],
		[country].[country_code],
		[country].[deciphering_country],
		[person].[person_id],
		[person].[name],
		[person].[surname],
		[person].[patronymic]
	FROM [transport]
	RIGHT JOIN [transport_person] ON
		[transport].[transport_id] = [transport_person].[transport_id]
	LEFT JOIN [person] ON
		[person].[person_id] = [transport_person].[person_id]
	LEFT JOIN [country] ON 
		[transport].[country_id]=[country].[country_id]
	ORDER BY [transport].[transport_id] ASC
	OFFSET 0 ROWS
);