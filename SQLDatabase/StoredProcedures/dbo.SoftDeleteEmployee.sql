USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteEmployee]    Script Date: 02-Sep-25 12:47:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SoftDeleteEmployee]
	@EmployeeId NVARCHAR(450)
AS
BEGIN
	UPDATE EmployeeProjects SET IsDeleted = 1, UpdatedDate = GETDATE() WHERE EmployeeId = @EmployeeId
	UPDATE Employees SET IsDeleted = 1, UpdatedDate = GETDATE() WHERE EmployeeId = @EmployeeId
END