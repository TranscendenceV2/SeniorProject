CREATE TABLE [dbo].[StaffDept] (
    [StaffDeptID] INT IDENTITY (1, 1) NOT NULL,
    [StaffID]     INT NOT NULL,
    [DeptID]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([StaffDeptID] ASC),
    CONSTRAINT [FK_DeptID_Bridge] FOREIGN KEY ([DeptID]) REFERENCES [dbo].[Departments] ([DeptID]),
    CONSTRAINT [FK_StaffID_Bridge] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([StaffID])
);

