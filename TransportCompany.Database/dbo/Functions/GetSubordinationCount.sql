CREATE FUNCTION dbo.GetSubordinationCount(
	@regionId BIGINT = 0,
	@workshopId BIGINT = 0,
	@brigadeId BIGINT = 0
)
RETURNS @TL TABLE(
	[region_count]   BIGINT NULL,
    [workshop_count] BIGINT NULL,
    [brigade_count]  BIGINT NULL,
    [person_count]   BIGINT NULL
)
AS
BEGIN
	DECLARE @regionCount BIGINT = NULL;
	DECLARE @workshopCount BIGINT = NULL;
	DECLARE @brigadeCount BIGINT = NULL;
	DECLARE @personCount BIGINT = NULL;

	IF @brigadeId != 0
	BEGIN
		SELECT @personCount = (
			SELECT COUNT(*) 
			FROM [person]
			WHERE 
				@brigadeId = [person].[brigade_id]
		)
	END
	ELSE IF @workshopId != 0
	BEGIN
		SELECT @brigadeCount = (
			SELECT COUNT(*) 
			FROM [brigade]
			WHERE 
				@workshopId = [brigade].[workshop_id]
		);
		SELECT @personCount = (
			SELECT COUNT([person].[person_id])
			FROM ( 
				SELECT * 
				FROM [workshop]
				WHERE [workshop_id] = @workshopId
			) AS [workshop]
			LEFT JOIN [brigade] ON
				[workshop].[workshop_id] = [brigade].[workshop_id]
			LEFT JOIN [Person] ON
				[brigade].[brigade_id] = [person].[brigade_id]
		);
	END
	ELSE IF @regionId != 0
	BEGIN
		SELECT @workshopCount = (
			SELECT COUNT(*) 
			FROM [workshop]
			WHERE 
				@regionId = [workshop].[region_id]
		);
		SELECT @brigadeCount = (
			SELECT COUNT([brigade].[brigade_id])
			FROM ( 
				SELECT * 
				FROM [region]
				WHERE [region_id] = @regionId
			) AS [region]
			LEFT JOIN [workshop] ON
				[region].[region_id] = [workshop].[region_id]
			LEFT JOIN [brigade] ON
				[workshop].[workshop_id] = [brigade].[workshop_id]
		);
		SELECT @personCount = (
			SELECT COUNT([person].[person_id])
			FROM ( 
				SELECT * 
				FROM [region]
				WHERE [region_id] = @regionId
			) AS [region]
			LEFT JOIN [workshop] ON
				[region].[region_id] = [workshop].[region_id]
			LEFT JOIN [brigade] ON
				[workshop].[workshop_id] = [brigade].[workshop_id]
			LEFT JOIN [person] ON
				[brigade].[brigade_id] = [person].[brigade_id]
		);
	END
	ELSE
	BEGIN
		SELECT @regionCount = (
			SELECT COUNT(*) 
			FROM [region]
		);
		SELECT @workshopCount = (
			SELECT COUNT([region_id]) 
			FROM [workshop]
		);
		SELECT @brigadeCount = (
			SELECT COUNT([workshop_id]) 
			FROM [brigade]
		);
		SELECT @personCount = (
			SELECT COUNT([brigade_id]) 
			FROM [person]
		);
	END

	INSERT INTO @TL ([region_count], [workshop_count], [brigade_count], [person_count]) 
	VALUES (@regionCount, @workshopCount, @brigadeCount, @personCount)
	RETURN
END;