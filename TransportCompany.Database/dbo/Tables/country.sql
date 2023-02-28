CREATE TABLE [dbo].[country] (
    [country_id]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [country_code]        NVARCHAR (MAX) NOT NULL,
    [deciphering_country] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([country_id] ASC)
);

