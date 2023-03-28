CREATE TABLE [dbo].[repair_person_detail_action] (
    [repair_id] BIGINT   NOT NULL,
    [person_id] BIGINT   NOT NULL,
    [detail_id] SMALLINT NOT NULL,
    [action_id] SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([repair_id] ASC, [person_id] ASC, [detail_id] ASC),
    FOREIGN KEY ([detail_id]) REFERENCES [dbo].[detail] ([detail_id]) ON DELETE CASCADE,
    FOREIGN KEY ([person_id]) REFERENCES [dbo].[person] ([person_id]) ON DELETE CASCADE,
    FOREIGN KEY ([repair_id]) REFERENCES [dbo].[repair] ([repair_id]) ON DELETE CASCADE
);

