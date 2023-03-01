CREATE TABLE [dbo].[data_type] (
    [data_type_id] SMALLINT       NOT NULL,
    [name]         NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([data_type_id] ASC)
);

