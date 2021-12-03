using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlexaSkillDotNet.Tests
{
    [DebuggerStepThrough]
    public  class AmazonIntentSampleRequests: SampleRequestBase
    {
        
        public static string LambdaTestScreen_AlexaIntent_Answer()
        {
            var str = @"
{
  ""version"": ""1.0"",


  ""session"": {
    ""new"": false,
    ""sessionId"": ""amzn1.echo-api.session.[unique-value-here]"",
    ""application"": {
      ""applicationId"": ""amzn1.ask.skill.[unique-value-here]""
    },
    ""attributes"": {
      ""score"": 4,
      ""currentQuestionIndex"": 0,
      ""speechOutput"": ""Question 1. What was Rudolph's father's name? 1. Blixen. 2. Comet. 3. Donner. 4. Dasher. "",
      ""correctAnswerText"": ""Donner"",
      ""repromptText"": ""Question 1. What was Rudolph's father's name? 1. Blixen. 2. Comet. 3. Donner. 4. Dasher. "",
      ""questions"": [
        16,
        20,
        29,
        2,
        19
      ],
      ""STATE"": ""_TRIVIAMODE"",
      ""correctAnswerIndex"": 3
    },
    ""user"": {
      ""userId"": ""amzn1.ask.account.[unique-value-here]""
    }
  },



  ""context"": {
    ""AudioPlayer"": {
      ""playerActivity"": ""IDLE""
    },
    ""System"": {
      ""application"": {
        ""applicationId"": ""amzn1.ask.skill.[unique-value-here]""
      },
      ""user"": {
        ""userId"": ""amzn1.ask.account.[unique-value-here]""
      },
      ""device"": {
        ""supportedInterfaces"": {
          ""AudioPlayer"": {}
        }
      }
    }
  },



  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""amzn1.echo-api.request.[unique-value-here]"",
    ""timestamp"": ""2016-10-27T21:06:28Z"",
    ""locale"": ""en-US"",
    ""intent"": {
      ""name"": ""AnswerIntent"",
      ""slots"": {
        ""Item"": {
          ""name"": ""Answer"",
          ""value"": ""1""
        }
      }
    }
  }
}
";

            return CleanRequest(str);
        }

        public static string LambdaTestScreen_AlexaStartSession()
        {
            var str = @"

{
  ""version"": ""1.0"",



  ""session"": {
    ""new"": true,
    ""sessionId"": ""amzn1.echo-api.session.[unique-value-here]"",
    ""application"": {
      ""applicationId"": ""amzn1.ask.skill.[unique-value-here]""
    },
    ""user"": {
      ""userId"": ""amzn1.ask.account.[unique-value-here]""
    },
    ""attributes"": {}
  },



  ""context"": {
    ""AudioPlayer"": {
      ""playerActivity"": ""IDLE""
    },
    ""System"": {
      ""application"": {
        ""applicationId"": ""amzn1.ask.skill.[unique-value-here]""
      },
      ""user"": {
        ""userId"": ""amzn1.ask.account.[unique-value-here]""
      },
      ""device"": {
        ""supportedInterfaces"": {
          ""AudioPlayer"": {}
        }
      }
    }
  },



  ""request"": {
    ""type"": ""LaunchRequest"",
    ""requestId"": ""amzn1.echo-api.request.[unique-value-here]"",
    ""timestamp"": ""2016-10-27T18:21:44Z"",
    ""locale"": ""en-US""
  }
}";
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

    

        public static string AMAZONStopIntent()
        {
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.bbb7ba23-daef-4699-9755-454b3e601cae"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""attributes"": {""IntentHistory"" : ""1:intent1;2:intent2;3:intent3;"" },
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



        public static string AMAZONCancelIntent()
        {
            var str = @"
{
  ""version"": ""1.0"",
  ""session"": {
                ""new"": true,
    ""sessionId"": ""SessionId.6e2df435-ada2-4fbd-a3b9-05498a0c515d"",
    ""application"": {
                    ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
    },
    ""user"": {
                    ""userId"": ""amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI""
    }
            },
  ""request"": {
                ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.1afedd4c-9cbe-4f82-b654-c9d25276bda2"",
    ""timestamp"": ""2016-08-31T01:44:30Z"",
    ""locale"": ""en-US"",
    ""intent"": {
                    ""name"": ""AMAZON.CancelIntent""
    }
            }
        }



";

            return CleanRequest(str);
        }


        
        public static string SessionEndedRequest()
        {
            var str = @"
{
  ""session"": {
    ""new"": false,
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
    ""type"": ""SessionEndedRequest"",
    ""requestId"": ""request5678""
  }
}



";

            return CleanRequest(str);
        }


    }
}
