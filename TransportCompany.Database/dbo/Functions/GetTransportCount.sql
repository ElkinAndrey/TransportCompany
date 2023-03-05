CREATE FUNCTION GetTransportCount ()
RETURNS @TL TABLE(
	[count]   BIGINT NOT NULL
)
AS
BEGIN
	DECLARE @count BIGINT;

	SET @count = (
		SELECT COUNT([transport].[transport_id])
		FROM [transport]
	)

	INSERT INTO @TL ([count]) 
	VALUES (@count)
	RETURN
END;