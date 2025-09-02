USE [EmployeeDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetDate]    Script Date: 02-Sep-25 16:31:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[fn_GetDate]()
RETURNS DATETIME
AS
BEGIN
	RETURN GETDATE()
END