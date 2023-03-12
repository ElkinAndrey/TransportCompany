CREATE TABLE [dbo].[cargo_transportation] (
    [cargo_transportation_id] BIGINT         IDENTITY (1, 1) NOT NULL,
    [price]                   MONEY          DEFAULT ((0)) NOT NULL,
    [additional_information]  NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [start]                   DATETIME       NOT NULL,
    [end]                     DATETIME       NULL,
    [transport_id]            BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([cargo_transportation_id] ASC),
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id]) ON DELETE CASCADE
);

