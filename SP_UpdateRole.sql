USE [ASP_EF_Music]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRole]    Script Date: 05/11/17 15:43:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Pieter Van Leuven
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRole] 
	-- Add the parameters for the stored procedure here
	@id int, 
	@role nvarchar(max)
AS
BEGIN
	UPDATE Roles
	   SET role = @role
	 WHERE Id = @id
END

GO

