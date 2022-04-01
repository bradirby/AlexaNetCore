using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotChecker.Tests
{
    public class DurationSlotCheckerQueries
    {

        
        public static string sampleMethod()
        {
            var str = @"



";
            return str;

        }

        public static string Complex()
        {
            // give me duration values for two years one months eight days four hours nine minutes and three seconds
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.7c3b0461-d3e7-4526-a063-8b4c2c041227"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODgxNDE0NiwiaWF0IjoxNjQ4ODEzODQ2LCJuYmYiOjE2NDg4MTM4NDYsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFESFphUXFja1RIb2hTTVlZTnBYZnYwSkFFQUFBQUFBQUJsWk5wdWFtMkE2bXJRQVpOWjh1Z2E2QWRZZVlTSnAwWFBxUHE3RDl2UkE4S2NUU0JRQ0ZJTEY4ZzZaVnZucHBLUjlSUXA4NUtCVm5CVFJiRXdGZ2plT3lRWVBpeSt6MllqQUJCY1BBdzNsOFl4YU5Tc2tldmRzUHpiSWFOWEFqa1dKb0NWZDlGS1RUNU9DcEpGMDBIKzBiQnB5UXdpVGRGc3NWbWd5bUUyVU9abUJ3NXVVNXdEY1kzZVF6SStBYXpyUEh6b1NBMmhUT0FrdDUzYXNWYU1TN0xUR2hqS2VqNGhDOHZ3OHB4dVJ2SnpVY2J5RStCKzdtZXJ5aW9MbW1sNnU1QzB1M2lSaUxHZFp6eHZTa3JDaWJnQ3J0ZXdOUm9ZYW1JQ2pyVFJvYUZvSzhWQU9TZWNadVRlTythUnlKc05oRU1kR2ZuREY0VldzQjFSSExrQlljV0VrWU11ZlhKVWNEY2wyZUlZaUNSYTYvc1p3K3JTZS9CMklUQnUraElDR2d3UCIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.iDXXEZ3bhL4ZbWmyJO9BdIiSU3yCKNDPm_uvBMv6w8byxmkRG1jPwe1QFyFF85osg5bAr1d0sDGVYjKNCDyzbxwRdat67JOhEodSuj-b2T0JZOIaT9Q8xeQauOSeZ85ei1bh5T0K5VuwcEJ__v6CJ1Dsew2tMh46kGoEOWyfWhPxbyTqHSegbS8GSHosiYC9_aZAoxBkttOFlODnLOFw9ZCkdMIs89AI06u-zC65t3L9B7z20UUeLpPGG2FgiftMlAcrPQ6UwHqKdANx-Mt0NzXxjqz15lwhgYJ5mohe6mM4T9GkeMaFes5AxYPXfJp0zh6WtHwZb0kRBAsWi7c39g""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.fbe907b8-38f7-4b8b-bfa5-78f7fa0a192e"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-04-01T11:50:46Z"",
		""intent"": {
			""name"": ""DurationSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""value"": ""and"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""and""
					}
				},
				""durationInputValue"": {
					""name"": ""durationInputValue"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""List"",
						""values"": [
							{
								""type"": ""Simple"",
								""value"": ""P2Y""
							},
							{
								""type"": ""Simple"",
								""value"": ""P1M8DT4H""
							},
							{
								""type"": ""Simple"",
								""value"": ""PT9M""
							},
							{
								""type"": ""Simple"",
								""value"": ""PT3S""
							}
						]
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
