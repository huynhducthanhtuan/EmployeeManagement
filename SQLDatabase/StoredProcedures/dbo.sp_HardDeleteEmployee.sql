USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_HardDeleteEmployee]    Script Date: 02-Sep-25 13:19:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_HardDeleteEmployee]
	@EmployeeId NVARCHAR(450)
AS
BEGIN
	DELETE EmployeeProjects WHERE EmployeeId = @EmployeeId
	DELETE Employees WHERE EmployeeId = @EmployeeId
END