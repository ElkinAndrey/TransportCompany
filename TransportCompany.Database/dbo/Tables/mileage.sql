CREATE TABLE [dbo].[mileage] (
    [mileage_id]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [fixed_mileage] INT              NOT NULL,
    [date]          DATETIME         NOT NULL,
    [transport_id]  BIGINT           NOT NULL,
    PRIMARY KEY CLUSTERED ([mileage_id] ASC),
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id]) ON DELETE CASCADE
);

