USE [EmployeeDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetEmployeebyId]    Script Date: 02-Sep-25 16:31:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_GetEmployeebyId](@EmployeeId NVARCHAR(450))
RETURNS TABLE
AS
RETURN
(
	SELECT E.FullName, E.Gender, E.DateOfBirth, E.Hometown, E.AvatarImage, P.PositionName, D.DepartmentName FROM Employees E
	JOIN Positions P ON P.PositionId = E.PositionId
	JOIN Departments D ON D.DepartmentId = E.DepartmentId
	WHERE E.EmployeeId = @EmployeeId
)