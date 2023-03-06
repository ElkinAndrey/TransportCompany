CREATE TABLE [dbo].[person_person_property] (
    [person_property_id] BIGINT         NOT NULL,
    [person_id]          BIGINT         NOT NULL,
    [content]            NVARCHAR (MAX) DEFAULT ('') NULL,
    PRIMARY KEY CLUSTERED ([person_property_id] ASC, [person_id] ASC),
    FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([person_id]) ON DELETE CASCADE,
    FOREIGN KEY ([person_property_id]) REFERENCES [dbo].[person_property] ([person_property_id]) ON DELETE CASCADE
);

