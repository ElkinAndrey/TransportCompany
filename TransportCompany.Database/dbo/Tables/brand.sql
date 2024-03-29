﻿CREATE TABLE [dbo].[brand] (
    [brand_id]        BIGINT IDENTITY (1, 1) NOT NULL,
    [year_publishing] INT    DEFAULT ((0)) NOT NULL,
    [brand_model_id]  BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([brand_id] ASC),
    CHECK ([year_publishing]>=(0)),
    FOREIGN KEY ([brand_model_id]) REFERENCES [dbo].[brand_model] ([brand_model_id]) ON DELETE CASCADE
);







