using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExactMeasureSkill.Tests.TestData;
using Microsoft.VisualBasic.CompilerServices;

namespace ExactMeasureSkill.Tests
{


    public class BadMeasureTypeRequests: SampleRequestBase
    {


        public static string BadTargetMeasureTypeWithDecimals()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.af2b7ee1-ca0a-4c5f-a536-dea869c44c18"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {
			""DestType"": ""millimeters"",
			""SourceType"": ""inches"",
			""OrigVal"": ""4.000000""
		},
		""user"": {
			""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
		}
	},
	""context"": {
		""Viewports"": [
			{
				""type"": ""APL"",
				""id"": ""main"",
				""shape"": ""RECTANGLE"",
				""dpi"": 213,
				""presentationType"": ""STANDARD"",
				""canRotate"": false,
				""configuration"": {
					""current"": {
						""mode"": ""HUB"",
						""video"": {
							""codecs"": [
								""H_264_42"",
								""H_264_41""
							]
						},
						""size"": {
							""type"": ""DISCRETE"",
							""pixelWidth"": 1280,
							""pixelHeight"": 800
						}
					}
				}
			}
		],
		""Viewport"": {
			""experiences"": [
				{
					""arcMinuteWidth"": 346,
					""arcMinuteHeight"": 216,
					""canRotate"": false,
					""canResize"": false
				}
			],
			""mode"": ""HUB"",
			""shape"": ""RECTANGLE"",
			""pixelWidth"": 1280,
			""pixelHeight"": 800,
			""dpi"": 213,
			""currentPixelWidth"": 1280,
			""currentPixelHeight"": 800,
			""touch"": [
				""SINGLE""
			],
			""video"": {
				""codecs"": [
					""H_264_42"",
					""H_264_41""
				]
			}
		},
		""Extensions"": {
			""available"": {
				""aplext:backstack:10"": {}
			}
		},
		""System"": {
			""application"": {
				""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AEHABLPXX35CQ5BP6M4I2BO345GDAEOGMUMMK3PABJMKRGZ4LVLTHOWFYB766NM64UICB4RUWMR5UQAK5BZORMAJ2NFWVQ5KHM6HGAGFFJQSRDXZMXGGF6NA5XLKDITSXZNBEYBXRNP743RXZC6SSHP2EM6Q"",
				""supportedInterfaces"": {
					""Alexa.Presentation.APL"": {
						""runtime"": {
							""maxVersion"": ""1.8""
						}
					}
				}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzODU0MSwiaWF0IjoxNjM4NDM4MjQxLCJuYmYiOjE2Mzg0MzgyNDEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQUJ2WVFKakJPS2c5RzEvZXBHVm40czJMY0Vrd2ZvWCtuYnlYV3VDODdpNGRkVWpWckk3dXlYenRzU0RyWDNrNmtjdjM1QWRiUVlHMXFRb3JWQ2JNenhJNU91NlVXd1R5Z0dzUGVhQUErdmRXcktZVnZIMVMzRTVQdTd4Sjd6TG9MUUJTMTE2M0ExcUhpNFh2TzM5U1d6L0pDY3FBWFk4MXdZc1FTcWt0YXlYSTFUSm1YdVlNK2NwTXZ2U3lCdmZwM0pmK0ZHaHoyY0FnT3pqTW9EQ005RGwxYkozdmJMRWNsRmREcTRWMnFjbVdiUWVwUmlwQzYvaGcyUERuOEpqRCtWK0lMTEk3Y2pibGZ4MFh0V25Gc0NzcEhOU1JMRGZCblhJaDVOQ2czREZKSUVXZExHRW9vcXVUUmRsTzlzc2VOeVM1TTlVZmowMDVCSXRrTmZLdVBRTzByWjVqTVlhWi80Zkd5bVNwMjlzeGthVkswYmZuOHlRU2RGMlpXRG1LOXpMaHE5eSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.P7E-2qgNr5TIfD55unuVUyvXC1Q3GKc8aYcuqLz9wL865YoblgFJUdvSM8ET2PM3lLa2WjlBCFuMEwBOoUKTHJ3lyw3el4RL68HH1F-VUI5QxkP59Lba_EZ06B8W8cmgWUk5-DMlOqbX9HcEOOJkx6r7yMLPVlcJPBj7hTrMSVmsCgc_t4FTv20SlGtYQ1FLGTjgK8QnrY17Qne4y6313sG1-v_kcmatXa5-a3HDu5Vp1HzhXNT57obCpWJRZv9QsjrEswXn31KpUx3xfqy0Q8ZbML0LxVZk0v_u0H-tjrvilngQVCRYXloH58MxjX2ZJhea-Fc_lMA1gmHzK6GHGA""
		},
		""Alexa.Presentation.APL"": {
			""token"": """",
			""version"": ""APL_WEB_RENDERER_GANDALF"",
			""componentsVisibleOnScreen"": [
				{
					""uid"": "":1409"",
					""position"": ""960x600+0+0:0"",
					""type"": ""mixed"",
					""tags"": {
						""viewport"": {}
					},
					""children"": [
						{
							""uid"": "":1410"",
							""position"": ""960x600+0+0:0"",
							""type"": ""graphic"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1413"",
							""position"": ""960x87+0+0:1"",
							""type"": ""mixed"",
							""tags"": {},
							""entities"": []
						}
					],
					""entities"": []
				}
			]
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.7da9a76a-c284-4182-9649-50e1758dbea4"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T09:44:01Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""32"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""32""
					}
				},
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""69"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""69""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""inches"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""inches"",
											""id"": ""3e1b00c196db969aa22cdc50c6e966c4""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""inches"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_MATCH""
									},
									""values"": [
										{
											""value"": {
												""name"": ""inches"",
												""id"": ""3e1b00c196db969aa22cdc50c6e966c4""
											}
										}
									]
								}
							]
						}
					}
				},
				""destType"": {
					""name"": ""destType"",
					""value"": ""aah"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_NO_MATCH""
								}
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""aah"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_NO_MATCH""
									}
								}
							]
						}
					}
				}
			}
		}
	}
}

        
        ";
            return CleanRequest(str);
        }
        



        public static string BadSourceMeasureTypeWithDecimals()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.af2b7ee1-ca0a-4c5f-a536-dea869c44c18"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {
			""DestType"": ""millimeters"",
			""SourceType"": ""inches"",
			""OrigVal"": ""4.000000""
		},
		""user"": {
			""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
		}
	},
	""context"": {
		""Viewports"": [
			{
				""type"": ""APL"",
				""id"": ""main"",
				""shape"": ""RECTANGLE"",
				""dpi"": 213,
				""presentationType"": ""STANDARD"",
				""canRotate"": false,
				""configuration"": {
					""current"": {
						""mode"": ""HUB"",
						""video"": {
							""codecs"": [
								""H_264_42"",
								""H_264_41""
							]
						},
						""size"": {
							""type"": ""DISCRETE"",
							""pixelWidth"": 1280,
							""pixelHeight"": 800
						}
					}
				}
			}
		],
		""Viewport"": {
			""experiences"": [
				{
					""arcMinuteWidth"": 346,
					""arcMinuteHeight"": 216,
					""canRotate"": false,
					""canResize"": false
				}
			],
			""mode"": ""HUB"",
			""shape"": ""RECTANGLE"",
			""pixelWidth"": 1280,
			""pixelHeight"": 800,
			""dpi"": 213,
			""currentPixelWidth"": 1280,
			""currentPixelHeight"": 800,
			""touch"": [
				""SINGLE""
			],
			""video"": {
				""codecs"": [
					""H_264_42"",
					""H_264_41""
				]
			}
		},
		""Extensions"": {
			""available"": {
				""aplext:backstack:10"": {}
			}
		},
		""System"": {
			""application"": {
				""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AEHABLPXX35CQ5BP6M4I2BO345GDAEOGMUMMK3PABJMKRGZ4LVLTHOWFYB766NM64UICB4RUWMR5UQAK5BZORMAJ2NFWVQ5KHM6HGAGFFJQSRDXZMXGGF6NA5XLKDITSXZNBEYBXRNP743RXZC6SSHP2EM6Q"",
				""supportedInterfaces"": {
					""Alexa.Presentation.APL"": {
						""runtime"": {
							""maxVersion"": ""1.8""
						}
					}
				}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzODM2OSwiaWF0IjoxNjM4NDM4MDY5LCJuYmYiOjE2Mzg0MzgwNjksInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQURwNnZCdHJiMmIzeWsxQVRPMWV0MFBGdllLYmZoV2lwczdDaWdJMnNRZnhIazlXM3JkdXVSdTBwdmFWTXhyaUw0K1RDclRHbFpNUkNueDFBQlVtaVEySnBEUm5JazRUUnlSU0VhT2xzSWN0V05ha0VwaGNmNXRhN0pzdXlub0RNaWxMR2pIYnU0d0JZa0lmVVYvTisxQmYxYUpPNHVKNERSNHcxZHhJZHFUQWozYlplOVExdjIvZ0NBYXhnZkZqTlNBQmwzOGI3YTRQRlM0cGgwVG1VZTZrWHRDM2w3MTMzNCtjNFZ4dXFQL25sanJNRXd1VFZwMkhkdHQyaFIzcHI2ZW9SOXhWcC9TN1c1Yko4UWhUUjMxSnNoN3dyUkZ1ZXh4TTZhUEZKSlVGTVJhOWJnUktTSVdpLzBxMXF1QVVQNUJTSWpRdDhzWjljR3FMSXlZUHNweHVlUjNXUUJCOHU4S1ZaRCtTMFd3T28wendtR2t6Z0ozbVJDVlhWUE10b0JRMS8xSiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.hOEnHxPESrSA5ZMzh9ZQkHTDZcmHfqHzevM0rvPpfOpCSX_FdnY1lCITFh_ZXXs5Hg70a-MBrIU6j_9HKY-V2uCa6_2D60usRsxmejQjcFVKlhmMZnXmgN4NUQ5x7uHces5TLwTY5phjLT-zTqUBXGG5PeOHrLp6JShT1YCw6MoIl-K5Bn2FS-E4SQmJFIfMoDICgS5eswqkDuJGstkG1w60h6RgTaxuGuvfxZgRzb5kFWUIPHDTwAF4IbkEcdde9G2ZmD7k2j90yG3TlN5uGGZGyVeWxVB9cJTwOrbN5M9AcViHza5VJOWIJjG2qA9GxvfnfMa51kFA9V-QDIOPfA""
		},
		""Alexa.Presentation.APL"": {
			""token"": """",
			""version"": ""APL_WEB_RENDERER_GANDALF"",
			""componentsVisibleOnScreen"": [
				{
					""uid"": "":1396"",
					""position"": ""960x600+0+0:0"",
					""type"": ""mixed"",
					""tags"": {
						""viewport"": {}
					},
					""children"": [
						{
							""uid"": "":1397"",
							""position"": ""960x600+0+0:0"",
							""type"": ""graphic"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1400"",
							""position"": ""960x87+0+0:1"",
							""type"": ""mixed"",
							""tags"": {},
							""entities"": []
						}
					],
					""entities"": []
				}
			]
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.7caf7940-6800-43ce-ba1b-96626cb880e3"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T09:41:09Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""12"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""12""
					}
				},
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""54"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""54""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""jjjj"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_NO_MATCH""
								}
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""jjjj"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_NO_MATCH""
									}
								}
							]
						}
					}
				},
				""destType"": {
					""name"": ""destType"",
					""value"": ""meters"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""meters"",
											""id"": ""07d9e3aefc4093a49121c91ef65e708b""
										}
									},
									{
										""value"": {
											""name"": ""kilometers"",
											""id"": ""e19aac86196b2fc4bfb408fe10698cd9""
										}
									},
									{
										""value"": {
											""name"": ""millimeters"",
											""id"": ""882f184dd8a217016e9d9074fe1eddee""
										}
									},
									{
										""value"": {
											""name"": ""centimeters"",
											""id"": ""e6ec92b31369caeccb14cdf8116fc589""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""meters"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_MATCH""
									},
									""values"": [
										{
											""value"": {
												""name"": ""meters"",
												""id"": ""07d9e3aefc4093a49121c91ef65e708b""
											}
										},
										{
											""value"": {
												""name"": ""kilometers"",
												""id"": ""e19aac86196b2fc4bfb408fe10698cd9""
											}
										},
										{
											""value"": {
												""name"": ""millimeters"",
												""id"": ""882f184dd8a217016e9d9074fe1eddee""
											}
										},
										{
											""value"": {
												""name"": ""centimeters"",
												""id"": ""e6ec92b31369caeccb14cdf8116fc589""
											}
										}
									]
								}
							]
						}
					}
				}
			}
		}
	}
}

        
        ";
            return CleanRequest(str);
        }
        


        public static string BadSourceMeasureType()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.af2b7ee1-ca0a-4c5f-a536-dea869c44c18"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {
			""DestType"": ""millimeters"",
			""SourceType"": ""inches"",
			""OrigVal"": ""4.000000""
		},
		""user"": {
			""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
		}
	},
	""context"": {
		""Viewports"": [
			{
				""type"": ""APL"",
				""id"": ""main"",
				""shape"": ""RECTANGLE"",
				""dpi"": 213,
				""presentationType"": ""STANDARD"",
				""canRotate"": false,
				""configuration"": {
					""current"": {
						""mode"": ""HUB"",
						""video"": {
							""codecs"": [
								""H_264_42"",
								""H_264_41""
							]
						},
						""size"": {
							""type"": ""DISCRETE"",
							""pixelWidth"": 1280,
							""pixelHeight"": 800
						}
					}
				}
			}
		],
		""Viewport"": {
			""experiences"": [
				{
					""arcMinuteWidth"": 346,
					""arcMinuteHeight"": 216,
					""canRotate"": false,
					""canResize"": false
				}
			],
			""mode"": ""HUB"",
			""shape"": ""RECTANGLE"",
			""pixelWidth"": 1280,
			""pixelHeight"": 800,
			""dpi"": 213,
			""currentPixelWidth"": 1280,
			""currentPixelHeight"": 800,
			""touch"": [
				""SINGLE""
			],
			""video"": {
				""codecs"": [
					""H_264_42"",
					""H_264_41""
				]
			}
		},
		""Extensions"": {
			""available"": {
				""aplext:backstack:10"": {}
			}
		},
		""System"": {
			""application"": {
				""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AEHABLPXX35CQ5BP6M4I2BO345GDAEOGMUMMK3PABJMKRGZ4LVLTHOWFYB766NM64UICB4RUWMR5UQAK5BZORMAJ2NFWVQ5KHM6HGAGFFJQSRDXZMXGGF6NA5XLKDITSXZNBEYBXRNP743RXZC6SSHP2EM6Q"",
				""supportedInterfaces"": {
					""Alexa.Presentation.APL"": {
						""runtime"": {
							""maxVersion"": ""1.8""
						}
					}
				}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzNzg4NywiaWF0IjoxNjM4NDM3NTg3LCJuYmYiOjE2Mzg0Mzc1ODcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQURKY2kzb1FTbFZZUHdsZ1lnTmxHVzlHTkptOEpjcUlzTmdwWUdOazFmMExUMFhPZ2kwQzc3OE9yS01DVFpnS3hxYi96WjIwdTYyQ2UxWjRYa0Z0K2ovNlY2aFVZTEdIVjBka0RJYlp2ei95SDltaWhKSUhLOFBmNjZkc0NtWHhpMkE2ZHVuVFN1U3NXb21tbTROV0xIbkh2Vy9seUIyU2lSYnhtNWFUVy83NTlvWGJPSUNqQ3FxN2lSVXQ3T1gzRkIwY3JBdEV0blk0L052RFVVMmphc3EzN2U0SU1VRGM3K2NPM2VuTFAyVVZoQ1ZUNkhDaGY2NGFpRmxEYmlDRk55a1AwbjJFWVVyT2ZNYWhQMHJaL0NjSnN1REJ6MzVLbVRKYjZ2NzhhcEMwSWVqOHFXYU54cnBYMHl3V3RxMHFLcHMrajVNTjJqbjM1ZGtjNHBEbUNuMHFBajAwNFppc29rMi8wWDBwREpuSk5pYWNVTEZuS2JmdFZ6bUNMMGJJcU5wam5QSSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.Cugkfc0IAss2rdw1aHV41Dmyh2ltM0__FcQ1Q4TRPnkzTirsDERCSV17HlDQBN7wQ_QcdJQGAcUqWTlMe6D5iFkDfi135-jYNVIdDoocXqHGBv7v5Pb3ZGbWxyW6IrdBVw5eAkOtDyFwUYnUGlQ3LxcvpJIWFjcglO9_lpOOQlAnhW2HH3-Zmu7aGoMr0zocxJrTFhtqK9ZoHBtd0WH5uVOXzVxEfgASQOR4eu64gx9OmEvqvFZEYeGXLnZsUefKa99GILXhqn1twZNPSkwGnx34rWcz5wQS6edjjkulf23AZUGtakuFlNLwzZQsA9Evzg34yEm03EvKzyR_mYVxVQ""
		},
		""Alexa.Presentation.APL"": {
			""token"": """",
			""version"": ""APL_WEB_RENDERER_GANDALF"",
			""componentsVisibleOnScreen"": [
				{
					""uid"": "":1370"",
					""position"": ""960x600+0+0:0"",
					""type"": ""mixed"",
					""tags"": {
						""viewport"": {}
					},
					""children"": [
						{
							""uid"": "":1371"",
							""position"": ""960x600+0+0:0"",
							""type"": ""graphic"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1374"",
							""position"": ""960x87+0+0:1"",
							""type"": ""mixed"",
							""tags"": {},
							""entities"": []
						}
					],
					""entities"": []
				}
			]
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.e110aa47-c24e-4004-83ad-61153120c2fe"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T09:33:07Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""3"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""3""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""xxxx"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_NO_MATCH""
								}
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""xxxx"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_NO_MATCH""
									}
								}
							]
						}
					}
				},
				""destType"": {
					""name"": ""destType"",
					""value"": ""meters"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""meters"",
											""id"": ""07d9e3aefc4093a49121c91ef65e708b""
										}
									},
									{
										""value"": {
											""name"": ""kilometers"",
											""id"": ""e19aac86196b2fc4bfb408fe10698cd9""
										}
									},
									{
										""value"": {
											""name"": ""millimeters"",
											""id"": ""882f184dd8a217016e9d9074fe1eddee""
										}
									},
									{
										""value"": {
											""name"": ""centimeters"",
											""id"": ""e6ec92b31369caeccb14cdf8116fc589""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""meters"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_MATCH""
									},
									""values"": [
										{
											""value"": {
												""name"": ""meters"",
												""id"": ""07d9e3aefc4093a49121c91ef65e708b""
											}
										},
										{
											""value"": {
												""name"": ""kilometers"",
												""id"": ""e19aac86196b2fc4bfb408fe10698cd9""
											}
										},
										{
											""value"": {
												""name"": ""millimeters"",
												""id"": ""882f184dd8a217016e9d9074fe1eddee""
											}
										},
										{
											""value"": {
												""name"": ""centimeters"",
												""id"": ""e6ec92b31369caeccb14cdf8116fc589""
											}
										}
									]
								}
							]
						}
					}
				}
			}
		}
	}
}

        
        ";
            return CleanRequest(str);
        }
        


        public static string BadTargetMeasureType()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.af2b7ee1-ca0a-4c5f-a536-dea869c44c18"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {
			""DestType"": ""millimeters"",
			""SourceType"": ""inches"",
			""OrigVal"": ""4.000000""
		},
		""user"": {
			""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
		}
	},
	""context"": {
		""Viewports"": [
			{
				""type"": ""APL"",
				""id"": ""main"",
				""shape"": ""RECTANGLE"",
				""dpi"": 213,
				""presentationType"": ""STANDARD"",
				""canRotate"": false,
				""configuration"": {
					""current"": {
						""mode"": ""HUB"",
						""video"": {
							""codecs"": [
								""H_264_42"",
								""H_264_41""
							]
						},
						""size"": {
							""type"": ""DISCRETE"",
							""pixelWidth"": 1280,
							""pixelHeight"": 800
						}
					}
				}
			}
		],
		""Viewport"": {
			""experiences"": [
				{
					""arcMinuteWidth"": 346,
					""arcMinuteHeight"": 216,
					""canRotate"": false,
					""canResize"": false
				}
			],
			""mode"": ""HUB"",
			""shape"": ""RECTANGLE"",
			""pixelWidth"": 1280,
			""pixelHeight"": 800,
			""dpi"": 213,
			""currentPixelWidth"": 1280,
			""currentPixelHeight"": 800,
			""touch"": [
				""SINGLE""
			],
			""video"": {
				""codecs"": [
					""H_264_42"",
					""H_264_41""
				]
			}
		},
		""Extensions"": {
			""available"": {
				""aplext:backstack:10"": {}
			}
		},
		""System"": {
			""application"": {
				""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFGETGN2WSE6YICNNRJUR3F5TZZJJZTR67TSL4YURMMJXJC3KTUFXKXHNECKRRD3UQUANBDRAF526CL5FTY6AD7BQRZAXMNF4DSXCYVVZAJHICSGCBTRZXCM4ARPC2WMH4OGOETJKE6KMK6KDI6LNHFW5M3QIHWHX577IOK7OMZGYZL25WKB7PZZKIJF3DLOATI3JGSPJ3VPHNA""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AEHABLPXX35CQ5BP6M4I2BO345GDAEOGMUMMK3PABJMKRGZ4LVLTHOWFYB766NM64UICB4RUWMR5UQAK5BZORMAJ2NFWVQ5KHM6HGAGFFJQSRDXZMXGGF6NA5XLKDITSXZNBEYBXRNP743RXZC6SSHP2EM6Q"",
				""supportedInterfaces"": {
					""Alexa.Presentation.APL"": {
						""runtime"": {
							""maxVersion"": ""1.8""
						}
					}
				}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzODA4MywiaWF0IjoxNjM4NDM3NzgzLCJuYmYiOjE2Mzg0Mzc3ODMsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQUFsdXM4d3BVZTM1QUtGWmYySk9hSUU2WHlNZHYzK3M4UEtJQ08vNUJ0b2wvakhCNnMwTmhLeHk2cWhoQkhYNmdScEFJbFB0bFE4Zy9FVXJVdHpORzZTaDF1VGpMZmtCWm9HZ01PMHhkTmdTU1NkYjFnZ3pTSHdBL1FGY05yWUcxUFZHTElxNlJPYVFxckdtdVhvVjUyLzEwWCtoZ3h1QkVuaGdpenFGUkxCbjZKQndIdDlCNFpuRlc5U1RVZ21UcTVJWllGNER6RFRWdXh3SmU3MWtCT2NvaGlNMEF0MWxYZnoyc3hrVzJ3UEdpdm9yL2RXcVFVNGhySlFBNk5FVWgzczBVV0JNemR6MngzM0d6TnFBZ2tYK0xWVWNJQUJVNmgxeXd3SnVhU2RVcmJvTFJ4aTh0RHpkU3I1V3FWUjdFSzJ2Q0FKbjJPSkdObVFPb1Q0WUZ6YzkyQ1REcW11RXRnbm0zWm9JVFBZY005RVNWTmdmWW9sY242bnNPdUtUUzQ0VE1ESiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.eTUKx5mGXr8B0pbMee_MtavaS8Ps0wxwO-9XQWtJpopvSIH2Fx0tab_1RGA8iBOjfgYZjAeMbLWW4J7-VTvIuObVLtf7vhMKjWaVFEKhykKSTdrwQJ5GwTlxtuvAmLy-erA4rzdESPSc0x2FsaXq7I4jVelOiwt2AkPM5Tr5Vu3sEQc_yBvHjf5rcU0Bp_RfUHvKrQ2M9fGQkY54N4nIzGxAuRM8_rPPi5Ybc1yAxVrikO6VRL6WpkwssagPVrZkcueCwnWCjOtvJ2Xsk4_E5WHWfnIJYgtS6Q9ILr0RmleIGcJBUTNwksEHh3h2hjvgpqZe-DU99T85e8RaBZ0FYg""
		},
		""Alexa.Presentation.APL"": {
			""token"": """",
			""version"": ""APL_WEB_RENDERER_GANDALF"",
			""componentsVisibleOnScreen"": [
				{
					""uid"": "":1383"",
					""position"": ""960x600+0+0:0"",
					""type"": ""mixed"",
					""tags"": {
						""viewport"": {}
					},
					""children"": [
						{
							""uid"": "":1384"",
							""position"": ""960x600+0+0:0"",
							""type"": ""graphic"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1387"",
							""position"": ""960x87+0+0:1"",
							""type"": ""mixed"",
							""tags"": {},
							""entities"": []
						}
					],
					""entities"": []
				}
			]
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.99c1619e-ad1b-4b1f-8827-ef9147809060"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T09:36:23Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""8"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""8""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""inches"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""inches"",
											""id"": ""3e1b00c196db969aa22cdc50c6e966c4""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""inches"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_MATCH""
									},
									""values"": [
										{
											""value"": {
												""name"": ""inches"",
												""id"": ""3e1b00c196db969aa22cdc50c6e966c4""
											}
										}
									]
								}
							]
						}
					}
				},
				""destType"": {
					""name"": ""destType"",
					""value"": ""kkkkk"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
								""status"": {
									""code"": ""ER_SUCCESS_NO_MATCH""
								}
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""kkkkk"",
						""resolutions"": {
							""resolutionsPerAuthority"": [
								{
									""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5.measuretype"",
									""status"": {
										""code"": ""ER_SUCCESS_NO_MATCH""
									}
								}
							]
						}
					}
				}
			}
		}
	}
}
        
        ";
            return CleanRequest(str);
        }
        


        

    }
}
