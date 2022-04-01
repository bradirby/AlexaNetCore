

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


        public static string LaunchRequest=> $"{StartOfRequest()}{AlexaBuiltInIntents.NoIntent}{EndOfRequest()}".Replace("IntentRequest",AlexaRequestType.LaunchRequest);

		

        private static string StartOfRequest()
        {
            var str = @"{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.XXXXXXXXXXXXXXXXXX"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
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
				""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.XXXXXXXXXXXXXXXXXX"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""XXXXXXXXXXXXXXXXXX""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.XXXXXXXXXXXXXXXXXX"",
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
