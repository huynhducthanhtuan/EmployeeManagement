USE [EmployeeDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ToLower]    Script Date: 02-Sep-25 16:32:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_ToLower](@Text NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	RETURN LOWER(@Text)
END