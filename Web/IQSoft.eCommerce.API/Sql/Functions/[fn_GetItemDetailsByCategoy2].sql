USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetItemDetailsByCategoy2]    Script Date: 14-Feb-21 5:31:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetItemDetailsByCategoy2](@CategoryId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

 DECLARE @JSON_DATA NVARCHAR(MAX)
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '	
	[
		{
			"title" : ""
			,"type" : "img-slider"
			,"data" : [
						{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/3.jpg"
							,"others":""
						}
						,{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/4.jpg"
							,"others":""
						}
						,{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
						,{
							"name": ""
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
					]
		}
		,{
			"title" : "Recenly Viewed"
			,"type" : "grid-list-infinity"
			,"data" : [
						{
							"name": "Weighing Machine"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Massger"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Smart Watch"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/3.jpg"
							,"others":""
						}
						,{
							"name": "Trimmer"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/4.jpg"
							,"others":""
						}
						,{
							"name": "Shaver"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
						,{
							"name": "Hari Curler"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
					]
		}
		,{
			"title" : "Hair Care Appliances"
			,"type" : "one-one"
			,"data" : [
						{
							"name": "Epilator"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Trimmer"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Hair Straightener"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/3.jpg"
							,"others":""
						}
						,{
							"name": "Hair Styler"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/4.jpg"
							,"others":""
						}
						,{
							"name": "Shaver"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
						,{
							"name": "Hari Curler"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/5.jpg"
							,"others":""
						}
					]
		}
		,{
			"title" : "Smart Wearables"
			,"type" : "one-one"
			,"data" : [
						{
							"name": "Smat Watch"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Smart Brand"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Smartwatch Strap"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/3.jpg"
							,"others":""
						}
					]
		}
		,{
			"title" : "Health Care Appliances"
			,"type" : "one-one"
			,"data" : [
						{
							"name": "Massager"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Weighing Machine"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/1.jpg"
							,"others":""
						}
						,{
							"name": "Air Purifier"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/3.jpg"
							,"others":""
						}
						,{
							"name": "Infrared Thermometer"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"							
							,"imagePath": "'+@IMG_PATH+'slider/4.jpg"
							,"others":""
						}						
					]
		}
	]
'

RETURN @JSON_DATA
END
