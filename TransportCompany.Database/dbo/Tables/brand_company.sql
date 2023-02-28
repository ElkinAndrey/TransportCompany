CREATE TABLE [dbo].[brand_company] (
    [brand_company_id] BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([brand_company_id] ASC)
);

