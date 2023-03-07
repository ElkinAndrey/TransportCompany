CREATE TABLE [dbo].[person] (
    [person_id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [surname]            NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [patronymic]         NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [start]              DATETIME       NOT NULL,
    [end]                DATETIME       NULL,
    [person_position_id] SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([person_id] ASC),
    CHECK ([start]<[end]),
    FOREIGN KEY ([person_position_id]) REFERENCES [dbo].[person_position] ([person_position_id]) ON DELETE CASCADE
);






GO
CREATE TRIGGER AddPersonProperty
ON [person]
AFTER INSERT
AS
BEGIN
	DECLARE @personId BIGINT = (SELECT [person_id] FROM inserted)
	DECLARE @personPositionId BIGINT = (SELECT [person_position_id] FROM inserted)

	INSERT INTO [person_person_property] ([person_id], [person_property_id])
	SELECT
		[person_id] = @personId,
		[person_position_person_property].[person_property_id]
	FROM
		[person_position_person_property]
	WHERE 
		[person_position_person_property].[person_position_id] = @personPositionId
END