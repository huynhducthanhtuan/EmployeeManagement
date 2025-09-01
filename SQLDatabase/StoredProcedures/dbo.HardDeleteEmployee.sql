USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[HardDeleteEmployee]    Script Date: 01-Sep-25 22:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HardDeleteEmployee]
	@EmployeeId NVARCHAR(450)
AS
BEGIN
	DELETE EmployeeProjects WHERE EmployeeId = @EmployeeId
	DELETE Employees WHERE EmployeeId = @EmployeeId
END