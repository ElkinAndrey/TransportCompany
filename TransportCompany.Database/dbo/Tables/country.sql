CREATE TABLE [dbo].[country] (
    [country_id]          SMALLINT       NOT NULL,
    [country_code]        NVARCHAR (MAX) NOT NULL,
    [deciphering_country] NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([country_id] ASC)
);





