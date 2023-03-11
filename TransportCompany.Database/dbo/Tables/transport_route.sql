CREATE TABLE [dbo].[transport_route] (
    [transport_id] BIGINT NOT NULL,
    [route_id]     BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_id] ASC, [route_id] ASC),
    FOREIGN KEY ([route_id]) REFERENCES [dbo].[route] ([route_id]) ON DELETE CASCADE,
    FOREIGN KEY ([transport_id]) REFERENCES [dbo].[transport] ([transport_id]) ON DELETE CASCADE
);

