CREATE TABLE [dbo].[transport_property] (
    [transport_property_id] BIGINT         NOT NULL,
    [name]                  NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [data_type_id]          SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_property_id] ASC),
    FOREIGN KEY ([data_type_id]) REFERENCES [dbo].[data_type] ([data_type_id]) ON DELETE CASCADE
);

