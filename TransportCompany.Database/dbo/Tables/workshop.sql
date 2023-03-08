CREATE TABLE [dbo].[workshop] (
    [workshop_id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [region_id]          BIGINT         NOT NULL,
    [master_id]          BIGINT         NOT NULL,
    [garage_facility_id] BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([workshop_id] ASC),
    FOREIGN KEY ([garage_facility_id]) REFERENCES [dbo].[garage_facility] ([garage_facility_id]) ON DELETE CASCADE,
    FOREIGN KEY ([region_id]) REFERENCES [dbo].[region] ([region_id]) ON DELETE CASCADE
);

