CREATE TABLE [dbo].[transport] (
    [transport_id] BIGINT        NOT NULL,
    [series]       NVARCHAR (10) NOT NULL,
    [number]       NVARCHAR (10) NOT NULL,
    [region_code]  NVARCHAR (10) NOT NULL,
    [start]        DATETIME      NOT NULL,
    [end]          DATETIME      NOT NULL,
    [mileage]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_id] ASC)
);

