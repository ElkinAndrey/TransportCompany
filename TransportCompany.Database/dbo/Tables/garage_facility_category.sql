CREATE TABLE [dbo].[garage_facility_category] (
    [garage_facility_category_id] BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]                        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([garage_facility_category_id] ASC)
);

