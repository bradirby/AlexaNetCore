using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExactMeasureSkill.Tests.TestData;
using Microsoft.VisualBasic.CompilerServices;

namespace ExactMeasureSkill.Tests
{
    public class ImperialToMetricSampleRequests : SampleRequestBase
    {

        public static string OneFootInMeters_TryAgainInMillimeters()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.d3b39e0b-b3fa-4c8d-9a49-0b33ab04675a"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {
			""DestType"": ""meters"",
			""SourceType"": ""feet"",
			""OrigVal"": ""1.000000""
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQwMDc5NywiaWF0IjoxNjM4NDAwNDk3LCJuYmYiOjE2Mzg0MDA0OTcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFEQzZNc1g3eFpKcG9sQ0VQVnI0cDErSkFFQUFBQUFBQUNtVzJjbkVrTzM5cTAxdWZCaXBudG11TklJOW9UejBVNXpVNmY4NTZFb2RWQUhXbTZrS0pPZEJIYllEeklJbG5qOWtJbm1hQ0hQc0FkZ05ZQzdxR3QrNUZaUkF4K0NjSEVUSlhrQWV0TEZSdDU4Z1ZmKzNUQlc3NHljb3BCRzJVRkFmWFJaQXdBckJjbk05WkpPK01OZXQ4bEVDTU9uWXZqa1BzVUtXUUpYNUs0aU9jd2lsQjBEMEFNYnJhaVpibFkrVVRvTW5TSTlvZUsvMWJSY0g5d3hqeXVCSWZtZmxsckJSWXR3YThoNU5mYmZ3S3IxVG80bjVTbHN2NjdoYmhxTGw0RTZ1V0tvaDRabHl4aktpc2NFZ3IydjE1SXZicVYzMS94ZmNVa1JiTVhaZ3JsUGtyZnpPUTVpVWFSZ09rZmdTRDBJakpYNW81dVhHczdSWUZ6Z2cxZzVoT2ExTXMxdTVCdldZK05JckNHcGpWMmR1WlRQU1ExK0VNQnhwVlpCZ29ESyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.fDzzDC1RjFZVnF3c-diIH3cDqezxGrE91d_Na8o7aPcDVQ2i7VYW5qsIRiOKRH_dK2Au1-h6TMnv8BTisjJtuN4YYRZ2tD2WRGbd3gdNEEc75D0vXgeniEJrY_Itxjhnc0qd8-9N1xVnsCUx-jAIS3Ll3Es_zO4fCETnFQ_fTSsyQzOJwniUpmqv5RKkvHnKybBC9ftwVPMXOzQFcMSz6WH_5p8C5g3ST_mWvU5v0mqVb0x8aH9sOMAKYhQZNNjG8iMd_-a7ZJxKFqwbk3O9kBfqKgpw6lp-1B4cklvaluak5969G1rsQboEU4_JWk8oYLqGDZQPkxlte4mFFDWlNQ""
		},
		""Alexa.Presentation.APL"": {
			""token"": """",
			""version"": ""APL_WEB_RENDERER_GANDALF"",
			""componentsVisibleOnScreen"": [
				{
					""uid"": "":1014"",
					""position"": ""960x600+0+0:0"",
					""type"": ""mixed"",
					""tags"": {
						""viewport"": {}
					},
					""children"": [
						{
							""uid"": "":1015"",
							""position"": ""960x600+0+0:0"",
							""type"": ""graphic"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1017"",
							""position"": ""960x87+0+0:1"",
							""type"": ""mixed"",
							""tags"": {},
							""entities"": []
						},
						{
							""uid"": "":1032"",
							""position"": ""307x307+588+87:1"",
							""type"": ""graphic"",
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
		""requestId"": ""amzn1.echo-api.request.fd544967-8463-4205-8c8f-60fa50dccc84"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-12-01T23:14:57Z"",
		""intent"": {
			""name"": ""TryAgain"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""destType"": {
					""name"": ""destType"",
					""value"": ""millimeters"",
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
											""name"": ""millimeters"",
											""id"": ""882f184dd8a217016e9d9074fe1eddee""
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
						""value"": ""millimeters"",
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
												""name"": ""millimeters"",
												""id"": ""882f184dd8a217016e9d9074fe1eddee""
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
        
        public static string OneFootInMeters()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.7eb7e948-16b2-4d88-bb65-9073bffe02ae"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDAwNywiaWF0IjoxNjM3MTg5NzA3LCJuYmYiOjE2MzcxODk3MDcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUQ4OWFZc0djcXYzNlVVSGtQVjBkTHFaRkFPYzBxS25nSkMrVDVHM2Z1YUpCa2Q2UmxiRkNLOFNVb1lvNEt3UVVJQmVsQkIrWlNNRXhkdy8wRHdzNlpPZkU2NVoyVXFpcVdiU2s5RjFwTTJ4SVFTYUNvWFVGOEtYRUJ2UDh0cEd1YjZpTkNmb2h2d01jcWNWa2FISVozZ1JLRkhQWVFkVURGanFQblZhTlpUSU1LcVl0RUx1d1FndDh1VzViUU1OUkZLTFlrZDJ4UU5ucTNqRWVDSE8zV0JEeW1ycmZPWmZGMVh2c2R2SFJWUnVpRGxOSjdFOW5FUDBOTnVDV2x1VEQ3WGs1bks0NmRWbEN0Wm9UNit3Mk9ULzdsNHlKVmtVS1hYZUIzWWdVMGIxWm5pSzRNVXNHR2xMQkE5UFluVEJCOHhaRkd3ekJYRm9wMG0vNlpQcnZlQnM4aVZRdjh3bndsdHM1U29LMkIyRjhPeUlRTHphczNyYnEvdjZJN293ZkQxQkZyRyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.dGzw2fUzQQWSld-F-OL8NeeI4fVjXCKBYbWTjodOJCJaX1DAS41rRfC1rBD4cTraNNBvvglYzvkpsmJ3ti32RAymdW5Q_F0wptlmqej07VCSItqfZl40AA0WLeweti0KHvzp6OhPxCvlpONmY9fmBlgtJ1aXNxCGHNKxCMlk6JieRDKCuaYiBYhoQkjWG0A4eCHzCU1MnApHAGcIPNW4QUuxpT9MDcrborBF69E6-Navt6fUFQ7pDfvMrkS9v68kg-ykEw217jqvD7uWf2PsnEEDmWrOrknFlOw9Duik7RCoTzv9VYKXIPCXr6h_uRtEG1MLwm5S-mYAFJVnhGQWJw""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.cefdaba3-8826-4253-b180-5757e5e90ae0"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T22:55:07Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""1"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""1""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""foot"",
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
											""name"": ""feet"",
											""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
						""value"": ""foot"",
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
												""name"": ""feet"",
												""id"": ""e03f9063484fb1967d1675c86a6094d7""
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


        public static string SixFeetInMeters()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.e4f4c3bc-42af-416f-8c0c-191746d18de4"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDEzNiwiaWF0IjoxNjM3MTg5ODM2LCJuYmYiOjE2MzcxODk4MzYsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUN4M05Zb2wxSVQ4cWFHcmIrK2EvNzhHVjdTTjVQaDRQenZnTDVjOHY5Vms0cjJQelEvazd4QnJjL2d4VjBQaStVT1o0eGYwNEhnRHdueVJ1cGZJZmZQaXNtNHdSVWphNnhLTHN4V29HWmhORHdueUl4dTd4MzhjU0ZBdW5zbzJwM3VleTBLS25ybmEyc0h6czVxS0Q4NWtUZ1daUjJ5YnpYWlVUT29xM2ROSUtpckthU3d6MDI2K2R1SzJQQ2hZWUYySE41OTR0c2IxRTZ4djNGclByV0NzR0NQTkN1MHI4RFovZ1Flc2E2dzUvNlRaMU1mdUJOQ3JFS1hnVk4yOWVkckNHbGpjM1BGcmJDaXE2OFpxRDdHaktiS0M2NmNueGswNlBDQTlBOGlxTE1Rb0xqNWhQWVU4N2N3SjkxSVhLYzlJR05WWlFuTHdpUXpZRjFCUE91VzFueTZVUkI4TkZlSGlTODZCSFlBbGV3QURlMjNWZU9sVFh3MVBER2VuZVJWWWZqNCIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.MeeWYr4FPWvopr-0E3bzpkMWcr74Z9XvKnd06PpWiJDR8hTXMFNrGmog81-FZ4DflUbM2glvHihWrMMK3xJhrhBmr5rv7_zNtp8Utln7lEYzwv0b1IzeTwDHQiJmVwMWfY3WlY3KYTiB1-JaIb5pADVRcZm6paaRmj1fys5VNGx1WR0-fTZasHmPP2UW2y9BhE_ZUK-e2b4AJD4k9iDBlAGMHDbNm_Cgl6hpQP9WdncC5zYAgHzELrKUuQQFuzhYbPBa6O2mMZuR4tzk24PGvhDWSzE55OJZI4USfduRGdtWLHktEKvcT3RouFW8NCiBBTSie-MfQ61Q85Ijpz6pEw""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.bff5b286-8fb9-4654-8b2e-770d398950ca"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T22:57:16Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""6"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""6""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""feet"",
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
											""name"": ""feet"",
											""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
						""value"": ""feet"",
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
												""name"": ""feet"",
												""id"": ""e03f9063484fb1967d1675c86a6094d7""
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

		/// <summary>
		/// ask exact measure for 6.72 feet in meters
		/// </summary>
		/// <returns></returns>
        public static string SixPointSevenTwoFeetInMeters()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.1702a483-5d93-43dd-b17d-3c63b773493b"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDE5NCwiaWF0IjoxNjM3MTg5ODk0LCJuYmYiOjE2MzcxODk4OTQsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUJNL3d4Wi80Sks5TFRyZ0J1dldiVGVkdGhzcndLdFZVc29maSsvVVpRT3lTZjkrMG9MczdrNXZtRzIrSGU3ZGdpTkVLMTlVbkY1RGpmcDRSY3E5b2V2ZEppdHlKcHlnOTE5VmdDcElCc2hidERaVjlUWXowaVFuRG50OXV1TzJVT0hwQmhUeFRLaCtiQWlZSm5wS3lXV1hvQkJGcG5DQmxZOFVKbmYxWFVEYUJjTmZCVnVXeXRYT2d0R21aQlgvRzJIWWliRi9UUzBXNHkyUnZ6WXFtcjhpZElUTWppditCeUxCTkZuUWEzZW90U3ZIaHNsaUl1RSsxUVhsaHFkeDFTd3UyWW9jQzhCbnExUWxkdGdjMVFLQmNDbW5UQm12Q0FENmltejdYZVhidGdqV2xRWUFFM0lGb2NPVWtDVlR0WkVQK0h6V3JqbDV0Z0gxWEZxcE8vTHE2SlRvaGJZV3RLc0U4b25DM0RZOGF1aFBuK1pFam9peG9HOVJkNEY4NFVZQWJITCIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.JuPgW2iw8-U6qlsqmqJJeOJ8--BhdoJo7zNHAn7UAQMAy0MS-DX_DrqVnvELQX5bzR2UmiaDLgleZjfy5Xsz2Fg0Soi-l_c0PI1GLrmjOdUIQX-npejMo_fpxAzrwJUQXJ8MvDPLPXZUMWkJCiyr8pY5-fPX9D7CtSHmwv6313AoVPWMGoc9J8aI3_smOq12Lf7BEaYfQIS4Uv5unRYudmUp0eeaNwB2PSVtbbp9AaMYCDodqvM9AjyHUCBPPAX8RjtWqO6_qpkiGacRtWeJunlYZagFL5-NqYUK-y_3HLWz7VLvQTcjGIi2aOF_6kgXv-4Q1eHMr3WXF_KbVUXARg""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.01524287-99c5-41aa-ab50-bfec760c73f1"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T22:58:14Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""72"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""72""
					}
				},
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""6"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""6""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""feet"",
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
											""name"": ""feet"",
											""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
						""value"": ""feet"",
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
												""name"": ""feet"",
												""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
        
        /// <summary>
		/// ask exact measure for seven miles in meters
		/// </summary>
		/// <returns></returns>
        public static string SevenMilesInMeters()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.3e1139e0-8674-4842-aea6-89268a2d6b9a"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDczNiwiaWF0IjoxNjM3MTkwNDM2LCJuYmYiOjE2MzcxOTA0MzYsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUM2S1IzVDBJZFJJaU5EVG1ONFV5elVrU1N5Qm5vWUgvOVkyR0RJbVg5Ti8zQjBHRyt1a3hoYjl6SVBxcFllMjdYK3hxYkRKWFFDWFFpZVVwWUxhK3p0czlPS1p5czdIYnlQK2ZobFd6QlJjRGhqNk9tVEF0WWpTSEdhMU5BLzJjTmVwUVI0dkRVamxOMElOVXEyOFRQMVNEalMzekV0Z095enE3Y1RDeWt5M0NKUG9UWlN1RFlXVkFzWDdUdlFHTmlzNWJLOW5lbmhEekRqenZjaVQzb3lISmwrUnE1UEo2Z1pMS29uQnd6ankydWJ5c3Bwc2R6NXNWU0JRTExMS3M2LzF0MjVHNjlLRm14V0wyR0lnQUlFVXpocisyU3pRNkduQWFaRDhRWm0yd3R1V1ZreThVVGQ5WTFUdkRJQnNMb00zZVZtUGZJbTNsVlh6SllQYmtYZmd2L0tsalhtK0dzTjlCZW5oeGxwZTRVNUg0R0R2MEp5WGpBanRuVmNvMmtBdjhqRyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.NkC1H49pjLHUEd_zILgSe2A_AMbUYrVjrvaKEX41CTlPNn8nd51n3Dg7bAQoMQ-XQaKKxQ66jCveVfy3dY4wRdVsDVbiU0Ng-W6fdFKrdjlMPOjuZnM1evDubMpNMXb5qP5dPfu0lr4yqBm13kvv_xyiB0L_3vXsIQQ4l4e32qkoKcEQnLZK6NEYeUnnRHakaakkEzKGobaZyn-oZoIGhOENRjfbdTS-qapyTSHB4aZE5nxZT83i4k5BI9BOCRLVU5attbpYHmEYUlbghaV106E8uWFlbvrzJBt-NhhOcGqFUjysQrY6jTeoPfMx0NNQ3iwzaLuID-oiRcDvH82xTQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.7d7c259b-b61a-481f-9076-3ba47516c85d"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:07:16Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""7"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""7""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""miles"",
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
											""name"": ""miles"",
											""id"": ""6a81060b83b919bc115112bf840eca63""
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
						""value"": ""miles"",
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
												""name"": ""miles"",
												""id"": ""6a81060b83b919bc115112bf840eca63""
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


		/// <summary>
		/// ask exact measure what is 1 inch in centimeters
		/// </summary>
		/// <returns></returns>
        public static string OneInchInCentimeters()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.404cb969-c435-43fd-b1ca-f466b6b7085a"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDMwNCwiaWF0IjoxNjM3MTkwMDA0LCJuYmYiOjE2MzcxOTAwMDQsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUFLRW00OEkyS2pkSXEyUi9Wd3NLczAxeUNtUFU3L2RDYVV5dFd2UkplWWtTQ3l3SmJpMWVIVi9ZWDR3Rlc2bTlqeTdtbE5vbERjZ2xKMXV0bHdLSnIvRDRYUER2NlRRK2ZVanZEY05oRnppR00yRzNsSjZOS0tPQ0tqTFBrOC8xV1FXeWxDMExOdGpETDUvc0p4cjVHM3hDRUdNMXZWS0FYVWJlTlduWUw3ZzF0WVExcVhsaTFMbm11OWZiUlYyOTZ4anoxZlc1VWRIakxiRkRqVG9NKzNpbjFWUHcwcmdTSjkxREZGWXlrYUZWL2kwb1Zvb3Z0cURhcEI3QXlhVUFKRExrZUZqVWRkZjlsU3hJQ09DZzkxMUp5NlNUbkNmTUhmMkV1SmhsUlFZOU5CL1VKcS9KenZka2pCdG4zRjFLVEs3L2tadUFyNHB6UUQwK0w5R0NwQ2NuM3I2MUo5cUJFa3dTVE82VytUNmUxZUxaRWcrbk1Yb1JPWXVnZXJ3WjNFQnhFSSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.e6PmBGaOmkARkGoDip0Hx3SqMWDPhK4wuZK7oVtptUQ9s6EkBqjoNF6i4Nz_PNIHRbxjNlDmaS1Mrtxb8RNjrag5_Gx3KO0cZJA9F7CKodY8WkJDn4K0ymEABVpSgkuUMB0oxTNVn-470-2wD6X3Dra0kZ0PDk1ZS5s0ctkZjeM4RfhD4zPSSURfhuY5fi7Vw02uFju1bZjra6fvuB4_b1-acyA_75Tzz89AB1oKyoZJZ9jMUofXnMHJ9B1cHMwTtKTDP7WMNhI04A_87QkLl_CIUd0Ww9Eo5iw8mCHjPw2m0mRkosUhNyeFP2l6JFr7fcEcwzpcmbvOTwuCQFW9EQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.d08c25b8-b7dc-4f85-ba81-6f6db2835bab"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:00:04Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""1"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""1""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""inch"",
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
						""value"": ""inch"",
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
					""value"": ""centimeters"",
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
						""value"": ""centimeters"",
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

		/// <summary>
		/// ask exact measure what is one yard in centimeters 
		/// </summary>
		/// <returns></returns>
        public static string OneYardInCentimeters()
        {
			
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.36a017a2-035e-43e2-9986-0af7ba8b139f"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDQzNywiaWF0IjoxNjM3MTkwMTM3LCJuYmYiOjE2MzcxOTAxMzcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUI4eXNiM1FqQXZLUlk1UG1lNlJ5RzFUMXVFRmkyVXczTGNOdkw3d3FFUWx5N2E1SzBuS2pIWWNkYURtZnBpNmRaWE5McW84WmJpK1JOY0JsU2VWazlMK3d4SU15UkJ1VUZjc3ZNSmh5TUxqbEM4cVlFWWFQSWJDS2hpSnY5dkxpWFBTaXlNdzhHMnlzMm1jQXVLWnlVNjk4Si9kd2JyZjFLdFduSVljeUx6bG9yWFNxZkVuOU1ld3EvK2E5SCtIUnBrMGNEem5ITytrL3pIQmd2R2JHVUU3WEVWeE5KYmVScmJYNzcxWmJ4SXBGZ0x5NThERDVPNklLU1puR2xyTW9mRDhvdWNKQWZ2K2NBMFRlakpKUGNQdVZRUUxnUWRqOTZhSHl0ODFQVTk1RGRsak5kQ3M0ZDdpVnFDcEhGajcvV0pycVhEbWYzMkZhYWYwQW5zdWtsZlFjT1lwVmRiV1pwZlpLQWdWS1NYVUl0NFZHNEtZM28vamhEa3FQR1E4OFdXSUM4VyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.QhnHWXVeI4zhh4I2PGN31O_fvZOZsiXdUg8BWeE6gB_Iu1syuiGaNqTM41jlVsrO_9vYjbKcAvNzqxSX-of6VabvAa0Ivaqj5giPCDx-KnoZRybPHX5O5cUf9p-tU0ovOl-2fpvSkkRlDI3Jx4iQquuOhi5Ek6YTkRpG0hxwr-aTR9tjwS5kGlMBSoS3eUvxC0LT465YoeUO--mvTXKBzY-oBq719paQavxpFXFghVTANPoB8MKCVsd2hQ8rf2b-8xnkm7g-2r42YXeZfPUEX6QZ0r_KT3-c0_657jk1p3LF0hVvLztT0vZffMgpkZIzC-M4oacCBm6KxV2Ekhx09Q""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.9a09d594-2f78-4037-9afa-ce135c9fa3aa"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:02:17Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""1"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""1""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""yard"",
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
											""name"": ""yards"",
											""id"": ""1558f5ebe39c9d140d40659b809ad019""
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
						""value"": ""yard"",
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
												""name"": ""yards"",
												""id"": ""1558f5ebe39c9d140d40659b809ad019""
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
					""value"": ""centimeters"",
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
						""value"": ""centimeters"",
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

		/// <summary>
		/// ask exact measure for one mile in meters
		/// </summary>
		/// <returns></returns>
        public static string OneMileInMeters()
        {
			
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.4718cb58-64b7-4d21-ae7c-7e599a0e2a03"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDM2NiwiaWF0IjoxNjM3MTkwMDY2LCJuYmYiOjE2MzcxOTAwNjYsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUFUblh5TzF4RXBLczNKYnNzdDh4WjdvZUpvcjRkMWcxSXoyU3VicnR6S3RaSDFXeVJKVldWMHNVMEdnblhxUkFHdy9YeWxuaFVoNEZwYjlDOTV1YVNmMm1xMHNCejArTzNsVEhqa0xQWmlJT3N2SlBxWmlFeDUxdW82aHFGS0Uwc2NVSjVpak13MFIzNDRFRjNGZHcwNGFXYU1PK0ZxRE8wdlBBQlpSbVB6MXNqbzRpR2FhRC9Lc1E2ZHB0RnhmRDBmYTg5NlhHSk0rVEpDNmZPVjJmOWdESHhrMmlJWmVsV3BRZDBrNndJb3NWcHpLd01XeGdGaDUyRXl4RmN4QmlmZVBhUXRIZ1hQZXVHcElQRTMwV0g5WjdBblFoUGhXcld5dWpMN2ZqVGloZlBtWVR0clFHNlNQY3dNWjFKclIwUnNMb2ErR3RjK01iNm5vTTNyeEtpdjhTbXJBSVQ1Z2xLQlJZbVFDdGVXeFpYOFNmbEpTUHp4b1dnVkFZWU50cU1jR01RaiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.WmbLwoYhlh0ROcmfPbRHbiDAiIK3DzcModiRmxGAxkAyS3eILxTevCCsR3bkvDSl_3edrSVe-bRW6tn9x8hMieHO7241zu9L1kbKg9jvsfamJTVnFC4sEpJf-JANoT304yxU4XfEubf24X2YY2EfkZg1sEMlRMM21A1pTpz-P_7s3fFON1gJ-iXkKlEDvGRslUDZNky0vvTPPbGAOQ3IYk_XEMpj873wyZodDab3JwL1EzO4vrWO0UuveMe8GQiLsk8KdB1lf77HaXbNjIL87dHOD7RqvfjVGKYVKEgqlcGZ1LBC9rQRAMZu5vD9u6ioBpgJ9mLGE3ZODycDFgWdUw""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.aa3d7f26-4a49-4fdb-b82f-1101def6035e"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:01:06Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""1"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""1""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""mile"",
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
											""name"": ""miles"",
											""id"": ""6a81060b83b919bc115112bf840eca63""
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
						""value"": ""mile"",
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
												""name"": ""miles"",
												""id"": ""6a81060b83b919bc115112bf840eca63""
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


		/// <summary>
		/// ask exact measure for 2.2 inches in centimeters
		/// </summary>
		/// <returns></returns>
        public static string TwoPointTwoInchesInCentimeters()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.fbe97111-b827-4d75-92a0-13c142a9f281"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDU0NCwiaWF0IjoxNjM3MTkwMjQ0LCJuYmYiOjE2MzcxOTAyNDQsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUNWWWI3YU1aRGs1bzhITXZmUyswbkVXcmFxdFdhdEFUL2VQc2pJU1pWTkJjMWhESjFPelBKTG16dHErYmxpY0NuUFFidHc5cDBDVkNzRWJMTzh6ODRQQ2ZIaWRkdDd5b01JNVJ5M1hoYXFtTnBxUmFWMC9mT1pFcU9Jc3pBN1MrREtGQVhZQVNLWnYvTXNwRSs4cytDMk03OWFWWU15REpoUXNFWlZyNkhCZjUza3l6VUdpejdtZGFTdGY4MmtzU1hMbkNsMVl5YXQ0VlNUOHRGU0xGK1JEd0owU3Z6b3BaVFkxbGx2SjJNWWdydjhGbUpTemV6OHJuU1dtVFRjc0hSd2I0Sm15TVJtL1FwSE1XaDY0VWJBVW45QjVSV1Z5TWp5MzJCUXF2NmxFaG0yVlVFTFJmK3hvVWppUlQ2OG1UOVQ3Y2Z6ZzFVdmgxUXRXMGpHZGJZVEFLTlo3a1dxZ0hBU1YwUEU5K25Zdm9qT3NqS3oyNXdCajBmVW9OYWYrZm85aWY2TiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.CLHOFW4pusuOpuRIits8EYIOyNCa5HsWodmJ1_cCYdmrJFYDsS3WM9ZGFAUiCnHLDywzMjWU3sKVPpD3rE7qCYWJ706BZ5u6es2su603K3VZ3zYa9ffvu9wK0nuCRxezrnEx9MfrQfs1qK-G9bwJLGpDN6h9CxWxxIDc-VC8CvC-f0BH92YHT-qecbwMsfp_pq7_5OcK7zjWd1NAGMUEeVqfNU8-xTK1JKD6aCCgr8jkDAEW2DDn1JmZ0rwYYj9yhCjWjdKnnEYqSUGtNlhOV-JrLPhQaVHO8PChFHBFi_Rb1oiN_1vAU9nDlFC_R-RzWue6gC42sYGd32tZtypogg""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.b5a5aaf9-1f8c-40ef-8090-3f92c85d0add"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:04:04Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
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
					""value"": ""centimeters"",
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
						""value"": ""centimeters"",
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


		/// <summary>
		/// ask exact measure for 2.2 feet in centimeters
		/// </summary>
		/// <returns></returns>
        public static string TwoPointTwoFeetInCentimeters()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.2ce66d89-b8a6-4cbb-92c0-cfa342780395"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDU4OSwiaWF0IjoxNjM3MTkwMjg5LCJuYmYiOjE2MzcxOTAyODksInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQURlUzIvMHJLSHRBdzB2aGJ1M0lXc2xiYldHWFQrT1hIeFg2REZSOUFEdDNEclZia0pqeWVyUjdGbjdCN2s0VUt5RThja01wYWJ6OTN6cThRTkFDUWdGWHZHbk9MNVg3aDY3bGtHbmJUNDlCRnk2VENVb2xiOFdsakYva0dJU254ZEJkSzUxUnl2ZGVXVjI2dzJZVEFxZ3JaaGlvbmhnbU1HMGNaZkpBdDUyQkpwN2U2MUIyWW03SkNCdXRHcVBYU2dpbkJ3QlNxWmMzelVPVGJpUWtOTHVoVUJqTjdaN0tiNTcyVGVkaGlFUmVmYWxIbWtMMnRSN2ozdHdOV1Z4SmhsMVVSWmNZNVVHQkJNYVBLTFlxTURGaGpkS1RoZkMxQWI2VkExNkdCSVAyZGhvalpXelRPMFhEUWpkN0FUcnkvTitmOFdhUFJMN1RnU0RqSFBmNEJ2OXN2L0d1RVBqajlnSVo3K1E5WUoyQThEYi9vc0krWVY4MUpnYlRUUmJ4NXlLZjUwYyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.A5f0F8SiWrT3E7cSdCoU-Egs9FaZ084yLmLw9bXjJjJBvxeEpJq6OdtztH__Mcmt6XseP1yH3ToGmIAYsJTGQzMpTfK_ghrZEBHR44aYgTo2TqwSAW6k-PrD1pzmbRsiaZhXH4pDOr6fK5yFxhfJAN-YyLa65Ziwi1WcnIrS817zRhTQgoBtgipezpXPjU2AXzbRQyiRurNjmUedXAdKS8_1MLveXgiuLMG6JS4llP6JK58zngLfJcLvcExYEQYpD1otrUqd7LAuAZU1cHlbcQ7rg-8O5BgtZtsKB2QMFJZoZbVstmCQ5qJZ0TRAUuTIvruKIdhnz7T1pTB46GTVVw""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.106300e1-e783-4e2e-a759-f3c89e45e9ee"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:04:49Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""feet"",
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
											""name"": ""feet"",
											""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
						""value"": ""feet"",
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
												""name"": ""feet"",
												""id"": ""e03f9063484fb1967d1675c86a6094d7""
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
					""value"": ""centimeters"",
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
						""value"": ""centimeters"",
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

		/// <summary>
		/// ask exact measure for 2.2 yards in centimeters
		/// </summary>
		/// <returns></returns>
        public static string TwoPointTwoYardsInCentimeters()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.0a11c70a-9edb-4b99-a380-56865233c226"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDYzMSwiaWF0IjoxNjM3MTkwMzMxLCJuYmYiOjE2MzcxOTAzMzEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUFoNzU0WXNJL3Zpbk1xYmFiZUZmR2k0UC8yVFptWko4Q1Zxa0JWWDV1bDVJbkxoaC9SV1YvRzJLdURpYk5XVXR2SEo3TWJkMEo1VHRQeWdvcEhPWG5zbjdrNmR4QS84TCtYWkNzTXN3bDZlMHlXQlFsamJMMHYvSGwvNFJLME1CeFE1aWNQM1NELy9ZSzhTR0hobWloem91SzNJL1I3TmIwTXhYRElUN2hzL25nVUtMeTBVZ1ZWZGZ2azRUMjZ2bVNWVjMveE5WWThqUW13empJcDBaRzhhZ21IS1hSc2JUekxUdTlFcnZSaDJlYmtyVVBzTFhucjg0cXhqeWRoc2pnN2ZBSjJEMDYvelJIcEV4SHR2bjhQbTJqY3prZmMzcG5teS92RVRVSFpleDBCWWk0aTlGcUx1Y2t2ZklsazYrNlM0WkJUaGJodk1ISnRyb3FzNVQ2ZmR0TGZkRWMvS3grZmZoYUE0akZQWGd5RkZGS1FYWFJaZTgyc2lQdnkvZTN3L2hiYyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.V5-M2QWu1pH3oVkRNvPvUp49Pc3tWpUe5ESXbkf_6yEC4NCBYGAstuRNor9WSg6oJloEEzrP7Dhnao44o55RerwZmeeW1inmxxRncKkSQnJ1RJzCNJOvW-yS2fqXhU9oCJz3ngU-Xvi2vgmU5S96kILIdroZ3dB6TCzpFofNfVqEz_v6gLD-urQBo691V3dfUVJZ59wVPMNKOd9J_iOIaqCjKZjYeMNVutWWWom9p-0SeWKO2iLSIyj6EYDjOvYFFqj3rX8ChqKiZITlxaK8fsFfAhlImTpovzVempBXXCejOHKQ7zHYgSir7VDG9yYKZrdcAgD2iqX16VI027QkXA""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.f4b4bf0d-5de8-49bb-bf86-8e1d55aea8b7"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:05:31Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""yards"",
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
											""name"": ""yards"",
											""id"": ""1558f5ebe39c9d140d40659b809ad019""
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
						""value"": ""yards"",
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
												""name"": ""yards"",
												""id"": ""1558f5ebe39c9d140d40659b809ad019""
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
					""value"": ""centimeters"",
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
						""value"": ""centimeters"",
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

		/// <summary>
		/// ask exact measure for 2.2 miles in meters
		/// </summary>
		/// <returns></returns>
        public static string TwoPointTwoMilesInMeters()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.8ce6c47f-6943-4770-9ec6-cb4621b9139a"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
		},
		""attributes"": {},
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzNzE5MDY4MCwiaWF0IjoxNjM3MTkwMzgwLCJuYmYiOjE2MzcxOTAzODAsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCcXgxbldUNk50aStXUVZ6bjYrbmJ0SkFFQUFBQUFBQUFaaXluRUxPYXNVam0waVlLQVN0K1RkeUZlRDJGTE4wRFhMMUQ1MkdmVDQwVDVUVk0ra3R3ZXdFcUFES0swQ0lDaXA3bU93c3paNVVna0o4b2NUcEpKUTB4VHJwb093cERNRThoYnBvL2ZnWEt3YWp2S3l2WG5NaVU0aUFRcHhaWWJZL0VydiszTWhNQys4Tkh1b05ZUThLbUExR3ZuSVpjV0g0U1JNU013aURUbzJkK0hxWG1KZk52eVBYQi9wRU91YmRPUVYxUFRQMjVUMmo1MG5HbVF2TjNxaXhNT2JkcW5kcWNIaUdOeHVyOFhTa3BVSkpWN3N1U1FCeVFRc2ZwTmd3SWxtcm9PTnpETk13ZW5UanBYWjJLWUFObGZaa2pzWWFET1FnZU9SSERONk1TS2QrWThXNm1sTDU5K29DZEhPU0x1SnYrWkxmVnVXWnJ2K0Uvbk5GQWM3OFk2Mk1kOWdnMkE3ZHZVcFNQZE5SRnE4WkYwSXZqSlRrak1TMTNVa1RtRiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.Wlt4_n-Lm5vMiVXjvWH2H0G4sIKb7xfEe32NOuk0YrsHQaRJEkg2Tcf4E70kqNXIz3xQSeRSuEUm-KLO8Fth-VYbZm6HJq_JaxjMu8sJ4QZReCE5nypCEPF0yA7-I95et-qj3tc3q4J_GEduvtfLL4Wvtqx0Q5fEAz4WLt37FKqMxzv6n9iPWbbOh6pEw1aqh5jmJ2tJ0f7LyMaaqlEXps_a4Z-hazjZ4XNc0VRmx_lEA8mad6Lxa49MH-M50G2El1LOq58E8TALBZi9tnHSH09S7UVFyJN05vsuNiBpcQV1gSULJEm2hepDANCog6fWxEI5fuBwUs-bzKmdtrZ-Yg""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.13ce0057-de87-4e4b-80ff-1bae281b1ee0"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-17T23:06:20Z"",
		""intent"": {
			""name"": ""WithDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""decimalValue"": {
					""name"": ""decimalValue"",
					""value"": ""2"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
					""value"": ""miles"",
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
											""name"": ""miles"",
											""id"": ""6a81060b83b919bc115112bf840eca63""
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
						""value"": ""miles"",
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
												""name"": ""miles"",
												""id"": ""6a81060b83b919bc115112bf840eca63""
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
        

    }
}
