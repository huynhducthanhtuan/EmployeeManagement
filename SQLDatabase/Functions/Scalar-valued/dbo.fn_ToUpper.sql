USE [EmployeeDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ToUpper]    Script Date: 02-Sep-25 16:33:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_ToUpper](@Text NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	RETURN UPPER(@Text)
END