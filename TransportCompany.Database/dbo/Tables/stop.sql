CREATE TABLE [dbo].[stop] (
    [stop_id]  BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [location] NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([stop_id] ASC)
);

