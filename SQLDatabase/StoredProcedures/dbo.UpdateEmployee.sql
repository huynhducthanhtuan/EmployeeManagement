USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 01-Sep-25 22:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateEmployee]
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