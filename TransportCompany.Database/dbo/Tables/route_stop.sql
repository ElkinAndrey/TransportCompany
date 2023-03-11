CREATE TABLE [dbo].[route_stop] (
    [route_id]    BIGINT   NOT NULL,
    [link_number] SMALLINT NOT NULL,
    [stop_id]     BIGINT   NOT NULL,
    PRIMARY KEY CLUSTERED ([route_id] ASC, [link_number] ASC),
    FOREIGN KEY ([route_id]) REFERENCES [dbo].[route] ([route_id]) ON DELETE CASCADE,
    FOREIGN KEY ([stop_id]) REFERENCES [dbo].[stop] ([stop_id]) ON DELETE CASCADE
);

