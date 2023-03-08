CREATE TABLE [dbo].[brigade] (
    [brigade_id]  BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [workshop_id] BIGINT         NOT NULL,
    [foreman_id]  BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([brigade_id] ASC),
    FOREIGN KEY ([foreman_id]) REFERENCES [dbo].[person] ([person_id]),
    FOREIGN KEY ([workshop_id]) REFERENCES [dbo].[workshop] ([workshop_id]) ON DELETE CASCADE
);

