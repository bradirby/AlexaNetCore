using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlexaNetCore.Tests
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""InvalidIntent"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": { },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""LaunchRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": {""IntentHistory"" : ""1:intent1;2:intent2;3:intent3;"" },
    ""user"": {
                ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    },
    ""new"": true
  },
  ""request"": {
    ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
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
    ""sessionId"": ""SessionId.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
                    ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
    },
    ""user"": {
                    ""userId"": ""amzn1.ask.account.XXXXXXXXXXXXXXXXXX""
    }
            },
  ""request"": {
                ""type"": ""IntentRequest"",
    ""requestId"": ""EdwRequestId.XXXXXXXXXXXXXXXXXX"",
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
