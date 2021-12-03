using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaSkillDotNet.Tests
{


    public class ApprovalSubmissionSampleRequests : SampleRequestBase
    {
        
        public static string StartRequest()
        {
            var str = @"
 {""session"":{""new"":true,""sessionId"":""session1234"",""attributes"":{},""user"":{""userId"":null},""application"":{""applicationId"":""amzn1.echo - sdk - ams.app.[unique - value - here]""}},""version"":""1.0"",""request"":{""type"":""LaunchRequest"",""requestId"":""request5678""}}

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
  ""session"": {
    ""sessionId"": ""SessionId.3f1f8f0d-3c68-41f0-b24e-25c0bd1743da"",
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
    ""type"": ""LaunchRequest"",
    ""requestId"": ""EdwRequestId.d2abdc61-3726-4341-aebb-51c9aa995c42"",
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-30T03:01:27Z""
  },
  ""version"": ""1.0""
}

";

            return CleanRequest(str);

        }


        public static string LaunchRequest2()
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
