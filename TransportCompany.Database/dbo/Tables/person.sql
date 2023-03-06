CREATE TABLE [dbo].[person] (
    [person_id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [surname]            NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [patronymic]         NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [start]              DATETIME       NOT NULL,
    [end]                DATETIME       NULL,
    [person_position_id] SMALLINT       NOT NULL,
    [country_id]         SMALLINT       NOT NULL,
    [brand_id]           BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([person_id] ASC),
    CHECK ([start]<[end]),
    FOREIGN KEY ([person_position_id]) REFERENCES [dbo].[person_position] ([person_position_id]) ON DELETE CASCADE
);

