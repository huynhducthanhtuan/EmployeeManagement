USE [EmployeeDB]
GO
/****** Object:  Trigger [dbo].[trg_AfterDeleteEmployee]    Script Date: 02-Sep-25 17:13:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_AfterDeleteEmployee]
ON [dbo].[Employees]
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeLogs(EmployeeId, Action)
    SELECT d.EmployeeId, 'HARD_DELETE'
    FROM deleted d;
END;