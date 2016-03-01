CREATE TABLE [dbo].[Employees] (
    [EmployeeID]             INT            IDENTITY (1, 1) NOT NULL,
    [DepartmentDepartmentID] INT            NOT NULL,
    [BuildingBuildingID]     INT            NOT NULL,
    [FirstName]              NVARCHAR (MAX) NOT NULL,
    [LastName]               NVARCHAR (MAX) NOT NULL,
    [DoB]                    DATETIME       NOT NULL,
    [RoomNumber]             INT            NOT NULL,
    [Title]                  NVARCHAR (MAX) NOT NULL,
    [Salary]                 DECIMAL (18)   NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_BuildingEmployee] FOREIGN KEY ([BuildingBuildingID]) REFERENCES [dbo].[Buildings] ([BuildingID]),
    CONSTRAINT [FK_EmployeesInDepartment] FOREIGN KEY ([DepartmentDepartmentID]) REFERENCES [dbo].[Departments] ([DepartmentID])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_BuildingEmployee]
    ON [dbo].[Employees]([BuildingBuildingID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EmployeesInDepartment]
    ON [dbo].[Employees]([DepartmentDepartmentID] ASC);

