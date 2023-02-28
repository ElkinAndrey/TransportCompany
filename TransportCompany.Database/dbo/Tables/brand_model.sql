CREATE TABLE [dbo].[brand_model] (
    [brand_model_id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (MAX) NOT NULL,
    [brand_company_id] BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([brand_model_id] ASC),
    FOREIGN KEY ([brand_company_id]) REFERENCES [dbo].[brand_company] ([brand_company_id]) ON DELETE CASCADE
);



