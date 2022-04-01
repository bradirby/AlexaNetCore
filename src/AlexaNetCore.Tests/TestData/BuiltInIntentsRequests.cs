

namespace AlexaNetCore.Tests
{
    public class BuildInIntentsRequests 
    {
        public static string LoopOffIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.LoopOffIntent}{EndOfRequest()}";
        public static string LoopOnIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.LoopOnIntent}{EndOfRequest()}";
        public static string CancelIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.CancelIntent}{EndOfRequest()}";
        public static string StopIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.StopIntent}{EndOfRequest()}";
        public static string HelpIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.HelpIntent}{EndOfRequest()}";
        public static string FallbackIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.FallbackIntent}{EndOfRequest()}";
        public static string NextIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.NextIntent}{EndOfRequest()}";
        public static string PreviousIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.PreviousIntent}{EndOfRequest()}";
        public static string PauseIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.PauseIntent}{EndOfRequest()}";
        public static string RepeatIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.RepeatIntent}{EndOfRequest()}";
        public static string ResumeIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.ResumeIntent}{EndOfRequest()}";
        public static string ShuffleOffIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.ShuffleOffIntent}{EndOfRequest()}";
        public static string ShuffleOnIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.ShuffleOnIntent}{EndOfRequest()}";
        public static string StartOverIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.StartOverIntent}{EndOfRequest()}";
        public static string YesIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.YesIntent}{EndOfRequest()}";
        public static string NoIntent => $"{StartOfRequest()}{AlexaBuiltInIntents.NoIntent}{EndOfRequest()}";
		

        private static string StartOfRequest()
        {
            var str = @"{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.d503f54d-7fcf-402d-a5bb-539d065524ba"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODgwNjY1NywiaWF0IjoxNjQ4ODA2MzU3LCJuYmYiOjE2NDg4MDYzNTcsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFESFphUXFja1RIb2hTTVlZTnBYZnYwSkFFQUFBQUFBQUNONUp5STNkVTUwMmdhMWhOSWEvMXNVK0dUV21VcGphVUl3RlhzSE52dHJMZ0JuUVU1bGVwbWhoRFJtVk9HOEpZMGJmUFpiV1g4MFhBNWZOZG9qNU1nZDNMalk1dlhubVZZdk9wQWtVKzFDWjIvay96VkdxMFRHektJaXltREduc3FMZ1dNN3BXMXVhRVVmSURRTGgxaEg0aDNsa2hhbjJJWis2cm5maWJGL2tDTUNIWG9JSEFCYVpBMWNvSFV6NGVEZG5wMm9QTHpBTkhLeTFJK2NRVDgvZjdpZDR6S3kvQkdCU3BmZGdVaEhxSWw5Wlo3VHU0QXNNaWI5V3JCckJ4anNtenBRTm16QVRLczg0c05jM2VoTGxJYjQvWWdxSTlZYXdDeU0wdXNMNEpOL2poSm1rVHNpV0swZU80VUxYWlkrOURFRGRJN2g1ZXdVbW1UNi9XNnlzODZGZUVoQ25FQ21RczNkMzlRbFVaS1RmWlh1OWFUd3lYMVR6TmtSL2l1YnB5NyIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.FOX-ogJrVTCYZImA3E35A9TgCPDayhZhdVAePul-TOL-0jvPs5RxYfWBM4Ma2fbwE3Y735nYebHeNO6_bSK23J_t-Cf7VS4vEOIWWHY_oMO1Hpvc3HJtdHhXvjqGdCpCUQa-J5ZDmY8S_AiLAqMqpXNW5X8tPefakIuAmPZWcpK9FRTGLkj9bnk7loEnI147pd7oEdjYVoefhkOyzKdvzHGTqQpTIrcTtjolYBwGO5R7wzywPi1qZsti-lFVKzmYelKAH6RN3-bl-LrxMbHtNe8kWQxzPGOkzJfwWGurIWvFtK3XKlSObg9LI7gKPRCZyh3T4nFSbr3BvbaUVYgLVQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.573fac64-8223-4020-b270-4929574d170d"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-04-01T09:45:57Z"",
		""intent"": {
			""name"": """;

            return str;

        }


		
        

        private static string EndOfRequest()
        {
            var str = @""",
			""confirmationStatus"": ""NONE""
		}
	}
}
";

            return str;

        }



    }


}
