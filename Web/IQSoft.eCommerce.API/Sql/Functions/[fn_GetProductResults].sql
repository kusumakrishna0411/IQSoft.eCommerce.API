USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetProductResults]    Script Date: 14-Feb-21 5:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetProductResults](@CategoryId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

 DECLARE @JSON_DATA NVARCHAR(MAX)
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '	
	[
		{
			"name": "Infinix Hot 10 (6 GB 128 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Amber Red, Ocean Wave"
			,"rateDetails":"₹ 10,798.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme C15(4 GB 64 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Power Blue, Power Silver"
			,"rateDetails":"₹ 10,249.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme 7pro(6 GB 128 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Micro Blue , Mirror Silver"
			,"rateDetails":"₹ 18,899.99 onwards"
			,"others":""
		}
		,{
			"name": "Infinix Smart 4 Plus (3 GB 32 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Ocean Wave, 2 more"
			,"rateDetails":"₹ 7,798.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme C15(4 GB 64 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Power Blue, Power Silver"
			,"rateDetails":"₹ 10,249.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme 7pro(6 GB 128 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Micro Blue , Mirror Silver"
			,"rateDetails":"₹ 18,899.99 onwards"
			,"others":""
		}
		,{
			"name": "Infinix Smart 4 Plus (3 GB 32 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Ocean Wave, 2 more"
			,"rateDetails":"₹ 7,798.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme C15(4 GB 64 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Power Blue, Power Silver"
			,"rateDetails":"₹ 10,249.99 onwards"
			,"others":""
		}
		,{
			"name": "Realme 7pro(6 GB 128 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Micro Blue , Mirror Silver"
			,"rateDetails":"₹ 18,899.99 onwards"
			,"others":""
		}
		,{
			"name": "Infinix Smart 4 Plus (3 GB 32 GB)"
			,"targetUrl": "'+@URL_PATH+'products?order=popular"							
			,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
			,"description":"Black, Ocean Wave, 2 more"
			,"rateDetails":"₹ 7,798.99 onwards"
			,"others":""
		}
						
	]
'

RETURN @JSON_DATA
END
