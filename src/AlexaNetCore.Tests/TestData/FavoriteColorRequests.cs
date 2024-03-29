﻿using System.Diagnostics;

namespace AlexaNetCore.Tests
{
    [DebuggerStepThrough]
    public class FavoriteColorRequests 
    {

        
        public static string WhatIsMyFavoriteColor()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.0000000-0000-0000-0000-00000000000"",
    ""application"": {
                ""applicationId"": ""amzn1.echo-sdk-ams.app.000000-d0ed-0000-ad00-000000d00ebe""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.account.AM3B00000000000000000000000""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""amzn1.echo-api.request.0000000-0000-0000-0000-00000000000"",
    ""timestamp"": ""2016-07-02T17:09:37Z"",
    ""intent"": {
      ""name"": ""MyColorIsIntent"",
      ""slots"": {
        ""Color"": {
          ""name"": ""Color""
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

        
        


        public static string FavoriteColor_Hello_Request()
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
    ""timestamp"": ""2016-07-03T04:07:49Z"",
    ""intent"": {
      ""name"": ""WhatsMyColorIntent"",
      ""slots"": {}
    },
    ""locale"": ""en-US""
  },
  ""version"": ""1.0""
}
";
            return str;
        }

        public static string FavoriteColor_Hello_Response()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""response"": {
                ""outputSpeech"": {
                    ""type"": ""PlainText"",
      ""text"": ""I""m not sure what your favorite color is, you can say, my favorite color  is red""
                },
    ""card"": {
                    ""content"": ""SessionSpeechlet - I""m not sure what your favorite color is, you can say, my favorite color  is red"",
      ""title"": ""SessionSpeechlet - WhatsMyColorIntent"",
      ""type"": ""Simple""
    },
    ""reprompt"": {
                    ""outputSpeech"": {
                        ""type"": ""PlainText""
                    }
                },
    ""shouldEndSession"": false
  },
  ""sessionAttributes"": { }
        }
";
            return str;
        }

        public static string FavoriteColor_ColorIsRed_Request()
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
    ""new"": false
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
    ""timestamp"": ""2016-07-03T04:10:26Z"",
    ""intent"": {
      ""name"": ""MyColorIsIntent"",
      ""slots"": {
        ""Color"": {
          ""name"": ""Color"",
          ""value"": ""red""
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

        public static string FavoriteColor_ColorIsRed_Response()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""response"": {
                ""outputSpeech"": {
                    ""type"": ""PlainText"",
      ""text"": ""I now know your favorite color is red. You can ask me your favorite color by saying, what""s my favorite color?""
                },
    ""card"": {
                    ""content"": ""SessionSpeechlet - I now know your favorite color is red. You can ask me your favorite color by saying, what""s my favorite color?"",
      ""title"": ""SessionSpeechlet - MyColorIsIntent"",
      ""type"": ""Simple""
    },
    ""reprompt"": {
                    ""outputSpeech"": {
                        ""type"": ""PlainText"",
        ""text"": ""You can ask me your favorite color by saying, what""s my favorite color?""
                    }
                },
    ""shouldEndSession"": false
  },
  ""sessionAttributes"": {
                ""favoriteColor"": ""red""
  }
        }
";
            return str;
        }
        public static string FavoriteColor_WhatIsColor_Request()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": {
                ""favoriteColor"": ""red""
    },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": false
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
    ""timestamp"": ""2016-07-03T04:11:59Z"",
    ""intent"": {
      ""name"": ""WhatsMyColorIntent"",
      ""slots"": {}
    },
    ""locale"": ""en-US""
  },
  ""version"": ""1.0""
}
";
            return str;
        }


        public static string FavoriteColor_WhatIsColor_Response()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""response"": {
                ""outputSpeech"": {
                    ""type"": ""PlainText"",
      ""text"": ""Your favorite color is red. Goodbye.""
                },
    ""card"": {
                    ""content"": ""SessionSpeechlet - Your favorite color is red. Goodbye."",
      ""title"": ""SessionSpeechlet - WhatsMyColorIntent"",
      ""type"": ""Simple""
    },
    ""reprompt"": {
                    ""outputSpeech"": {
                        ""type"": ""PlainText""
                    }
                },
    ""shouldEndSession"": true
  },
  ""sessionAttributes"": { }
        }
";
            return str;
        }



    }
}
