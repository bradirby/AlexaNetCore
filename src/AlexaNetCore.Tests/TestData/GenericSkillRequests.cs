using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaNetCore.Tests
{
    public class GenericSkillRequests : SampleRequestBase
    {
        

        
        public static string EndSession()
        {
            var str = @"


{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": false,
    ""sessionId"": ""amzn1.echo-api.session.123456789012"",
    ""application"": {
      ""applicationId"": ""amzn1.ask.skill.987654321""
    },
    ""attributes"": {},
    ""user"": {
      ""userId"": ""amzn1.ask.account.testUser""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""amzn1.ask.skill.987654321""
      },
      ""user"": {
        ""userId"": ""amzn1.ask.account.testUser""
      },
      ""device"": {
        ""supportedInterfaces"": {
          ""AudioPlayer"": {}
        }
      }
    }
  },
  ""request"": {
    ""type"": ""SessionEndedRequest"",
    ""requestId"": ""amzn1.echo-api.request.1234"",
    ""timestamp"": ""2016-10-27T21:11:41Z"",
    ""locale"": ""en-US"",
    ""reason"": ""USER_INITIATED""
  }
}


";
            return CleanRequest(str);

        }

        
            /// <summary>
        /// This is the request generated when I type "Open exact measure" at the Alexa Simulator console here
        /// https://developer.amazon.com/alexa/console/ask/test/amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5/development/en_IN/
        /// </summary>
        /// <returns></returns>
        public static string OpenExactMeasure()
        {
            var str = @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.4bb67e53-b3c9-475c-8ab7-e9531e6ea695"",
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
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgzMjNjNDMzLTdkYjctNDRiMi05N2MxLTExMjZmNWNmYzVmNSIsImV4cCI6MTYzMjMxNzUxMSwiaWF0IjoxNjMyMzE3MjExLCJuYmYiOjE2MzIzMTcyMTEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFETCsrdTN2Q2tzeTd5ZFMvTFRjbXc1SkFFQUFBQUFBQUMxa3RiYlpvLzgyRC9LOVhRUHJSN01ZTjUxVHd3V242M0FRQkV1Z2N5VnhXYWRMNTJQU0NnSXJVQnBLMmNPWDcxYmVXdHhiYWpROXpPekpST0tmYnVnL1ExU2pYTjB0cXhUSDcwdDJvMFNlSjN6dFNDZTczK2FBYXZEOXlMZ2R0OGNnbDBPaGI0YkFkSkk0TGo5UkxTUS9zMU1YaXR6TlhZc0RrdCt4RUE0WFlrYlRLQVhUZ3I5TUhuZjNWRXNPR0JHY0FuaXJEc05SdzV0NmJ5b1lCclRIY3hNdGZHNW1LWk91T2owQk9DM3l3ZzdwRWg5Q3B4ODJNYVBtSkpUNWNwWFR3eG1FNDN2YTZwQTZEcVg3R2xZb1RyQXhlN1VqUHFZclVxNkNuRC9GTkJtNXRYN2lQZFlRUkN2ZjBjUzl3RU1kNmRUK0I1cjZHTzloTjhOT1VHRzZ3cnh4TjRDUnd0WXV2K1hKSWVpK0NieHhBTHE3VHZjZGc5RHUvYnB5VVR1TlJTNyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSEFCTFBYWDM1Q1E1QlA2TTRJMkJPMzQ1R0RBRU9HTVVNTUszUEFCSk1LUkdaNExWTFRIT1dGWUI3NjZOTTY0VUlDQjRSVVdNUjVVUUFLNUJaT1JNQUoyTkZXVlE1S0hNNkhHQUdGRkpRU1JEWFpNWEdHRjZOQTVYTEtESVRTWFpOQkVZQlhSTlA3NDNSWFpDNlNTSFAyRU02USIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0VUR04yV1NFNllJQ05OUkpVUjNGNVRaWkpKWlRSNjdUU0w0WVVSTU1KWEpDM0tUVUZYS1hITkVDS1JSRDNVUVVBTkJEUkFGNTI2Q0w1RlRZNkFEN0JRUlpBWE1ORjREU1hDWVZWWkFKSElDU0dDQlRSWlhDTTRBUlBDMldNSDRPR09FVEpLRTZLTUs2S0RJNkxOSEZXNU0zUUlIV0hYNTc3SU9LN09NWkdZWkwyNVdLQjdQWlpLSUpGM0RMT0FUSTNKR1NQSjNWUEhOQSJ9fQ.ZtG75-XR7UFlQXKZ0j0X9NOES6M5KBvhoc8H4vEJb1zo2D5NqfL0gjsb3E_wIilJeLdNu5Qc2yY79cL9ugKwOSWSW7OS5xx4tE1GvNjRTo0j27rDCNnXArdFpb0ZoAnky3vOiqp3ralbtWXzxbhF33YHVakQaEV75t3OLvCeHf78C2MoqqlqSrCvn_WSVBoWv8Nh9O80T0X3IhwR808YBdTVYsPevAmEp5GIaNLo7lgjGeenLVlJaanxK7g3WcIhWudMTVFRcyo3iYmGXS0B-JjixdTm2I6p2omZTsoYWN_xT8v6gVqRUujk-uX5LLbrg8EY6THPJ4yqGDkhc9-ljQ""
		}
	},
	""request"": {
		""type"": ""LaunchRequest"",
		""requestId"": ""amzn1.echo-api.request.813cd910-36a7-4127-8d82-632f41a07bce"",
		""locale"": ""en-IN"",
		""timestamp"": ""2021-09-22T13:26:51Z"",
		""shouldLinkResultBeReturned"": false
	}
}


"
                ;
            return CleanRequest(str);
        }


        

        public static string StartSession()
        {
            var str = @"
{
  ""session"": {
    ""new"": true,
    ""sessionId"": ""session1234"",
    ""attributes"": { },
    ""user"": {
                ""userId"": null
    },
    ""application"": {
                ""applicationId"": ""amzn1.echo-sdk-ams.app.[unique-value-here]""
    }
        },
  ""version"": ""1.0"",
  ""request"": {
    ""type"": ""LaunchRequest"",
    ""requestId"": ""request5678""
  }
}


";

            return CleanRequest(str);

        }




        public static string CancelRequest()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.3f1f8f0d-3c68-41f0-b24e-25c0bd1743da"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    },
    ""new"": false
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.36edaa25-e3ca-4b36-ace0-d647cbbacf55"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-30T03:08:13Z"",
    ""intent"": {
      ""name"": ""AMAZON.CancelIntent"",
      ""slots"": {}
    }
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }


        
        public static string InvalidIntentType()
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
    ""type"": ""InvalidIntent"",
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


        public static string InvalidIntentName()
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
      ""name"": ""InvalidIntentName"",
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


        
        public static string EmptyRequest()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.a8b29a9e-b5cf-4d7e-89f0-6fdf1cdd1c9c"",
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
    ""requestId"": ""EdwRequestId.19bdfa12-843e-4016-af94-055bf1d5c7c0"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-30T02:52:55Z"",
    ""intent"": {
      ""name"": ""WithoutDecimal"",
      ""slots"": {
        ""sourceType"": {
          ""name"": ""sourceType""
        },
        ""inputValue"": {
          ""name"": ""inputValue""
        },
        ""destType"": {
          ""name"": ""destType""
        }
      }
    }
  },
  ""version"": ""1.0""
}

";
            return CleanRequest(str);

        }

    
        public static string LaunchRequest()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
		""sessionId"": ""amzn1.echo-api.session.ce498e3f-9494-4b28-b029-de6577092411"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.6acd2461-06d1-44f0-ad5c-c9a16bdb8830""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.AGTRXT3Y3FU74LNNIASLVD6C37PZAI4IKC2FYEB3CMUM7MRUWAGVLYQQWFIGXC5LGG33ENHGY726D3TIGU25WJZTFZI6R7A52ZHPOVF6XVFGY6EWX2UNLVFXEISZFKK3AT3CKHQQZXCQC3FDNMZSDLKT7YNXHO3H5AFFX22NBENRASTIZLHZ3RLVITQXIFPLHSZZDBLV5NJABZI""
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
				""applicationId"": ""amzn1.ask.skill.6acd2461-06d1-44f0-ad5c-c9a16bdb8830""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AGTRXT3Y3FU74LNNIASLVD6C37PZAI4IKC2FYEB3CMUM7MRUWAGVLYQQWFIGXC5LGG33ENHGY726D3TIGU25WJZTFZI6R7A52ZHPOVF6XVFGY6EWX2UNLVFXEISZFKK3AT3CKHQQZXCQC3FDNMZSDLKT7YNXHO3H5AFFX22NBENRASTIZLHZ3RLVITQXIFPLHSZZDBLV5NJABZI""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AEC6MAIKKWRL7EYPPCCDRKW6F6SALTUIEMLC7URKBCHYJM5BAU7IVZUUNCCY5NVHIBDS6PM2NGDQ42U66RSZE7GOC732VOZCSQWC5APXAMAPBI45N4OSF3XKSF6WERDNHF5HACPRBVHRICXTAQ2E25VAT7ZA"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjZhY2QyNDYxLTA2ZDEtNDRmMC1hZDVjLWM5YTE2YmRiODgzMCIsImV4cCI6MTYzMjQ4MTA1MSwiaWF0IjoxNjMyNDgwNzUxLCJuYmYiOjE2MzI0ODA3NTEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDakhmbHlMcHdmUS8yalBNNUVKOUc0SkFFQUFBQUFBQUFaQUw0emlOQkxlWjRPSEhmSlloZmJOajdPYTJaN3lvMjFrWE5DN090a2hzQkFTLzFWMzh2MlVwWnF2L2NDcUlNZEE3MVZCVnJsSjlRR3h2L2M1UnJ5MDV3dURjV2hldTdaR2xmeHR5czdMZ0paVnM5dVBQVjd5TzViSXVzL0tVbkkxNWYxVU9lYnF3S2Y1Z0tJODhzOEM5NXVHZkVGSEVsdHVGT0FSQnZ3eW1NNzMrUGxkbFREVFNBN0IzQ2lTV0xHWFVsSVYwdEs4U0NSVk1LTHNrdFk4dExkQzRqNVdzZ3NDWlpDNEhyNzc4bVRtT1dGRk9IcE5TQ2k4Zng3YU9WNUdIWmdlclJJZEFNb1J2cGF2RElPczY2N3ZVU2s2eW52ZStNMnJsNGtISzNXU21ROFJobGdXK2VUdWZJblZIM1RyVlBIMmpaZ0piTEZvaml1MG42dTlkSVRqeDhYZVFON2NMT1g5eFordHU2cEZEcm5XNmErcG4zNXpZc2F3VzNEME9JRiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFQzZNQUlLS1dSTDdFWVBQQ0NEUktXNkY2U0FMVFVJRU1MQzdVUktCQ0hZSk01QkFVN0lWWlVVTkNDWTVOVkhJQkRTNlBNMk5HRFE0MlU2NlJTWkU3R09DNzMyVk9aQ1NRV0M1QVBYQU1BUEJJNDVONE9TRjNYS1NGNldFUkROSEY1SEFDUFJCVkhSSUNYVEFRMkUyNVZBVDdaQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFHVFJYVDNZM0ZVNzRMTk5JQVNMVkQ2QzM3UFpBSTRJS0MyRllFQjNDTVVNN01SVVdBR1ZMWVFRV0ZJR1hDNUxHRzMzRU5IR1k3MjZEM1RJR1UyNVdKWlRGWkk2UjdBNTJaSFBPVkY2WFZGR1k2RVdYMlVOTFZGWEVJU1pGS0szQVQzQ0tIUVFaWENRQzNGRE5NWlNETEtUN1lOWEhPM0g1QUZGWDIyTkJFTlJBU1RJWkxIWjNSTFZJVFFYSUZQTEhTWlpEQkxWNU5KQUJaSSJ9fQ.Fr1rM2r_98V4GhYRsaX36G9iPIHiQ9wRXO_aMbS7VdqPwNicNJsmYEo0aL4mZXLusj95r95slI7OiRxyhSwFEDFZIX_9geHFnBts7zlN0j866W62CSjFt5593CkfAg36G3DLdORUnoSPSTrHBjC_tsOH2t4XeDkRJBDDqU65sMGGqbc8ivhRpzFMW4MZej7bFf54i3VvrkaF87d2OZGHEjVkMC0YCXHHSwA9ZcoA9zPIBpWtqtcZVC4Qh61sfJxg8d8vnTGoeM5R7ZE-JZsYC7DNgwE3HQ-48mMcTMwLlWlnkHEodku07YgtPENQIyiRqxNSdGETk1vQIjn2vMbVIw""
		}
	},
	""request"": {
		""type"": ""LaunchRequest"",
		""requestId"": ""amzn1.echo-api.request.feb4406d-01c0-4d3e-aa6f-1da6ebd717f8"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-09-24T10:52:31Z"",
		""shouldLinkResultBeReturned"": false
	}
}

";

            return CleanRequest(str);

        }



        

        public static string StopRequest()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.bbb7ba23-daef-4699-9755-454b3e601cae"",
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
    ""requestId"": ""EdwRequestId.e9dd3904-6215-430d-8063-595279c04455"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-30T18:41:50Z"",
    ""intent"": {
      ""name"": ""AMAZON.StopIntent"",
      ""slots"": {}
    }
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }





    }


}
