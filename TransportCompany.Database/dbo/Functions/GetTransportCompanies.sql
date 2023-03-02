CREATE FUNCTION GetTransportCompanies ()
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[brand_company_id] AS [company_id],
		[name]
	FROM 
		[brand_company]
);