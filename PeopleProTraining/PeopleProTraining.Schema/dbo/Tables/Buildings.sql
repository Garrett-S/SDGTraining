CREATE TABLE [dbo].[Buildings] (
    [Name]         NVARCHAR (MAX) NOT NULL,
    [BuildingID]   INT            NOT NULL,
    [AddressLine1] NVARCHAR (MAX) NOT NULL,
    [AddressLine2] NVARCHAR (MAX) NULL,
    [City]         NVARCHAR (MAX) NOT NULL,
    [State]        NVARCHAR (MAX) NOT NULL,
    [ZipCode]      NVARCHAR (MAX) NOT NULL,
    [Country]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED ([BuildingID] ASC)
);



