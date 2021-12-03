using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExactMeasureSkill.Tests.TestData;
using Microsoft.VisualBasic.CompilerServices;

namespace ExactMeasureSkill.Tests
{
    public class ImperialToImperialSampleRequests : SampleRequestBase
    {

        public static string OneFootInInches()
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
			""DestType"": ""inches"",
			""SourceType"": ""miles"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzMzI1MiwiaWF0IjoxNjM4NDMyOTUyLCJuYmYiOjE2Mzg0MzI5NTIsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQUFKQlZFUCt2Y1ljd3dsYU85WUxsSTZtVUtpRGRNQURVVXppZkZpZWl3YzBENGphUzlONjI4M0IwSVpkR2dUMDdQcVp1aWlTY20vKzFSWUhwdmp4UFE4N3Z6MGwwTWNjcmpaeS80YWRrZjd2cUtQM3ptNFVnbngxNWlsUDZEbnFiV0VuWXBrZDRHNmpDQ1JQT1hDbmNnZnZ2ZUNwZXo2M1ZlZmlyandGOStKZ3dKTjQ0b2I1dU54M29sOXMzNFRNQmIyMFAxcEpJZXR5T2RWeE93S2l4WndVTVRKR1BtV3R5NDRieWVBTFdPUXpUeUNHdXBRcnl4SHlvUVB6VVEvclFzVy9RRXBnZ09GNjZubG9GeEltY29NVzZvM2xkaEltbTZsMXlGRVpCWjJEbkw3dTJPamltZWhaMW1NUjh3VHlwNXNFdFFrc2VjYW1DMXRWY0NjTzBjeVIxcUxVOC94UHJqL0N0eTM1Tk82dnRDS0FqVUNwUExhUHJIMXcyYWd0WllsYlBaWiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.XtEM9NyFTfSpwpaGPEWTo6bcDrkKf_ZVtKM-rfsLNRsQ6RX3yki4r8rXt0VK5Kv8oVHetQZ1cCy3HLQ-haduOf7nMV-QqSlqqxcE6_E0p_-GYOx7YLwhUvgRUCiMMXD60HUtwqiv00-ppudrTpijHSS30xeH103EaEm-hyGNfm0_ZaiEzcjWIFPHrHCgamev5vis5Vv-vzExBS7XLRQBmYnkb2BBLKZWQAyC3LM9VPji-IvU1DLzjMLaoujLQBxVGSWkE2RhD545wK6ZpykHfYbwR430d0b8tXKb4zBeH7-Mq6z5faG0ahvfu_IPfdYy6xk-0jRelPe-mgh26ZHxSg""
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
		""requestId"": ""amzn1.echo-api.request.8a2b5e1b-a6da-4e63-8fa1-b290021408e3"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T08:15:52Z"",
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
				}
			}
		}
	}
}
";
            return CleanRequest(str);
        }
        




        public static string OneMileInInches()
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODQzMjEyNSwiaWF0IjoxNjM4NDMxODI1LCJuYmYiOjE2Mzg0MzE4MjUsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDSXlqRU9QRFUyMzIwa2pndmpTK1VYSkFFQUFBQUFBQUFwVDRHM3BhRFViTW52SDJ5UURhVEZpRG5XZlNPVUNuK0xBWm1NOFUyYlI4TVUwSjJ1TFhDU3NPeXZvWkRrc2VjZ1lQazZYYzMrUWovb3JSZXBxOHIvNVUzS09iQ2Rla25Kb2oyWHdRT09qNmJQcmd2ZlhCdG5ySmdxN1NaSjgyQnhmNHJ0M0xQcmFpeEdLdG5pbVRYeWdsMmJDNEhhcWJNUDBvaVZSMkFINll6bHJ4amlSa2RiK1ZWdjMxcVFPZllYcEpzME5manBZMGNlR0EvcnVpSVdvT2ZSQXdCT1VjOGpJREJtWXVLM2VsbTVyeXZSTGE5RTJQMHRWb05LUStna0tzbWVUbnhFN3c2SW5pbFpVQm15MklrQm0zMDlTN2dZTmZld1A2SlJ6aWRVaGtWYUxjbS9wQzFJTkZXUHVvSXE2OE5aWk4yS2tnbzZ6Y3N5alFpRXRWcU5kbXY1cDVjQnRLQzg5YStBMGR6Y1p1Rkc0MFJFZWdDTDBUSVMvL1FDdFVOOCIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.KWsrznoQMzyX6dsHcbNfS8Di-pfv8lONGHaLdjcPbINMjYnhNJL7AFz0-NEBvvsv-sJj8-OK_vQ9DALSJ1pj7BqZ71be9_66NIiMl4H6SZ7zSjCi7p_lyXQnXlb6zOnifeymG3XxIWLazYwADFztm7oi-Qhruw8nutV2nFXwX01Mu4M6vbFHpKO_hE6WkJAvII0OV9C3NSWFqjCScFgLv9m6JzF9u_Rh2WedG1EFEKj8n32EF85TMW85HHrlzZ3HjlsQ4n92DPvDaeSBxXTMGxdBnSBdr-JGZDegltHkWI1GkcgS-DLx2P5lLoqi3yvNCAaNc3ze0W4SyP719n-vHA""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.0714306b-38f4-450c-a5bf-158c9f4250bb"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-12-02T07:57:05Z"",
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
