CREATE TABLE [dbo].[person_position_person_property] (
    [person_property_id] BIGINT   NOT NULL,
    [person_position_id] SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([person_property_id] ASC, [person_position_id] ASC),
    FOREIGN KEY ([person_position_id]) REFERENCES [dbo].[person_position] ([person_position_id]) ON DELETE CASCADE,
    FOREIGN KEY ([person_property_id]) REFERENCES [dbo].[person_property] ([person_property_id]) ON DELETE CASCADE
);

