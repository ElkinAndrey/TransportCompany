CREATE TABLE [dbo].[route] (
    [route_id] BIGINT         IDENTITY (1, 1) NOT NULL,
    [number]   NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([route_id] ASC)
);

