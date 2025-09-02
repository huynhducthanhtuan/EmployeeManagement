USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 02-Sep-25 13:20:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UpdateEmployee]
	@EmployeeId NVARCHAR(450),
	@FullName NVARCHAR(max),
	@Gender NVARCHAR(max) = 'Other',
	@DateOfBirth DATETIME2(7),
	@Hometown NVARCHAR(max),
	@AvatarImage NVARCHAR(max)
AS
BEGIN
	UPDATE Employees
	SET 
		FullName = @FullName, 
		Gender = @Gender,
		DateOfBirth = @DateOfBirth, 
		Hometown = @Hometown, 
		AvatarImage = @AvatarImage,
		UpdatedDate = GETDATE()
	WHERE EmployeeId = @EmployeeId
END