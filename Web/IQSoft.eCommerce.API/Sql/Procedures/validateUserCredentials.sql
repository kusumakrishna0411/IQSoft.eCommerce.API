USE [eCommerceSais]
GO
/****** Object:  StoredProcedure [dbo].[validateUserCredentials]    Script Date: 06-Feb-21 6:33:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[validateUserCredentials]
@userName varchar(2000),
@password varchar(2000)
as
begin

	IF EXISTS (SELECT 1 FROM USERS WHERE UserName = @userName AND CAST(Password AS NVARCHAR) = @password AND Status = 1)
	BEGIN
		SELECT UserName,CAST(Password AS NVARCHAR) Password FROM USERS WHERE UserName = @userName AND CAST(Password AS NVARCHAR) = @password
	END	
end
