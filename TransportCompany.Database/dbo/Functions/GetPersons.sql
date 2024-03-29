﻿CREATE FUNCTION GetPersons (
	@offset BIGINT,
	@length BIGINT,
	@name NVARCHAR(MAX) = '',
	@surname NVARCHAR(MAX) = '',
	@patronymic NVARCHAR(MAX) = '',
	@personPosition NVARCHAR(MAX) = 0,
	@startHireDate NVARCHAR(MAX) = '',
	@endHireDate NVARCHAR(MAX) = '',
	@startDismissalDate NVARCHAR(MAX) = '',
	@endDismissalDate NVARCHAR(MAX) = '',
	@brigadeId BIGINT = 0,
	@transportId BIGINT = 0
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		[person].[person_id],
		[person].[name],
		[person].[surname],
		[person].[patronymic],
		[person].[start],
		[person].[end],
		[person_position].[name] AS [position]
	FROM (
		SELECT * 
		FROM [person] 
		WHERE 
			(@name = ''					OR	[name] like '%' + @name + '%')								AND
			(@surname = ''				OR	[surname] like '%' + @surname + '%')						AND
			(@patronymic = ''			OR	[patronymic] like '%' + @patronymic + '%')					AND
			(@personPosition = 0		OR	@personPosition = [person_position_id])						AND
			(@startHireDate = ''		OR	CONVERT(DATETIME, @startHireDate) <= [start])				AND
			(@endHireDate = ''			OR	CONVERT(DATETIME, @endHireDate) >= [start])					AND			
			(@startDismissalDate = ''	OR	CONVERT(DATETIME, @startDismissalDate) <= [end])			AND
			(@endDismissalDate = ''		OR	CONVERT(DATETIME, @endDismissalDate) >= [end])				AND
			(@brigadeId = 0				OR	@brigadeId = [brigade_id])									AND
			(@transportId = 0			OR	EXISTS(
												SELECT [person_id] 
												FROM [transport_person] 
												WHERE 
													[transport_person].[transport_id] = @transportId AND 
													[person].[person_id] = [transport_person].[person_id]
											)
			)
	) AS [person]
	LEFT JOIN [person_position] ON 
		[person].[person_position_id]=[person_position].[person_position_id]
	ORDER BY [person_id]
	OFFSET @offset ROW FETCH NEXT @length ROWS ONLY
);