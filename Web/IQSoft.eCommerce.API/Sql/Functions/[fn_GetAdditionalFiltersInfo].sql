USE [eCommerceSais]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetItemDetailsByCategoy]    Script Date: 20-Feb-21 4:37:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER function [dbo].[fn_GetAdditionalFiltersInfo](@CategoryId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

 DECLARE @JSON_DATA NVARCHAR(MAX)
 DECLARE @IMG_PATH NVARCHAR(MAX)  = 'http://iqerp.in/mappimages/'
 DECLARE @URL_PATH NVARCHAR(MAX)  = 'http://localhost:54047/'

	SET @JSON_DATA = '
	{
	"priceMinValue" : 1199
	,"priceMaxValue" : 59990
	,"MOQMinValue" : 1199
	,"MOQMaxValue" : 59990
	,"details" :
	[
		{
			"title" : "RAM"
			,"filterType" : "RAM"
			,"data" : [
						{
							"display": "1 GB"
							,"value": 1
							,"noOfItems": 88
							,"others":""
						}
						,{
							"display": "12 GB"
							,"value": 12
							,"noOfItems": 3
							,"others":""
						}						
						,{
							"display": "2 GB"
							,"value": 2
							,"noOfItems": 447
							,"others":""
						}
						,{
							"display": "3 GB"
							,"value": 3
							,"noOfItems": 33
							,"others":""
						}
						,{
							"display": "4 GB"
							,"value": 4
							,"noOfItems": 44
							,"others":""
						}
						,{
							"display": "5 GB"
							,"value": 5
							,"noOfItems": 55
							,"others":""
						}						
						,{
							"display": "6 GB"
							,"value": 6
							,"noOfItems": 66
							,"others":""
						}
						,{
							"display": "500 MB"
							,"value": 500
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "ROM"
			,"filterType" : "ROM"
			,"data" : [
						{
							"display": "128 GB"
							,"value": 128
							,"noOfItems": 477
							,"others":""
						}
						,{
							"display": "128 MB"
							,"value": 128
							,"noOfItems": 3
							,"others":""
						}						
						,{
							"display": "16 GB"
							,"value": 16
							,"noOfItems": 256
							,"others":""
						}
						,{
							"display": "256 GB"
							,"value": 256
							,"noOfItems": 7
							,"others":""
						}
						,{
							"display": "32 GB"
							,"value": 32
							,"noOfItems": 561
							,"others":""
						}
						,{
							"display": "32 MB"
							,"value": 32
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "4 GB"
							,"value": 4
							,"noOfItems": 66
							,"others":""
						}
						,{
							"display": "64 GB"
							,"value": 64
							,"noOfItems": 6
							,"others":""
						}
						,{
							"display": "8 GB"
							,"value": 8
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Battery Capacity"
			,"filterType" : "BatteryCapacity"
			,"data" : [
						{
							"display": "1400 mAh"
							,"value": 1400
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "1600 mAh"
							,"value": 1600
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "1750 mAh"
							,"value": 1750
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "2000 mAh"
							,"value": 2000
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "2050 mAh"
							,"value": 2050
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "2100 mAh"
							,"value": 2100
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "2200 mAh"
							,"value": 2200
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "2300 mAh"
							,"value": 2300
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "2400 mAh"
							,"value": 2400
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "2500 mAh"
							,"value": 2500
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "2600 mAh"
							,"value": 4
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "2800 mAh"
							,"value": 2800
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "2900 mAh"
							,"value": 2900
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "3000 mAh"
							,"value": 3000
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "3010 mAh"
							,"value": 3010
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "3020 mAh"
							,"value": 3020
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "3030 mAh"
							,"value": 3030
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Back Camera"
			,"filterType" : "BackCamera"
			,"data" : [
						{
							"display": "108 MP + 16 MP + 8 MP"
							,"value": 0
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "108 MP + 16 MP + 8 MP"
							,"value": 1600
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "108 MP + 16 MP + 8 MP"
							,"value": 1750
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "12 MP + 2 MP + 8 MP"
							,"value": 2000
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "108 MP + 8 MP + 2 MP + 2 MP"
							,"value": 2050
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "12 MP"
							,"value": 2100
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "12 MP + 2 MP"
							,"value": 2200
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "12 MP + 8 MP + 2 MP + 2 MP"
							,"value": 2300
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "12 MP + 13 MP"
							,"value": 2400
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "12 MP + 2 MP"
							,"value": 2500
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "12 MP + 5 MP"
							,"value": 4
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "12 MP + 8 MP + 2 MP"
							,"value": 2800
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "12 MP + 8 MP + 2 MP + 2 MP"
							,"value": 2900
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "13 MP"
							,"value": 3000
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "13 MP + 2 MP"
							,"value": 3010
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "13 MP + 2 MP + 8 MP"
							,"value": 3020
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "13 MP + 8 MP + 2 MP + 2 MP"
							,"value": 3030
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Screen Size"
			,"filterType" : "ScreenSize"
			,"data" : [
						{
							"display": "4.0 Inch"
							,"value": 4.0
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "4.5 Inch"
							,"value": 4.5
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "5 Inch"
							,"value": 5
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "5.2 Inch"
							,"value": 5.2
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "5.3 Inch"
							,"value": 5.3
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "5.34 Inch"
							,"value": 5.34
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "5.4 Inch"
							,"value": 5.4
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "5.45 Inch"
							,"value": 5.45
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "5.5 Inch"
							,"value": 5.5
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "5.7 Inch"
							,"value": 5.7
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "5.71 Inch"
							,"value": 5.71
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "5.84 Inch"
							,"value": 5.84
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "5.9 Inch"
							,"value": 5.9
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "5.99 Inch"
							,"value": 5.99
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "6.0 Inch"
							,"value": 6.0
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "7 Inch"
							,"value": 7
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "8 Inch"
							,"value": 8
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Smart Phone Mobile"
			,"filterType" : "SmartPhoneMobile"
			,"data" : [
						{
							"display": "Realme 1"
							,"value": 4.0
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Realme 11"
							,"value": 4.5
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "Realme 12"
							,"value": 5
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "Realme 13"
							,"value": 5.2
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "Realme 14"
							,"value": 5.3
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Realme 15"
							,"value": 5.34
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "Realme 16"
							,"value": 5.4
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "Realme 17"
							,"value": 5.45
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Realme 18"
							,"value": 5.5
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "Realme 19"
							,"value": 5.7
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "Realme 21"
							,"value": 5.71
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "Realme 321"
							,"value": 5.84
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "Realme 31"
							,"value": 5.9
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "Realme 41"
							,"value": 5.99
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "Realme 51"
							,"value": 6.0
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "Realme 61"
							,"value": 7
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "Realme 71"
							,"value": 8
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Activation Status"
			,"filterType" : "ActivationStatus"
			,"data" : [
						{
							"display": "Activated"
							,"value": 4.0
							,"noOfItems": 897
							,"others":""
						}
						,{
							"display": "Fresh"
							,"value": 4.5
							,"noOfItems": 1197
							,"others":""
						}
						]
		}
		,{
			"title" : "Product Type"
			,"filterType" : "ProductType"
			,"data" : [
						{
							"display": "SmartPhone"
							,"value": 4.0
							,"noOfItems": 2112
							,"others":""
						}
						]
		}
		,{
			"title" : "Supplier City"
			,"filterType" : "SupplierCity"
			,"data" : [
						{
							"display": "Ahmedabad"
							,"value": 4.0
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Bangalore"
							,"value": 4.5
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "Bhopal"
							,"value": 5
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "Chennai"
							,"value": 5.2
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "Delhi"
							,"value": 5.3
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Ghaziabad"
							,"value": 5.34
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "Gurgaon"
							,"value": 5.4
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "Gwalior"
							,"value": 5.45
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Howrah"
							,"value": 5.5
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "Hyderabad"
							,"value": 5.7
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "Indore"
							,"value": 5.71
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "Jaipur"
							,"value": 5.84
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "Kolkata"
							,"value": 5.9
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "Mumbai"
							,"value": 5.99
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "Nagpur"
							,"value": 6.0
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "Nashik"
							,"value": 7
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "Noida"
							,"value": 8
							,"noOfItems": 6
							,"others":""
						}
					]
		}
		,{
			"title" : "Brand"
			,"filterType" : "Brand"
			,"data" : [
						{
							"display": "Alcatel"
							,"value": 4.0
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Anee"
							,"value": 4.5
							,"noOfItems": 4
							,"others":""
						}						
						,{
							"display": "Apple"
							,"value": 5
							,"noOfItems": 2
							,"others":""
						}
						,{
							"display": "Asus"
							,"value": 5.2
							,"noOfItems": 27
							,"others":""
						}
						,{
							"display": "Billion Capture+"
							,"value": 5.3
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Bird"
							,"value": 5.34
							,"noOfItems": 6
							,"others":""
						}						
						,{
							"display": "Blaupunkt"
							,"value": 5.4
							,"noOfItems": 16
							,"others":""
						}
						,{
							"display": "Blu"
							,"value": 5.45
							,"noOfItems": 3
							,"others":""
						}
						,{
							"display": "Celkon"
							,"value": 5.5
							,"noOfItems": 14
							,"others":""
						}
						,{
							"display": "Coolpad"
							,"value": 5.7
							,"noOfItems": 60
							,"others":""
						}						
						,{
							"display": "E&L"
							,"value": 5.71
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "EL"
							,"value": 5.84
							,"noOfItems": 32
							,"others":""
						}
						,{
							"display": "Fly"
							,"value": 5.9
							,"noOfItems": 4
							,"others":""
						}
						,{
							"display": "Forme"
							,"value": 5.99
							,"noOfItems": 222
							,"others":""
						}						
						,{
							"display": "Forstar"
							,"value": 6.0
							,"noOfItems": 5
							,"others":""
						}
						,{
							"display": "Gfive"
							,"value": 7
							,"noOfItems": 26
							,"others":""
						}
						,{
							"display": "Gionee"
							,"value": 8
							,"noOfItems": 6
							,"others":""
						}
					]
		}
	]
	}
'

RETURN @JSON_DATA
END
