USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[SoftDeleteEmployee]    Script Date: 01-Sep-25 22:16:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SoftDeleteEmployee]
	@EmployeeId NVARCHAR(450)
AS
BEGIN
	UPDATE Employees 
	SET IsDeleted = 1, UpdatedDate = GETDATE()
	WHERE EmployeeId = @EmployeeId
END