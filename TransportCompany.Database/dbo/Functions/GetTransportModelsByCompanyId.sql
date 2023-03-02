CREATE FUNCTION GetTransportModelsByCompanyId (
	@companyId BIGINT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[brand_model].[brand_model_id] AS [model_id],
		[brand_model].[name]
	FROM 
		[brand_model]
	WHERE 
		[brand_model].[brand_company_id] = @companyId
);