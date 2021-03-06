USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetItemDetailsByCategoy]    Script Date: 06-Feb-21 10:03:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetItemDetailsByCategoy](@CategoryId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

 DECLARE @JSON_DATA NVARCHAR(MAX)
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '
	{
	"imagePath": "'+@IMG_PATH+'slider/1.jpg"
	,"noOfItems" : "6172"
	,"noOfSuppliers" : "297"
	,"details" :
	[
		{
			"title" : "Brand"
			,"type" : "oneRowWithMultipleItems"
			,"data" : [
						{
							"name": "Boat"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Realme"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Sony"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Apple"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Logitech"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "View All"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
					]
		}
		,{
			"title" : "Type"
			,"type" : "oneRowWithMultipleItems"
			,"data" : [
						{
							"name": "In the Ear"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Over the Ear"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "On the Ear"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
					
					]
		}
		,{
			"title" : "Shop By Price"
			,"type" : "listWithThreeColumns"
			,"data" : [
						{
							"name": "Below ₹ 50"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "₹ 50 - 100"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "₹ 100 - 150"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "₹ 150 - 200"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
						,{
							"name": "Above ₹ 250"
							,"targetUrl": "'+@URL_PATH+'products?order=popular"
							,"others":""
						}
					]
		}
	]
	}
'

RETURN @JSON_DATA
END
