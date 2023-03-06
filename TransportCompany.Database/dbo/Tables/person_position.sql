CREATE TABLE [dbo].[person_position] (
    [person_position_id] SMALLINT       NOT NULL,
    [name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([person_position_id] ASC)
);

