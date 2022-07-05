namespace AlexaNetCore.Tests.TestData
{
    internal class DialogRequests
    {

        public static string DialogConfirmationDenied=> @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.xxx"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.xxx""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.xxx""
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
				""applicationId"": ""amzn1.ask.skill.xxx""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.xxx""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.xxx"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""xxx.xxx.xxx-xxx-xxx-xxx""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.xxx"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-06-24T15:05:46Z"",
		""intent"": {
			""name"": ""RecommendationIntent"",
			""confirmationStatus"": ""DENIED"",
			""slots"": {
				""allergies"": {
					""name"": ""allergies"",
					""value"": ""no"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.allergiesType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""None"",
											""id"": ""NONE""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""cuisine"": {
					""name"": ""cuisine"",
					""value"": ""spicy"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.cuisineType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""Spicy"",
											""id"": ""SPI""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""dish"": {
					""name"": ""dish"",
					""value"": ""beef"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""AlexaEntities"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/EyKCiGg0gccDoue7gt8BDK""
										}
									},
									{
										""value"": {
											""name"": ""corned beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/KUJPmPziJeyFreBD6gmfhW""
										}
									},
									{
										""value"": {
											""name"": ""Kobe beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/AVDVeL0YcnZFKpr31QGyRu""
										}
									},
									{
										""value"": {
											""name"": ""beef lung"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/XUhZJXehN4FC9xNPdTPsh0""
										}
									},
									{
										""value"": {
											""name"": ""beef brisket"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/6v9kbheXJLtCX10zVJkBt8""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""timeOfDay"": {
					""name"": ""timeOfDay"",
					""value"": ""breakfast"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.timeOfDayType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""breakfast"",
											""id"": ""B""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				}
			}
		},
		""dialogState"": ""COMPLETED""
	}
}

";


		        public static string DialogCompleted => @"


{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.xxx"",
		""application"": {
			""applicationId"": ""amzn1.ask.skill.xxx""
		},
		""attributes"": {},
		""user"": {
			""userId"": ""amzn1.ask.account.xxx""
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
				""applicationId"": ""amzn1.ask.skill.xxx""
			},
			""user"": {
				""userId"": ""amzn1.ask.account.xxx""
			},
			""device"": {
				""deviceId"": ""amzn1.ask.device.xxx"",
				""supportedInterfaces"": {}
			},
			""apiEndpoint"": ""https://api.amazonalexa.com"",
			""apiAccessToken"": ""xxx.xxx.xxx-xxx-xxx-xxx-xxx-z8w""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.xxx"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-06-24T10:24:24Z"",
		""intent"": {
			""name"": ""RecommendationIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""allergies"": {
					""name"": ""allergies"",
					""value"": ""nuts"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.allergiesType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [

                                    {
										""value"": {
											""name"": ""Peanuts"",
											""id"": ""PEA""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""cuisine"": {
					""name"": ""cuisine"",
					""value"": ""spicy"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.cuisineType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""Spicy"",
											""id"": ""SPI""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""dish"": {
					""name"": ""dish"",
					""value"": ""beef"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""AlexaEntities"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/EyKCiGg0gccDoue7gt8BDK""
										}
									},
									{
										""value"": {
											""name"": ""corned beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/KUJPmPziJeyFreBD6gmfhW""
										}
									},
									{
										""value"": {
											""name"": ""Kobe beef"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/AVDVeL0YcnZFKpr31QGyRu""
										}
									},
									{
										""value"": {
											""name"": ""beef lung"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/XUhZJXehN4FC9xNPdTPsh0""

                                        }
},
									{
										""value"": {
											""name"": ""beef brisket"",
											""id"": ""https://ld.amazonalexa.com/entities/v1/6v9kbheXJLtCX10zVJkBt8""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				},
				""timeOfDay"": {
					""name"": ""timeOfDay"",
					""value"": ""breakfast"",
					""resolutions"": {
						""resolutionsPerAuthority"": [
							{
								""authority"": ""amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.timeOfDayType"",
								""status"": {
									""code"": ""ER_SUCCESS_MATCH""
								},
								""values"": [
									{
										""value"": {
											""name"": ""breakfast"",
											""id"": ""B""
										}
									}
								]
							}
						]
					},
					""confirmationStatus"": ""NONE"",
					""source"": ""USER""
				}
			}
		},
		""dialogState"": ""COMPLETED""
	}
}


";




    }
}
