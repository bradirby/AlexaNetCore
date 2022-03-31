using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotChecker.Tests
{
    public class DateSlotCheckerQueries
    {


        public static string AskForAprilFirstAndSeptemberFifth()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.f5d9029a-80c4-46a7-9fbf-7888062fb531"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.fca7fae9-ca12-4f77-a7c1-41b30f676ab7""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.AFXVFVD63OCOSHLBR47ATYZ3TG6UKPA7KK5L42DNV5II6NZJE37DET5F46XLF2KDNXHELVHUIO3OL6SWBGK3DM3NSBWEFEI3LFFEO7G274CW3XJ7R5XB4NH2LEYHOEBYWUIQDDJX2XTSV5DQPLRCCQRGFCFWBGQQ6YY5PUN4OZWAIT26XKP2H2QZWRIDRXD5ENPXGZMKIFMALWQ""
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
				""applicationId"": ""amzn1.ask.skill.fca7fae9-ca12-4f77-a7c1-41b30f676ab7""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFXVFVD63OCOSHLBR47ATYZ3TG6UKPA7KK5L42DNV5II6NZJE37DET5F46XLF2KDNXHELVHUIO3OL6SWBGK3DM3NSBWEFEI3LFFEO7G274CW3XJ7R5XB4NH2LEYHOEBYWUIQDDJX2XTSV5DQPLRCCQRGFCFWBGQQ6YY5PUN4OZWAIT26XKP2H2QZWRIDRXD5ENPXGZMKIFMALWQ""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AETGFYTVI7VT2NCHPMRQJ6TVOAVV356YCQA7NGLTX4MEMH2TSBMFATDNO2WRHYPKZGFHA7EVA3RUNNZNP2OEFN2PYJEL75NSISB2US22M4W5N3T22LLSEMZQZ3C26EJE7W52FKYFJYUWLWYIAJSOOWIG6OMA"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2MzczNCwiaWF0IjoxNjQ4NzYzNDM0LCJuYmYiOjE2NDg3NjM0MzQsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUEydkNlR0pGVWFKOXArN1pVaklEYVEvQWZISDNibDJDUFNGU0xCaGRNeG1iN1A1czFGU0ZIZHdHWlFNV1pYcnNiNVZnQ0YraEV6dU9zdkllQU5oZkI3cXlIdzlNSzA5NkFpdndTcUdVOTVnejFyN3lvQlF6Mi96N1dOYTRvVGpmeHhYTlNqS0QvQlRUdnNwWnVJVkdQaDBlODZHeGloME1RZFR1bkp1bWZXQ0svYzIvR21uMldzaTdETnBOaHFXUGljOXI0dC9pajR4VGlQZFFFNFpnUGsvT3FXa09LYnBVTGtIdDBsZlJYM1U5Rno5T0JGdzkxeUNqQ0FIWVZUZ1NmbS8vVFdyUEZsd1paOGFLTi9KQmozQXl6TUNCYmEzdkgxRjhtTUxKYlMvY1JJZkN0ODRHOGR6bngrdmQyWmpIcndpakg2YzlsZTBOK3U3WTJ6RW1YMHlJaGVHSkR3VExBVzJ2Kzlmd2tVV2o5N1FxbTk4akJPU2tJZEFKTVZkR05QZHM3VyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.bRG6YVVgXnHOIK84W52FNr4Gl2UksOEGOgueYV8AhHa2IAjOl4tD293ynL4xFufkqqc4K-6Jn0rJ5wdR5A3Hs8yx_nSFLCHfxowSeUNmPxeJ5kujDaiY6jMeXFbAwcal2Ip14b3oLDaWtqMwOdTByQlWp99yUg9Vl4vqhhQ4-rN0fHmeBwhCUHoCJiKNQ4NQA6LsT21EVx7OgzISClJGnO7EZDH55oaRyF8fOHH1K3B9Lnl_qKNkQh2v3Fng9yn35OLXHZUoPF7x4Soihm1njXH35hLCx9pA5YQH-84fFQJvRoSre-0lJRitFVzKLaHhefkLr-nXvsf72CrfPq4WUA""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.d7e361df-376b-4983-b4bc-a223c0486c94"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T21:50:34Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""List"",
						""values"": [
							{
								""type"": ""Simple"",
								""value"": ""2022-04-01""
							},
							{
								""type"": ""Simple"",
								""value"": ""2022-09-05""
							}
						]
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""value"": ""and"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""and""
					}
				}
			}
		}
	}
}
";
            return str;

        }



        public static string AskForAprilFourth()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.d9e9ea90-73ca-42dd-832f-7faa04b8049a"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.fca7fae9-ca12-4f77-a7c1-41b30f676ab7""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.AFXVFVD63OCOSHLBR47ATYZ3TG6UKPA7KK5L42DNV5II6NZJE37DET5F46XLF2KDNXHELVHUIO3OL6SWBGK3DM3NSBWEFEI3LFFEO7G274CW3XJ7R5XB4NH2LEYHOEBYWUIQDDJX2XTSV5DQPLRCCQRGFCFWBGQQ6YY5PUN4OZWAIT26XKP2H2QZWRIDRXD5ENPXGZMKIFMALWQ""
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
				""applicationId"": ""amzn1.ask.skill.fca7fae9-ca12-4f77-a7c1-41b30f676ab7""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.AFXVFVD63OCOSHLBR47ATYZ3TG6UKPA7KK5L42DNV5II6NZJE37DET5F46XLF2KDNXHELVHUIO3OL6SWBGK3DM3NSBWEFEI3LFFEO7G274CW3XJ7R5XB4NH2LEYHOEBYWUIQDDJX2XTSV5DQPLRCCQRGFCFWBGQQ6YY5PUN4OZWAIT26XKP2H2QZWRIDRXD5ENPXGZMKIFMALWQ""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.AETGFYTVI7VT2NCHPMRQJ6TVOAVV356YCQA7NGLTX4MEMH2TSBMFATDNO2WRHYPKZGFHA7EVA3RUNNZNP2OEFN2PYJEL75NSISB2US22M4W5N3T22LLSEMZQZ3C26EJE7W52FKYFJYUWLWYIAJSOOWIG6OMA"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2MjM5MCwiaWF0IjoxNjQ4NzYyMDkwLCJuYmYiOjE2NDg3NjIwOTAsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUJtaktPdGgrYWRlR09XRmlkak1PcGlIRjZHT1NHbHpremZ4Y1NmVmZuaFpsNUhJblpiZ1hQanVZWTZFempNenlnOWpDOVBiVHhlOUQyZEY4eVo5TXlCVmJjSms3Sm96Ym9DMDBhUGRRazdNb1RuZlVZTHNab2lvY2hTM0JESllMVXp0VzMwSmhZZzhvMzdsMytjN2dBUnRPUFYrMGJpVFhPN0w3TjFkbkFEQTJiOENzZ1l1aGE3TWt5YnJKbTYrZ1Z4bXpva3JRRUZZOHM5dzc2d2kvalRrdHpyR2JyK241STBsNkJYNDdVdE1SdXFyOTZrbG93ckZ2d1phTXNXeGJra2t5SjJPVk9wekVGTVJ2eUVhVnd2M2Q0RzJMVzQxck9sTDRiR05vS3FIeW9TeEJWZkdiNzM2UzhkZGd5emR1UlB6aFloTGNDZlQvellkRUNHaGg5VGQrMWNISStRUExIREc4UjYyMmxUTm1jTmh1bmdwczRZVFJtMFNaSllvNUIyS3RyMCIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.YaRNJ0pQRNKFi90gpZnhsuj_YQaUjQ7TpW20d-YwYAlVgoyxz6BV3XU0d7bPKVziygkwpMhZfYd4_B2Q4-U_UDoKaMaJznP7FSxmNkP08mbA7oOyyPGQDQ5rMxL4CWlJu7TnsWi2KrrWyZBVUk1-p61a3S-09HWGBUWqrZz88SaLLfMx-iKSyB093j9AQY40tNTp2_wX2aWmihdj2G2H6HAzKgkTgG7RbLnYhMm4agv6VBJlQi4n8gqxcPbnYwL47c6BP_CHeVEEev-bjvPaY4LBOMku9PbFMFI9oTUwB6zluxxRaICjjwbObaaVPooADubW4hYl7ctM4-7MRqJ2sQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.859be77c-0875-4c14-998a-ec48d9e86ab8"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T21:28:10Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2022-04-04"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2022-04-04""
					}
				}
			}
		}
	}
}

";
            return str;

        }

    }

}
