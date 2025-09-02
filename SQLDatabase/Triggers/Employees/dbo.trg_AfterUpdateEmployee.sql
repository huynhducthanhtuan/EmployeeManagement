USE [EmployeeDB]
GO
/****** Object:  Trigger [dbo].[trg_AfterUpdateEmployee]    Script Date: 02-Sep-25 17:13:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_AfterUpdateEmployee]
ON [dbo].[Employees]
AFTER UPDATE
AS
BEGIN
    INSERT INTO EmployeeLogs(EmployeeId, Action)
    SELECT 
		i.EmployeeId, 
		CASE i.IsDeleted 
			WHEN 0 THEN 'UPDATE'
			WHEN 1 THEN 'SOFT_DELETE'
			ELSE 'UPDATE'
		END
    FROM inserted i;
END;