using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExactMeasureSkill.Tests.TestData;
using Microsoft.VisualBasic.CompilerServices;

namespace ExactMeasureSkill.Tests
{
    public class MetricToImperialSampleRequests : SampleRequestBase
    {

        
        public static string OneMeterInYards()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.1412af2e-a9aa-453f-9c21-1bda18563169"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.abf39ef4-1c40-49df-9364-a7cf50cfd62a"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-18T20:22:53Z"",
    ""intent"": {
      ""name"": ""WithoutDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
          ""value"": ""meter""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""1""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""yards""
        }
      }
    }
  },
  ""version"": ""1.0""
}
"
;
            return CleanRequest(str);
        }
        


        public static string OnePointTwoMetersInYards()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.677b9f51-aaa7-462e-9fae-70e539286083"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.c3844b7d-4091-42e5-b2c0-c91cdf3eef11"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-18T20:24:15Z"",
    ""intent"": {
      ""name"": ""WithDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
          ""value"": ""meters""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""1""
        },
        ""decimalValue"": {
          ""name"": ""decimalValue"",
          ""value"": ""2""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""yards""
        }
      }
    }
  },
  ""version"": ""1.0""
}
";

            return CleanRequest(str);
        }
        
        
        public static string OnePointTwoSevenMetersInInches()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.d1edf265-4cbd-4e75-a419-92a8810ec175"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.d4e7a65a-dabc-46a7-9f04-319c4f0000f4"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-19T15:24:20Z"",
    ""intent"": {
      ""name"": ""WithDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
          ""value"": ""meters""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""1""
        },
        ""decimalValue"": {
          ""name"": ""decimalValue"",
          ""value"": ""27""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""inches""
        }
      }
    }
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }


        public static string TwentyOneMetersInInches()
{
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.a8e7f662-3acd-480f-bf08-f915ae8ffbf9"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzODMwOTc2OCwiaWF0IjoxNjM4MzA5NDY4LCJuYmYiOjE2MzgzMDk0NjgsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDS2tYK1NtbnpzNHErNmhZTGpHY2VOSkFFQUFBQUFBQUF1NmJSY0FHRWdGYmU3UTdvTHc3RW03T1dBY3d5OVo5YUdjclhLb0ViY0orbWJhZnphSnVxeVlzTy9WWm1hZWJOTERZUExHMmZPcllMTFA3QnlVbXM5RGVSeU1YN2xsN2lneHJ4cVlDRkhzZzAwdzk4blNGNE90bEhnWVVNdmlsUkhqWEd4dTJjeXlBeWFRa1U1aG1KRXVNRDRKTDQ5d3k2NEYxbDFSdVNaN2pqbkNmZkovblJ2MEVTV0lScWowTXRJZGRUWmd4b3gyL3NhWEkvbDQwaHVNTVFVWlJJbmpXU2MzQmx0YUtzR1dTZUxFcmRoa0cxaVBGTWFaQmZWMy8yM3NyNmZaS1RUZzNHajJuNERWMmlxdUd4Q0pTTTgvYlV3clV1Wm9oQmljdTc1enRoZGx1SWFvb2QwOVpWUTF4ZVJPdTNVZmNSYkp6d3hJdThpRTBWSTNUbzFzbUxCT0ZzQTV3ZWEvQXZDYUl3K1RRdmtablJOWXZsQ2VKMzVWWmRWUW1ERSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.esojQHf3rlLr5T7jjBrbGO4kj8bei5lmPGg0vcGI1p4LY016MydkL8_mrJs3DD4I-59Y3wzd3hVSmWpDiPOcLQlCfkgv4kV5T_u6YD69SvZI9qK25uGjleK0BjCj4OwYPZHvf1WZaEQ-euDhgwwv0PGJl30kCVwlJ2Xd9uY9AMdIMb5r81Rw5xgaP9RN3wbhrif__5uUWPjBirrFJur8EtymPO7xRMhZsaETukKDYyXhev-gVviJTxb_lXmOAOu3eUAAIy_mZi_KcqRGkQ3VOmApp5-kvFaMofE171KR1_ZXFntQub3YhzDJx9bkKg88Qncfctt2uN323KuZhCmuHA""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.3d402b80-5555-4282-9c1d-66ba4e2a110b"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-11-30T21:57:48Z"",
		""intent"": {
			""name"": ""WithoutDecimal"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""21"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""21""
					}
				},
				""sourceType"": {
					""name"": ""sourceType"",
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

        public static string SixtySevenKilometersInMiles()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.c4d77372-f000-45e3-978e-01649404af3d"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.da47dcf7-4c54-4927-a798-0a67f8e8bca7"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-19T15:35:04Z"",
    ""intent"": {
      ""name"": ""WithoutDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
          ""value"": ""kilometers""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""67""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""miles""
        }
      }
    }
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }


        public static string SixtySevenPointThreeNineKilometersInMiles()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.b387b3dd-13f2-4452-aeb8-5064fb103b19"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.a52621b1-b675-41bb-bdbe-8cbfd760b8be"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-19T15:35:56Z"",
    ""intent"": {
      ""name"": ""WithDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
          ""value"": ""kilometers""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""67""
        },
        ""decimalValue"": {
          ""name"": ""decimalValue"",
          ""value"": ""39""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""miles""
        }
      }
    }
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }



        public static string SixtySevenPointThreeNineKilometersInMiles_WithExtraValues()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.b387b3dd-13f2-4452-aeb8-5064fb103b19"",
    ""asdf"": ""asdf"",
    ""extraNode"": ""extra node text"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5"",
                ""anExtraAppId"": ""asdfasdf""
         },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
                , ""jffjfjfj"":""jffsdf""
            },
    ""asssdfdfsf"":""sfsdfsdfkljs"",
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""lksjdflksdj"":""slfdjsdlkfj"",
    ""requestId"": ""EdwRequestId.a52621b1-b675-41bb-bdbe-8cbfd760b8be"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-19T15:35:56Z"",
    ""intent"": {
      ""name"": ""WithDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType"",
            ""asdfjfjf"":""ksdlkjs"",
          ""value"": ""kilometers""
        },
        ""inputValue"": {
          ""name"": ""inputValue"",
          ""value"": ""67""
        },
        ""decimalValue"": {
          ""name"": ""decimalValue"",
          ""value"": ""39""
        },
        ""destType"": {
          ""name"": ""destType"",
          ""value"": ""miles""
        }
      }
    }
  },
""sdflkj"":""sdfklsdlkfj"",
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }

        


    }
}
