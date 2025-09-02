USE [EmployeeDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAllEmployees]    Script Date: 02-Sep-25 16:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_GetAllEmployees](@IncludeDeleted BIT = 0)
RETURNS TABLE
AS
RETURN
(
	SELECT E.FullName, E.Gender, E.DateOfBirth, E.Hometown, E.AvatarImage, P.PositionName, D.DepartmentName FROM Employees E
	JOIN Positions P ON P.PositionId = E.PositionId
	JOIN Departments D ON D.DepartmentId = E.DepartmentId
	WHERE @IncludeDeleted = 1 OR E.IsDeleted = 0
)