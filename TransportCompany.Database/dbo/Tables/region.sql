CREATE TABLE [dbo].[region] (
    [region_id]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [region_chief_id] BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([region_id] ASC),
    FOREIGN KEY ([region_chief_id]) REFERENCES [dbo].[person] ([person_id])
);



