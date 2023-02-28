CREATE TABLE [dbo].[transport_category] (
    [transport_category_id] SMALLINT       IDENTITY (1, 1) NOT NULL,
    [name]                  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([transport_category_id] ASC)
);



