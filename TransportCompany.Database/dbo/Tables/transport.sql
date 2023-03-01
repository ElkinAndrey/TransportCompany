CREATE TABLE [dbo].[transport] (
    [transport_id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [series]                NVARCHAR (10) DEFAULT ('') NOT NULL,
    [number]                NVARCHAR (10) DEFAULT ('') NOT NULL,
    [region_code]           NVARCHAR (10) DEFAULT ('') NOT NULL,
    [start]                 DATETIME      NOT NULL,
    [end]                   DATETIME      NULL,
    [mileage]               INT           DEFAULT ((0)) NOT NULL,
    [transport_category_id] SMALLINT      NOT NULL,
    [country_id]            SMALLINT      NOT NULL,
    [brand_id]              BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_id] ASC),
    FOREIGN KEY ([brand_id]) REFERENCES [dbo].[brand] ([brand_id]) ON DELETE CASCADE,
    FOREIGN KEY ([country_id]) REFERENCES [dbo].[country] ([country_id]) ON DELETE CASCADE,
    FOREIGN KEY ([transport_category_id]) REFERENCES [dbo].[transport_category] ([transport_category_id]) ON DELETE CASCADE
);











