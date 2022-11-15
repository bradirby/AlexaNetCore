using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AlexaNetCore.Model;

namespace AlexaNetCore.Tests
{
    [DebuggerStepThrough]
    public class GenericSkillRequests
    {

        public static string SessionEndedWithInvalidResponse(AlexaLocale localStr = null)
        {

            var str = @"
{
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
			""apiAccessToken"": ""XXXXXXXXXXXXXXXXXX
	},
	""request"": {
		""type"": ""SessionEndedRequest"",
		""requestId"": ""amzn1.echo-api.request.XXXXXXXXXXXXXXXXXX"",
		""timestamp"": ""2022-08-12T10:42:32Z"",
		""locale"": ""en-US"",
		""reason"": ""ERROR"",
		""error"": {
			""type"": ""INVALID_RESPONSE"",
			""message"": ""An exception occurred while dispatching the request to the skill.""
		}
	}
}


";

            return str.Replace("en-US", localStr.LocaleString);
        }


        public static string BlankRequest()
        {
            var str = @"

";
            return str;
        }



        public static string EndSession(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;

            var str = @"


{
  ""version"": ""1.0"",
  ""session"": {
    ""new"": false,
    ""sessionId"": ""amzn1.echo-api.session.XXXXXXXXXXXXXXXXXX"",
    ""application"": {
      ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
    },
    ""attributes"": {},
    ""user"": {
      ""userId"": ""amzn1.ask.account.testUser""
    }
  },
  ""context"": {
    ""System"": {
      ""application"": {
        ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
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


".Replace("en-US", localStr.LocaleString);
            return str;

        }



        public static string StartSession(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
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
                ""applicationId"": ""amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX""
    }
        },
  ""version"": ""1.0"",
  ""request"": {
    ""type"": ""LaunchRequest"",
    ""requestId"": ""request5678""
  }
}


".Replace("en-US", localStr.LocaleString);

            return str;

        }




        public static string CancelRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
            var str = @"
{
  ""session"": {
    ""sessionId"": ""SessionId.3f1f8f0a"",
    ""application"": {
                ""applicationId"": ""amzn1.ask.skill.XXXXXXXXXXXXXXXXXX""
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
    ""locale"": ""en-US"",
    ""timestamp"": ""2016-08-30T03:08:13Z"",
    ""intent"": {
      ""name"": ""AMAZON.CancelIntent"",
      ""slots"": {}
    }
  },
  ""version"": ""1.0""
}

".Replace("en-US", localStr.LocaleString);

            return str;

        }



        public static string HelpRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
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
			""name"": ""AMAZON.HelpIntent"",
			""confirmationStatus"": ""NONE""
		}
	}
}
".Replace("en-US", localStr.LocaleString);

            return str;

        }



        public static string InvalidIntent(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
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
".Replace("en-US", localStr.LocaleString);

            return str;
        }



        public static string EmptyRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
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

".Replace("en-US", localStr.LocaleString);
            return str;

        }


        public static string LaunchRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": true,
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
			""apiAccessToken"": ""eyJ0eXAiOi""
		}
	},
	""request"": {
		""type"": ""LaunchRequest"",
		""requestId"": ""amzn1.echo-api.request.XXXXXXXXXXXXXXXXXX"",
		""locale"": ""en-US"",
		""timestamp"": ""2021-09-24T10:52:31Z"",
		""shouldLinkResultBeReturned"": false
	}
}

".Replace("en-US", localStr.LocaleString);


            return str;

        }



        public static string StartOverRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
            var str = @"

{
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
			""name"": ""AMAZON.StartOverIntent"""",
			""confirmationStatus"": ""NONE""
		}
	}
}
".Replace("en-US", localStr.LocaleString);


            return str;

        }




        public static string FallBackIntent(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
            var str = @"

{
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
			""name"": ""AMAZON.FallbackIntent"""",
			""confirmationStatus"": ""NONE""
		}
	}
}
".Replace("en-US", localStr.LocaleString);


            return str;

        }






        public static string StopRequest(AlexaLocale localStr = null)
        {
            if (localStr == null) localStr = AlexaLocale.English_US;
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
    ""timestamp"": ""2016-08-30T18:41:50Z"",
    ""intent"": {
      ""name"": ""AMAZON.StopIntent"",
      ""slots"": {}
    }
  },
  ""version"": ""1.0""
}

".Replace("en-US", localStr.LocaleString);

            return str;

        }





    }


}
