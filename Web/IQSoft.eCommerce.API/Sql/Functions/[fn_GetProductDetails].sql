USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetProductDetails]    Script Date: 14-Feb-21 5:32:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetProductDetails](@ProductId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

 DECLARE @JSON_DATA NVARCHAR(MAX)
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '	
	{
		"name": "Infinix Hot 10 (6 GB 128 GB)"
		, "specefications":
		{
			"Smart Phone Number": "Infinix Hot 10 (6 GB 128 GB)"							
			,"RAM": "6 GB"
			,"OS":"Andriod 10"
			,"Processor Core":"Octa Core"
			,"Screen Size": "6.78 Inch"
			,"Network Support": "4G VoLTE"							
			,"Battery Capacity": "5200 mAh"
			,"Back Camera":"16 MP + 2 Low Light Sensor"
			,"SIM Type":"Dual SIM"
			,"Front Camera":"8 MP"
			,"others":""
		}		
						
	}
'

RETURN @JSON_DATA
END
