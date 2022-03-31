using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotChecker.Tests
{
    public class DateSlotCheckerQueries
    {

        
        public static string sampleMethod()
        {
            var str = @"



";
            return str;

        }

        public static string Spring()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.13c265c3-efba-4d1f-9bbd-366e64f9d8d0"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NjI3MCwiaWF0IjoxNjQ4NzY1OTcwLCJuYmYiOjE2NDg3NjU5NzAsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQURRM3o4SVAyaStlK1QzMFJMUmVkaCs1ZDFwVGpPTklHd0huazhBaDdPdmxkbkdRQVdUV21MZGpuWWNRV1dZMW9IcUdzMTZKWUFNU1ZkRWVDVlVGa3NtZEFxUkNzSkdaZGxBTkgySGlpeDlNQytaamtJTU1VangwRDBEdEdrZVVLYmhYeDdZY1BWZ1lKNzNvWGlVOENnZWdoenBvMElYYUxMY0xGWVpQQUQwRDdQMm9KSjBHajhZdWtsOVBlVHVjWGNFVWxLSDJ1Z1UxSlVHblpIWGVST3RPdmlsVitQSzF5MmJYSExnTThVR1NMcGk3N0t4MDZ4SmRFZ2pOUE1DQnlDd1Q4MGZOdElqQU1UR1F1U2o2N0RxcmdaMnBrUG5STm1jUnRnSWJ5K0dTR0ZCWHF4WnUwaUt6YTlXLzUvaUhXMTQ0aHFrWnNrb3dEdVBIWUpYaEtkSGJVcjNIbllhWDgwZ0tsendudTJUbkx2ZzJWKzVMMGdYQzFucDBMMjVQdmhvNUdwZSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.Bn4KKVU_kLVQs1rSW24gDjWyKb4gDVCM0N01YOxKVf64V_Iz86lxansHnaVHHfzMEwK58fwyB3WzZM4yrUjgu66WhJx2rORQes1hKhoBjL1rMmY3d_iQn0P_DgmFbulU2t-H6DCjtrGDN0OutwzTuP-C4YFNN_WWNwVHvTHxUFt7OMac6cnQDdmNyJa1m9fxLnFSMjRzVLyrFxL5wsB3gyh-gl1DhpWlYnLDEh1sd9V6gZca2Qv6rHebyvNqIWTLfDmGwTFtdgSi63QrRUz0Ia9JPmNxZXElbB3QvWmZM_z9zbwZEDx_IP_Vw3NL_GotoOuGEBJWlE9rnD_x7jvEww""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.a13ba7c2-81c9-4b6f-975b-ea1bedc09019"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:32:50Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2022-SP"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2022-SP""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }



        public static string NineteenNineties()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.6ca1ad61-bf0b-49d2-968e-e46f9afa031e"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NjE0NCwiaWF0IjoxNjQ4NzY1ODQ0LCJuYmYiOjE2NDg3NjU4NDQsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUQ2TDFFaFFPN29WU1VTZG9mUm9tZk8zdmNQcnZGejVRbG81eW9BNlM2YW5jK2dwOTZ2R1o4dk15WjFqR1NqRDZ2Z0pBeGl5YWVGYlV5U3crR3NxVkpNKzBlMHlSTTVaWVVUcTdnVFhwUnc0cVdFVTY2N0FBNGFzaVdDcFlMVXZkOWdDaVczbEdKRjE0ZGg2eFJZM0liTTBnWGpQOUhFVGQ4YmtBSWo2M3ZaTnlucFBJb2V0WWZTMWt6RVFxYVBYMS9Pb2o2UnhFbDZEaVZiZFVKdStNbklmeVJ5eU5BRWl2U3c2UFdFam9xRmtyMjVTSDNrdnlaTWFtTXA3a0V6YkNGLzdocCtMTnMxTW9Za1FwQ0swT3dDMzNBRmxOZlhjM1VHeGYvMlhzRTBlMEZZcUkvK0dsWDZnVTdQMDV1RCtscGlpeHZ6cjVobmlyUnFKWkxRckZrZkVielc0ZVlOTlMzQ2lrb3VZNDRKYTk0enNmU3Avd2FIV0YwcEVwQ3dHS0dYWGxRbSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.ep7zq68TkO7eTKa1zN8Kxn7J-4z5A8-7EXmKPzTbAA9d5b0FxWd5sSvYqxBs3L4uFXL4DpkcdVkjUqMkqq9HrhqRGNL1Oigqrh6lR7cAgtB8t86GrbR4FSlbMYp9chy5Xml_-o5HgFEcU7IiBehAAkkF_Gn6jJFtk3bsiGDCxrYJzfrLmcprAGymYjZQKSF4jPv5r_2PZUvL_8_mhzNJ334xd-oAGwHmp3G_PSuM4ipa-dRUt9V3Gwa8dFO6t5Drj9BVG_P0oM9Y1Q0G6D62OF23KxCZqBNbFMAxVye2GzTHXWwBjVTZcw9bSV18x0deRIgIcrBBeJJrUoug7r5xPQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.24d669a6-17ae-4769-8404-4dc9d8be0e4a"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:30:44Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""199X"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""199X""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }

        public static string ThisYear()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.9bcb4cb4-3973-4f42-a299-b86d4258d521"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NTk4MiwiaWF0IjoxNjQ4NzY1NjgyLCJuYmYiOjE2NDg3NjU2ODIsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUF4NkpsMVZNb0pRaXExSEduVHJJNzJOVVRIdnA3RzExam5TRitxYjF2M0RkeDV1RnlrY3ROQXVhWERtUG9YWUdVUnB3eUJJYWdRRnlaTDRHZk05S0xZM2ZYL2x5ZlJ0VE9iYXZ6VmpnbTNNQUNyQWhpRmFBL1UyaklGU1B3UEJpeW5PQVZXajBnWE9CckR3dVVSL0lvclE1eFNZeXVLMEYyWDFGZjZMMkF5M3J3bi8zcC9NWStiQkxWV2FSNWtqK2YyVkVrbzBpZnBpc040TWp2QzBkUWdKUXY0REhHdk13bER0N3BFVHhmcmU3cEVIWk1RYmtFMGw2OW95ZDBldEl2cmpVY0lZSTBRZmRMUHlPMWZ0ZFlQR0pVWGErWCtsUWJNNWpTN2lQOWdaK2YvSlcvQitEZmdWVTl5dkE2NjlDcUJkeEJzaWZ2RkFLYTdKbTZhKzl5K2xWa2pCSEppYkszTlo2dVRqU1RJMHNZNGhtQ1pxb21naENjdTJUMlRSUldNZDNMUiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.BgKijBbhXI_NdM1YT8IrdZo1JzO8y2HyUPnzWYR7Qlj0Ms8wY__PrIcpD1bDsK-tFAijtMiUqOjtBotXs0-VVUUkh-cdcUvWh4drFKu1sqmo5er3QTHroaZiXfpzXeHPIFl7XDYszowluEEQZyH1GLreptEBqFpYVLP2D3Xuags9IAGa5dhXzhlWSnXDQAZMe2SEBwWH0SuWRhTij_Rb3i7Dlsk1m9Ji2wVmqhbZvLpCpETe-aI7UKSc9hsA6bBjbigJ9lA18yve2Kn6mJzACNlolgjKouoheBU-mJHvYwI5hYF4pehCUaxZVsOIg_v4ivWxVJShaD7-z6nlDVzCLg""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.e71abbe8-0a19-49c1-b90a-b3e0e7f85fd1"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:28:02Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2022"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2022""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }


        public static string January()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.69d58e89-25a1-4393-b1b5-9720e12c3a3a"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NTg1MSwiaWF0IjoxNjQ4NzY1NTUxLCJuYmYiOjE2NDg3NjU1NTEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQURWUTNDdnd0c2U0azJidmJzSnBRTmFtOUFKUHpJZEN3M1NjaE5HejdBYzB5QVVkWDdFVU95cWdjdllNcTh4NklmT0JWc0hIQmZ3SHZ2RDJmM3VXRGNMUGNveXBwMzBpUE43cEJuc3hkbDY1L2orbnE1aDc1bEtuMUxSUnlsc2hPRFJDTUUzWHRXOXBHYlgxZ09jMjNBUlJMUitxeUkzTnpZRGNWdXFvRjN0NkhzTDJuaVRDcmNhdnBRbXdFazRQeExJaFZzQmV0WUVRaWlOMmNCRmdOR3MzT2J1RmFad09IVkhRR1J4bVYyNXlhbDZwY0ZMK1NSUkxmUjZTang3ck8vREJmcFQ3UXAvZVBIRFJ1R0tHbi9nNGIyTDhsc1c5RFBjODJUTDFab1NwaG4wK2dqMjlIOGRpeDBTRGdTaWh6MnZ3K2FMZEdMTHdIbjluZ252aytHbGN6ZWxTK2NtKzZreSthbGtVc3EzQlJRMytkR1N4ckdTYll5WGdmS2xYeExid2R1USIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.VJ4UMzcf9YNis-4KV9nJ0VCizfqnhfuQmIh4rCpJerY7gmcXRcrNnUM_QdYAzRb3cICBkYa_EQw7da_Jp6J4_UZhYWwk3C5hTq0i7PKVAysoIgCuAm8bqWs5xBbXn-GIVkIV4o5Oq_YlpkfCfldO2Lb7FnL4GQ1M7ihcLeK2Oq9DUAXb3wHNXh-LdXOyiFzO0AVe4JGipuG7J0zun3IdnkUe2Yg0EHn8G-EdbikARGMH17t22s53uawJCmWgxABcaVjEkFWj4Wrz7nSRFLaJTEN8VVFOuKBS8ubVUTbPY9RR0ryzMt7odO4RhqBZglq-3AYj5uAXZo8uaVOOLn6S1g""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.76220e81-a68e-401e-93b2-17ef967807fa"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:25:51Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2023-01"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2023-01""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }



        public static string NextWeekEnd()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.366d4319-b3ff-46ff-9c13-02da18af18d2"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NTcyMCwiaWF0IjoxNjQ4NzY1NDIwLCJuYmYiOjE2NDg3NjU0MjAsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUEyQkgrcTdMK1RzSXlpRlp4bGNmVlVpelFCVjBuV0tscjZUVDRKRnJyYnZCZWdncy90S2VGL1R1aUNyNFgzMUlvNi8zRXI2a1hhOFpnQ1pFUUt5aUpEazVEUDVlMGYvQU1GYlFnZDZUVzJQUjBwbnBFUi9zSFFaalpCakxQYThLSENERnR2TlowRVdvUDJLZEc2M2p2QTd1bit5VFNZQXRrdTUyQ3NyRXg4T1VXOUUzd1dtaVkvUEV5QmhJc1JwREpobHBNaGVLcjgxcTJwR0RRSHZhd0pQTG0vend0bDNmT0JFMlltRlMxSnVwK3hDUmNkSVFaNXJiV1dtbExLYUxGMTZBN2ZNaEVlM2FwaWtPd3VZaGlPdmhHN3kwSkwvWUh4RlU2SVZ5TWtTYXVsRTZmU0xBLzh2RGE5ZlE5bFFMSGdCNi9uL1crY2oySG9vaUhkMmJzRnFFMUV5UC9yZit5YmpOdW5URE1PMTBHNDRoeE5nZURIOFhlSTlyZ0ZJVThVVDh5QSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.UnOgJ4I0ZuYaCLAkSSBr179T7FunYh1z0F4PyG4396UxGwbA4RqdqeRARjhb0jRaSBKZk2P-9COeqlEP2g3R6rxrb6DDxvij09-raZMZsnwexO_e5y_RfsM3IXrreLgB_n9v294u-NOVTchuTTiq5pN99eTy9H5vQCRdN55qn0eGmzSLVlXUvnHXVtH7z9hfwvb_FS4DuqIM8N17_uJXh8uJsOTnga49IGZ61PpWmtjt_ja8K3gy7r3JWZP7wUcJBqWe489N5jLMC_ZQLJn_ViahBh0Suq19DZYVIOE4H0skH8jjXjxncBHJMxBU7CqoybS3J-PyAh-LIZYWsItJ_w""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.f84cfd25-217d-4f7a-9e49-6873c893f685"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:23:40Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2022-W14-WE"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2022-W14-WE""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }



        public static string AskForThisWeek()
        {
            var str = @"

{
	""version"": ""1.0"",
	""session"": {
		""new"": false,
		""sessionId"": ""amzn1.echo-api.session.e1060fe7-f887-4bc1-8a6e-e5b81eb550c9"",
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
			""apiAccessToken"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLmZjYTdmYWU5LWNhMTItNGY3Ny1hN2MxLTQxYjMwZjY3NmFiNyIsImV4cCI6MTY0ODc2NTUxNiwiaWF0IjoxNjQ4NzY1MjE2LCJuYmYiOjE2NDg3NjUyMTYsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFCaGhoaVcyVzl2WUFhYmhuUElJVUgrSkFFQUFBQUFBQUNRWHdmaTU3SkNNd282SHg0eGZiZGkyUnhmRXJBZjdWNjg0WkZYNVUwTldWTkpEWnRmMmdFMFVKRU4zZ3lqRURUSUFESWpNSWVOZzJ1eWpidXpEQTVIZ052RkxLSEl6UHZVcjNTMWthYitsNGFsUFVLd29vRDJhK083NEVWVlVmbGNWdWRsZGZneC93KzZPak1DNWdMM2FqMkVVOGFONHVUOVlNbDRRYmtDOUV1OVhEOURCdlBDKzgwMk55UENNOVhmMTAya0xRcnU3WURYVXAwTkovekJKWXMwdEhrSFFGaHlTdTVyZm11WHhoTThPakNsWmZxaFd6VEhSMXJsZHJRQ2NOMlBXc250UzNwN2Q0aHFSdzJmcHRsUTRGOFNvRmZ5eDR4bDFpQXNOeGQxaTBzZHZtaTUwcGJjcUJaWHBMQUp5T2hiQ09lUkpoMHdoQzEzQmFQTWMzWkpNMXFES1l5dlFOMi90VVVtOGJVVTBjYWlVYUlkMmJqaEk1Yk9EbndKOVpTbSIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFVEdGWVRWSTdWVDJOQ0hQTVJRSjZUVk9BVlYzNTZZQ1FBN05HTFRYNE1FTUgyVFNCTUZBVEROTzJXUkhZUEtaR0ZIQTdFVkEzUlVOTlpOUDJPRUZOMlBZSkVMNzVOU0lTQjJVUzIyTTRXNU4zVDIyTExTRU1aUVozQzI2RUpFN1c1MkZLWUZKWVVXTFdZSUFKU09PV0lHNk9NQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGWFZGVkQ2M09DT1NITEJSNDdBVFlaM1RHNlVLUEE3S0s1TDQyRE5WNUlJNk5aSkUzN0RFVDVGNDZYTEYyS0ROWEhFTFZIVUlPM09MNlNXQkdLM0RNM05TQldFRkVJM0xGRkVPN0cyNzRDVzNYSjdSNVhCNE5IMkxFWUhPRUJZV1VJUURESlgyWFRTVjVEUVBMUkNDUVJHRkNGV0JHUVE2WVk1UFVONE9aV0FJVDI2WEtQMkgyUVpXUklEUlhENUVOUFhHWk1LSUZNQUxXUSJ9fQ.jE1vA4hpphqx55MXyepz3ohFDcVbYM_xnnPJpPn3iZLvXyaKrvVVs9V7-K0zxzT4bPbrP2DOZZKVNSc9QWMJ9Fl0hOSBICJcp61GCXhTvSwRoVw7zasohmBl_XjO-lGlxwj6ew457eWfA80_TRNerPzzWyDdv-qsnaqZFbjTwRy4VSck03gmlOx3HFNJOU1h3m4iADoxBtOsjrzZTVZW8OhNNBff7kAaoi6gHzbpoY6N3DEIVhBzAtEuOQXksu-KscjovkWfRaRxRdSsoMLJL1ovgO_DxPPq8DTSnQrJS6ag9spLCPKFXiMcLh9JadB64oUAHRlNain7CcLILotCgQ""
		}
	},
	""request"": {
		""type"": ""IntentRequest"",
		""requestId"": ""amzn1.echo-api.request.1971cdee-49f9-4fac-999f-31d6bd0c2689"",
		""locale"": ""en-US"",
		""timestamp"": ""2022-03-31T22:20:16Z"",
		""intent"": {
			""name"": ""DateSlotCheckerIntent"",
			""confirmationStatus"": ""NONE"",
			""slots"": {
				""inputValue"": {
					""name"": ""inputValue"",
					""value"": ""2022-W13"",
					""confirmationStatus"": ""NONE"",
					""source"": ""USER"",
					""slotValue"": {
						""type"": ""Simple"",
						""value"": ""2022-W13""
					}
				},
				""__Conjunction"": {
					""name"": ""__Conjunction"",
					""confirmationStatus"": ""NONE""
				}
			}
		}
	}
}

";
            return str;

        }


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
