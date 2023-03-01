CREATE TABLE [dbo].[transport_category_transport_property] (
    [transport_property_id] BIGINT   NOT NULL,
    [transport_category_id] SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_property_id] ASC, [transport_category_id] ASC),
    FOREIGN KEY ([transport_category_id]) REFERENCES [dbo].[transport_category] ([transport_category_id]) ON DELETE CASCADE,
    FOREIGN KEY ([transport_property_id]) REFERENCES [dbo].[transport_property] ([transport_property_id]) ON DELETE CASCADE
);

