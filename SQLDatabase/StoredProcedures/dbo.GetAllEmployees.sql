USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 02-Sep-25 11:02:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllEmployees]
	@IncludeDeleted BIT = 0
AS
BEGIN
	BEGIN
		SELECT E.FullName, E.Gender, E.DateOfBirth, E.Hometown, E.AvatarImage, P.PositionName, D.DepartmentName FROM Employees E
		JOIN Positions P ON P.PositionId = E.PositionId
		JOIN Departments D ON D.DepartmentId = E.DepartmentId
		WHERE @IncludeDeleted = 1 OR E.IsDeleted = 0
	END
END