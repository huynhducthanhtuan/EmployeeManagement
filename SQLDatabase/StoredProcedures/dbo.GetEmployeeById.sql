USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 01-Sep-25 22:15:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetEmployeeById]
	@EmployeeId NVARCHAR(450)
AS
BEGIN
	SELECT E.FullName, E.Gender, E.DateOfBirth, E.Hometown, E.AvatarImage, P.PositionName, D.DepartmentName FROM Employees E
	JOIN Positions P ON P.PositionId = E.PositionId
	JOIN Departments D ON D.DepartmentId = E.DepartmentId
	WHERE E.EmployeeId = @EmployeeId
END