﻿using System.Diagnostics;

namespace AlexaNetCore.Tests
{
    [DebuggerStepThrough]
    public  class AirportInfoRequests : SampleRequestBase
    {
        
        
        /// <summary>
        /// This was a request where the Alexa service did not understand my spoken value for the slot
        /// </summary>
        /// <returns></returns>
        public static string AirportInfoSFO_BadRequest()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
    ""timestamp"": ""2016-07-03T01:48:34Z"",
    ""intent"": {
      ""name"": ""airportinfo"",
      ""slots"": {
        ""AIRPORTCODE"": {
          ""name"": ""AIRPORTCODE"",
          ""value"": ""how is sfo""
        }
      }
    },
    ""locale"": ""en-US""
  },
  ""version"": ""1.0""
}
";
            return str;
        }

        /// <summary>
        /// Sample Airport info response where there the slot was not understood
        /// </summary>
        /// <returns></returns>
        public static string AirportInfoSFO_BadRequest_Response()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""response"": {
                ""outputSpeech"": {
                    ""type"": ""SSML"",
      ""ssml"": ""<speak>I didn""t have data for an airport code of how is sfo</speak>""
                },
    ""reprompt"": {
                    ""outputSpeech"": {
                        ""type"": ""SSML"",
        ""ssml"": ""<speak>Tell me an airport code to get delay information.</speak>""
                    }
                },
    ""shouldEndSession"": false
  },
  ""sessionAttributes"": { }
        }
";
            return str;
        }


        /// <summary>
        /// Good request generated by the Echo using the Airport Info sample app
        /// </summary>
        /// <returns></returns>
        public static string AirportInfoSFO_GoodRequest()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
    ""timestamp"": ""2016-07-03T01:57:46Z"",
    ""intent"": {
      ""name"": ""airportinfo"",
      ""slots"": {
        ""AIRPORTCODE"": {
          ""name"": ""AIRPORTCODE"",
          ""value"": ""sfo""
        }
      }
    },
    ""locale"": ""en-US""
  },
  ""version"": ""1.0""
}
";
            return str;
        }


        public static string AirportInfoSFO_GoodRequest_Response()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""response"": {
                ""outputSpeech"": {
                    ""type"": ""SSML"",
      ""ssml"": ""<speak>There is currently no delay at San Francisco International. The current weather conditions are A Few Clouds, 70.0 F (21.1 C) and wind Northwest at 13.8mph.</speak>""
                },
    ""shouldEndSession"": true
  },
  ""sessionAttributes"": { }
        }
";
            return str;
        }

        

        

        public static string BlankRequest()
        {
            var str = @"

";
            return str;
        }



    }
}
