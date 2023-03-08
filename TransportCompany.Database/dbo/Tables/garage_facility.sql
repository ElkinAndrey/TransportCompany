CREATE TABLE [dbo].[garage_facility] (
    [garage_facility_id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [address]                     NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [garage_facility_category_id] SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([garage_facility_id] ASC),
    FOREIGN KEY ([garage_facility_category_id]) REFERENCES [dbo].[garage_facility_category] ([garage_facility_category_id]) ON DELETE CASCADE
);



