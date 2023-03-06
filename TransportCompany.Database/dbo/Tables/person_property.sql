CREATE TABLE [dbo].[person_property] (
    [person_property_id] BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [translation]        NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [data_type_id]       SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([person_property_id] ASC),
    FOREIGN KEY ([data_type_id]) REFERENCES [dbo].[data_type] ([data_type_id]) ON DELETE CASCADE
);

