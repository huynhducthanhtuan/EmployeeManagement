USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEmployee]    Script Date: 02-Sep-25 13:18:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_AddEmployee]
	@FullName NVARCHAR(max),
	@Gender NVARCHAR(max) = 'Other',
	@DateOfBirth DATETIME2(7),
	@Hometown NVARCHAR(max),
	@AvatarImage NVARCHAR(max),
    @DepartmentId NVARCHAR(450),
	@PositionId NVARCHAR(450)
AS
BEGIN
	INSERT INTO Employees(FullName, Gender, DateOfBirth, Hometown, AvatarImage, PositionId, DepartmentId)
	VALUES(@FullName, @Gender, @DateOfBirth, @Hometown, @AvatarImage, @PositionId, @DepartmentId)
END