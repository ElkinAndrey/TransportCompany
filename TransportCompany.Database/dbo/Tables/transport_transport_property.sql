CREATE TABLE [dbo].[transport_transport_property] (
    [transport_id]          BIGINT         NOT NULL,
    [transport_property_id] BIGINT         NOT NULL,
    [content]               NVARCHAR (MAX) DEFAULT ('') NULL,
    PRIMARY KEY CLUSTERED ([transport_property_id] ASC, [transport_id] ASC),
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id]) ON DELETE CASCADE,
    FOREIGN KEY ([transport_property_id]) REFERENCES [dbo].[transport_property] ([transport_property_id]) ON DELETE CASCADE
);



