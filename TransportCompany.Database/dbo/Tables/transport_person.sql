CREATE TABLE [dbo].[transport_person] (
    [transport_id] BIGINT NOT NULL,
    [person_id]    BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_id] ASC, [person_id] ASC),
    FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([person_id]) ON DELETE CASCADE,
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id]) ON DELETE CASCADE
);

