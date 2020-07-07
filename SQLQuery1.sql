


--CREATE TABLE [dbo].[tblDesignation] (
--    [DesignationID]   INT          IDENTITY (1, 1) NOT NULL,
--    [DesignationName] VARCHAR (30) NULL,
--    PRIMARY KEY CLUSTERED ([DesignationID] ASC)
--);


--CREATE TABLE [dbo].[tblDepartment] (
--    [DepartmentID]   INT          IDENTITY (1, 1) NOT NULL,
--    [DepartmentName] VARCHAR (30) NULL,
--    PRIMARY KEY CLUSTERED ([DepartmentID] ASC)
--);
CREATE TABLE [dbo].[tblEmployee] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NULL,
    [Email]        VARCHAR (50) NULL,
    [EmployeeCode] VARCHAR (10) NULL,
    [Gender]       VARCHAR (10) NULL,
    [Designation]  INT          NULL,
    [Department]   INT          NULL,
    [DOB]          VARCHAR (15) NULL,
    [Salary]       INT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([Designation]) REFERENCES [dbo].[tblDesignation] ([DesignationID]),
    FOREIGN KEY ([Department]) REFERENCES [dbo].[tblDepartment] ([DepartmentID])
);

