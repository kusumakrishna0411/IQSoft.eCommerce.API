USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetHomeDataDetails]    Script Date: 06-Feb-21 6:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetHomeDataDetails]
()
RETURNS NVARCHAR(MAX)
AS
BEGIN

	DECLARE @JSON_DATA NVARCHAR(MAX)

	--SET @JSON_"data" = (SELECT '['+ STUFF((
 --               SELECT ',{"Col1":"' + CAST(t1.UserName AS NVARCHAR(MAX)) + '",'+
 --                       +'"Col2":"'+CAST(t1.Password AS NVARCHAR(MAX)) + '"}'
 --                   FROM Users t1 FOR XML PATH(''), TYPE
 --                 ).value('.', 'varchar(max)'),1,1,''
 --             ) + ']')
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '[
	{
		"title" : ""
		,"type" : "slider"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" : [
					{
						"imagePath": "'+@IMG_PATH+'slider/1.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
					,{
						"imagePath": "'+@IMG_PATH+'slider/2.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
					,{
						"imagePath": "'+@IMG_PATH+'slider/3.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
					,{
						"imagePath": "'+@IMG_PATH+'slider/4.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
					,{
						"imagePath": "'+@IMG_PATH+'slider/5.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
					,{
						"imagePath": "'+@IMG_PATH+'slider/6.jpg"
						,"targetUrl": "'+@URL_PATH+'products?order=popular"
						,"others":""
					}
				]
	}
	,{
		"title" : ""
		,"type" : "list"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'accessories/1.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'accessories/2.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
		]
	}
	,{
		"title" : ""
		,"type" : "list"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'accessories/4.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'accessories/5.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'accessories/3.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
		]
	}
	,{
		"title" : "Flagship Brand Stores"
		,"type" : "list"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'brands/apple.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'brands/MI.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'brands/google-mobile.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'brands/OnePlus.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'brands/samsung.png"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'brands/vivo.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				]
	}
	,{
		"title" : ""
		,"type" : "slider"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'offer1.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				]
	}
	,{
		"title" : "Featured Brands"
		,"type" : "list"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'offers/12.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'offers/7.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'offers/8.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'offers/9.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'offers/5.gif"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				,{
					"imagePath": "'+@IMG_PATH+'offers/6.jpg"
					,"targetUrl": "'+@URL_PATH+'offers/products?order=popular"
					,"others":""
				}
				]
	}
	,{
		"title" : ""
		,"type" : "slider"
		,"targetUrl" : "'+@URL_PATH+'products?order=popular"
		,"data" :[
				{
					"imagePath": "'+@IMG_PATH+'offer2.jpg"
					,"targetUrl": "'+@URL_PATH+'products?order=popular"
					,"others":""
				}
				]
	}
]
'

RETURN @JSON_DATA
END
