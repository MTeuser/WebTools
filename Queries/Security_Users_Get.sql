-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Security].[Users_Get]
   @pIdentification varchar(50) = null,
   @pPassword varchar(50) = null
AS
BEGIN
	IF (@pIdentification <> null) AND (@pPassword <> null)
		BEGIN
	     Select idUser, Identification, [Password], LastName, FirstName, Picture, Email, Active, InsDateTime, UpdDateTime 
		 from [Security].[User] where 1=1
		 and Identification = @pIdentification
		 AND Password = @pPassword
		 END
	 ELSE
	    BEGIN
		   SELECT * FROM [Security].[User] WHERE 1=1		   
		END 
END
GO
