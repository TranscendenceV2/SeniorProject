CREATE TABLE [dbo].[Transactions] (
    [TransID]         INT            IDENTITY (1, 1) NOT NULL,
    [UniqueID]        INT            NOT NULL,
    [DeptID]          INT            NOT NULL,
    [StaffID]         INT            NOT NULL,
    [FundMasterID]    VARCHAR (30)   NOT NULL,
    [TransType]       CHAR (10)      NOT NULL,
    [TransDate]       DATE           NOT NULL,
    [TransTransfer]   DECIMAL (6, 2) NOT NULL,
    [TransAdjustment] DECIMAL (6, 2) NOT NULL,
    [TransCredit]     DECIMAL (6, 2) NOT NULL,
    [TransCharge]     DECIMAL (6, 2) NOT NULL,
    [TransAmount]     AS             ((([TransCharge]-[TransTransfer])-[TransAdjustment])-[TransCredit]),
    PRIMARY KEY CLUSTERED ([TransID] ASC),
    CONSTRAINT [FK_Dept] FOREIGN KEY ([DeptID]) REFERENCES [dbo].[Departments] ([DeptID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_FundMasterID] FOREIGN KEY ([FundMasterID]) REFERENCES [dbo].[Funding_Sources] ([FundMasterID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Staff] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([StaffID])
);

