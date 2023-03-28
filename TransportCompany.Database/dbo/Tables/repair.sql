CREATE TABLE [dbo].[repair] (
    [repair_id]    BIGINT         IDENTITY (1, 1) NOT NULL,
    [price]        MONEY          NOT NULL,
    [information]  NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [start]        DATETIME       NOT NULL,
    [end]          DATETIME       NULL,
    [transport_id] BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([repair_id] ASC),
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id])
);

