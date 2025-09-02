USE [EmployeeDB]
GO
/****** Object:  Trigger [dbo].[trg_AfterAddEmployee]    Script Date: 02-Sep-25 17:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_AfterAddEmployee]
ON [dbo].[Employees]
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeLogs(EmployeeId, Action)
    SELECT i.EmployeeId, 'INSERT'
    FROM inserted i;
END;