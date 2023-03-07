CREATE FUNCTION GetPersonCount (
	@name NVARCHAR(MAX) = '',
	@surname NVARCHAR(MAX) = '',
	@patronymic NVARCHAR(MAX) = '',
	@personPosition NVARCHAR(MAX) = 0,
	@startHireDate NVARCHAR(MAX) = '',
	@endHireDate NVARCHAR(MAX) = '',
	@startDismissalDate NVARCHAR(MAX) = '',
	@endDismissalDate NVARCHAR(MAX) = ''
)
RETURNS @TL TABLE(
	[count]   BIGINT NOT NULL
)
AS
BEGIN
	DECLARE @count BIGINT;

	SET @count = (
		SELECT COUNT([person].[person_id])
		FROM [person] 
		WHERE 
			(@name = ''					OR	[name] like '%' + @name + '%')								AND
			(@surname = ''				OR	[surname] like '%' + @surname + '%')						AND
			(@patronymic = ''			OR	[patronymic] like '%' + @patronymic + '%')					AND
			(@personPosition = 0		OR	@personPosition = [person_position_id])						AND
			(@startHireDate = ''		OR	CONVERT(DATETIME, @startHireDate) <= [start])			AND
			(@endHireDate = ''			OR	CONVERT(DATETIME, @endHireDate) >= [start])				AND			
			(@startDismissalDate = ''	OR	CONVERT(DATETIME, @startDismissalDate) <= [end])	AND
			(@endDismissalDate = ''		OR	CONVERT(DATETIME, @endDismissalDate) >= [end])
	)

	INSERT INTO @TL ([count]) 
	VALUES (@count)
	RETURN
END;