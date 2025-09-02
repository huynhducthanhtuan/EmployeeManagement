ALTER VIEW vw_GetAllEmployees
AS
SELECT E.FullName, E.Gender, E.DateOfBirth, E.Hometown, E.AvatarImage, P.PositionName, D.DepartmentName 
FROM Employees E
JOIN Positions P ON P.PositionId = E.PositionId
JOIN Departments D ON D.DepartmentId = E.DepartmentId