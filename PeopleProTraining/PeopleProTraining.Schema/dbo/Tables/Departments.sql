CREATE TABLE [dbo].[Departments] (
    [DepartmentID] INT            NOT NULL IDENTITY,
    [Name]         NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentID] ASC)
);

