namespace ExactMeasureSkill.Tests.TestData
{
    public class ApprovalSubmissionSession1Requests : SampleRequestBase
    {



        public static string Request20()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": false,
        ""sessionId"": ""amzn1.echo-api.session.32bf57ad-063d-453e-bd21-685508d698e3"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNECZEWE3MV5WTUJEQCGNTLFY2XOVOMPYVSSWXDPSNMOAYOVBUXX4AY4JJ4XTKACHTFS5K46IYZ5GURASUW4L52RZFYFSDMGT7PW4QV2DINYT6J4HAKEC53KFDETPIWX7TREQHNKQYPMNMVFOMRHIDAO3BO4DYNSHV375XAXP4X4RJZVM324SA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""SessionEndedRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 2,
        ""timestamp"": ""2021-09-24T09:16:29Z"",
        ""requestId"": ""amzn1.echo-api.request.3d246dee-79fa-4aa6-b5ca-676d303f6ca7"",
        ""intent"": null,
        ""reason"": ""USER_INITIATED""
    }
}
";

            return CleanRequest(str);

        }


        public static string Request19()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.1abdd365-864f-425e-a1b3-727cfcdb7fba"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNPNC2KFTVRBONXF7SVWZBN3PQFMDUUPHULXYUJQO33IKZI24C4J7DFJHX6EKT325XUNPLGXYNQLIRTSFIUJLCZC6SVPG4F5D3WEZUGGDL42RXNC2RY3TMYTFRMGQWOT6N7KL47RIFETZTQGP3TAYBRM22UT6IZB4PSGD3IROT7HAWHSB5WZ2Q"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-IN"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:27Z"",
        ""requestId"": ""amzn1.echo-api.request.c31a6307-8a31-4b0c-8ccb-1e643b4214cd"",
        ""intent"": null,
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request18()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": false,
        ""sessionId"": ""amzn1.echo-api.session.ccced341-d388-47e2-89ec-1029049b7048"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNBGOACGFSBWNHPV25FQHTLAPOY5WDDEZMMH4EFVGKFLU47L47WQG4JLXPZQZESOXVXXKLTYGYT4DNM2IX7UL72AORZP5SSO2PUVWUAMPFNLE2POLTXPWF7HAB5RANYFIDRXWK2KN4Y4W3G3JYKA5RUOYS3775LIZCXIIAMFSZPAJBWZHGGKUY"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""SessionEndedRequest"",
        ""locale"": ""en-US"",
        ""RequestType"": 2,
        ""timestamp"": ""2021-09-24T09:16:27Z"",
        ""requestId"": ""amzn1.echo-api.request.3bdb8a57-3870-4380-82a0-65d81683eb9a"",
        ""intent"": null,
        ""reason"": ""USER_INITIATED""
    }
}

";

            return CleanRequest(str);

        }


        public static string Request17()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": false,
        ""sessionId"": ""amzn1.echo-api.session.5a92265c-ba52-47f4-9803-507c09074937"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNIUBLOAVUZ2AXZGZ7J57G3BW6TKGPFCJNGCHBM3YY72TI6YKAXNBUEWHSZABO4HIFEO7U5LAZFP24ESUDBOJQSKHVVJWJDCC5IVLJHPFJDX2FRV2XANQG3EPG2NOOSS5FLCFVTKIUQKPEAWNTU5FZWBIVCQY6FOOAPS5H46FLII2KINS6TEXA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""SessionEndedRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 2,
        ""timestamp"": ""2021-09-24T09:16:27Z"",
        ""requestId"": ""amzn1.echo-api.request.b31e1bb1-9e58-4026-8347-6175427c4e8d"",
        ""intent"": null,
        ""reason"": ""USER_INITIATED""
    }
}
";

            return CleanRequest(str);

        }


        public static string Request16()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.32bf57ad-063d-453e-bd21-685508d698e3"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNECZEWE3MV5WTUJEQCGNTLFY2XOVOMPYVSSWXDPSNMOAYOVBUXX4AY4JJ4XTKACHTFS5K46IYZ5GURASUW4L52RZFYFSDMGT7PW4QV2DINYT6J4HAKEC53KFDETPIWX7TREQHNKQYPMNMVFOMRHIDAO3BO4DYNSHV375XAXP4X4RJZVM324SA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:27Z"",
        ""requestId"": ""amzn1.echo-api.request.a45b9e0f-3864-4bdb-9bf8-3b1782c63621"",
        ""intent"": null,
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request15()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": false,
        ""sessionId"": ""amzn1.echo-api.session.2a34716e-2e19-4cef-8d75-4cf9e77a6f5b"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNECZEWE3MV5WTUJEQCGNTLFY2XOVOMPYVSSWXDPSNMOAYOVBUXX4AY4JJ4XTKACHTFS5K46IYZ5GURASUW4L52RZFYFSDMGT7PW4QV2DINYT6J4HAKEC53KFDETPIWX7TREQHNKQYPMNMVFOMRHIDAO3BO4DYNSHV375XAXP4X4RJZVM324SA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""SessionEndedRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 2,
        ""timestamp"": ""2021-09-24T09:16:27Z"",
        ""requestId"": ""amzn1.echo-api.request.6d02c9b5-a1c3-41fb-bba6-ed7e662b57b4"",
        ""intent"": null,
        ""reason"": ""USER_INITIATED""
    }
}
";

            return CleanRequest(str);

        }


        public static string Request14()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.5a92265c-ba52-47f4-9803-507c09074937"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNIUBLOAVUZ2AXZGZ7J57G3BW6TKGPFCJNGCHBM3YY72TI6YKAXNBUEWHSZABO4HIFEO7U5LAZFP24ESUDBOJQSKHVVJWJDCC5IVLJHPFJDX2FRV2XANQG3EPG2NOOSS5FLCFVTKIUQKPEAWNTU5FZWBIVCQY6FOOAPS5H46FLII2KINS6TEXA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:25Z"",
        ""requestId"": ""amzn1.echo-api.request.8c5bf7dd-7b6a-4a71-85d8-f1c031630d20"",
        ""intent"": null,
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request13()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": false,
        ""sessionId"": ""amzn1.echo-api.session.b00e6db6-88f4-4be3-8a10-2ea6ecd45bf6"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNIUBLOAVUZ2AXZGZ7J57G3BW6TKGPFCJNGCHBM3YY72TI6YKAXNBUEWHSZABO4HIFEO7U5LAZFP24ESUDBOJQSKHVVJWJDCC5IVLJHPFJDX2FRV2XANQG3EPG2NOOSS5FLCFVTKIUQKPEAWNTU5FZWBIVCQY6FOOAPS5H46FLII2KINS6TEXA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""SessionEndedRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 2,
        ""timestamp"": ""2021-09-24T09:16:25Z"",
        ""requestId"": ""amzn1.echo-api.request.83865054-6f60-489d-9f1b-ada97c60ca7a"",
        ""intent"": null,
        ""reason"": ""USER_INITIATED""
    }
}
";

            return CleanRequest(str);

        }


        public static string Request12()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.2a34716e-2e19-4cef-8d75-4cf9e77a6f5b"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNECZEWE3MV5WTUJEQCGNTLFY2XOVOMPYVSSWXDPSNMOAYOVBUXX4AY4JJ4XTKACHTFS5K46IYZ5GURASUW4L52RZFYFSDMGT7PW4QV2DINYT6J4HAKEC53KFDETPIWX7TREQHNKQYPMNMVFOMRHIDAO3BO4DYNSHV375XAXP4X4RJZVM324SA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:23Z"",
        ""requestId"": ""amzn1.echo-api.request.27d5f84f-9315-4b94-9b21-bb56e0d184e6"",
        ""intent"": null,
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request11()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.b00e6db6-88f4-4be3-8a10-2ea6ecd45bf6"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNIUBLOAVUZ2AXZGZ7J57G3BW6TKGPFCJNGCHBM3YY72TI6YKAXNBUEWHSZABO4HIFEO7U5LAZFP24ESUDBOJQSKHVVJWJDCC5IVLJHPFJDX2FRV2XANQG3EPG2NOOSS5FLCFVTKIUQKPEAWNTU5FZWBIVCQY6FOOAPS5H46FLII2KINS6TEXA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:23Z"",
        ""requestId"": ""amzn1.echo-api.request.ae15c951-dc45-49a0-8d1b-20cab4f2708a"",
        ""intent"": null,
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request10()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.ccced341-d388-47e2-89ec-1029049b7048"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNBGOACGFSBWNHPV25FQHTLAPOY5WDDEZMMH4EFVGKFLU47L47WQG4JLXPZQZESOXVXXKLTYGYT4DNM2IX7UL72AORZP5SSO2PUVWUAMPFNLE2POLTXPWF7HAB5RANYFIDRXWK2KN4Y4W3G3JYKA5RUOYS3775LIZCXIIAMFSZPAJBWZHGGKUY"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""LaunchRequest"",
        ""locale"": ""en-US"",
        ""RequestType"": 0,
        ""timestamp"": ""2021-09-24T09:16:23Z"",
        ""requestId"": ""amzn1.echo-api.request.058bd306-1e3a-4573-8f3f-eec10e29a058"",
        ""intent"": null,
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request09()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.9cc22c85-a513-4ec4-b369-e46db7a2e8cf"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNLR6G6VTGKY7NU6NYOKUQKJYIUGRNHJSEYVM44G5KKRSDC5KUURX4XINAST3T4CFVMYRX5UOCJ44R3L57MNTT7ZSIEZ5RLCN5SWFYOPZ3C3ZQZKBJNCUNUZVCPSSAN6SYPRX2GDIEKZPSAEVCOCBV6CSP3HABMH2RQJUJIH6FUWJK63Y4KNLQ"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-IN"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:16Z"",
        ""requestId"": ""amzn1.echo-api.request.ef3d16f6-2936-4f9f-a578-c985ded4c81c"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""41159""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure kilometers""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""miles""
                }
            }
        },
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request08()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.2a325be3-0665-4ef1-8010-ea46522270b4"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNKBTPUSHTQIDEKKNNKYR7JHIVOJ6XRZZNNNPRZKLLG5PPBCOEF4LJCJT7EDHO4GRWRX7PYPVZDM2YW4KRG7MWZOZXL2ANJ2FOXPQAJE6SSN43CHX33YBREQZOHJ276JLOFB7H2DK52VAZMFBA4KXWI4UGH2LAGQUZV7IV6M2LL53SRXFBP3LA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-US"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:16Z"",
        ""requestId"": ""amzn1.echo-api.request.f35fc365-bbcb-4c02-8148-79018df7f173"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""733857""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure feet""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""miles""
                }
            }
        },
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request07()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.0eb43f84-6469-44ad-909f-2541362bae97"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNLR6G6VTGKY7NU6NYOKUQKJYIUGRNHJSEYVM44G5KKRSDC5KUURX4XINAST3T4CFVMYRX5UOCJ44R3L57MNTT7ZSIEZ5RLCN5SWFYOPZ3C3ZQZKBJNCUNUZVCPSSAN6SYPRX2GDIEKZPSAEVCOCBV6CSP3HABMH2RQJUJIH6FUWJK63Y4KNLQ"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-IN"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:15Z"",
        ""requestId"": ""amzn1.echo-api.request.c9de1b1f-7601-42aa-821c-f6ad1816ab33"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""60413551""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure kilometers""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""meters""
                }
            }
        },
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request06()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.2dc8e1ef-456c-49e9-94f5-f60bf34b6838"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNEYZBMTBQJH2NTZSPEYJZM3MAT4SNL7EZTMNG3XEGYRIKXBEJFMLHKPZNGRUMKVJUTVIB6Q3G35DZDAWGNVHWLSQSCUTDEM752Y76LKRHNHCWFGMIGXGPMYH4UBYVAKD4TDCOLKLTQQXL257F4YNPXTBKY5JHK42T53PQ4OM52GQE66OSYK7Y"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:15Z"",
        ""requestId"": ""amzn1.echo-api.request.91a7fb66-bd09-4eeb-af21-bdef41b9d6a6"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""4616237""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure kilometers""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""feet""
                }
            }
        },
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request05()
        {
            var str = @"
{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.f5ee2c87-6163-4b54-b7ea-6e0bda9f5ab5"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNAVW26CDDCDBO5UZUF7RF2LAI42UCB3FOUIAM4326BJH2QRZJSLF6XZE3NHJ75ULHHK7ETTZWXSR75Y4Q6GEMTMYEXQYOWLRBJ5T3JBLCEG6UTSOOGXN5ECQS3FCF6FNHA7K745MJ2VZ2IRM5TKYTBH5G3MJZYCE677BKSXI6TRMWTSEP2S3I"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:15Z"",
        ""requestId"": ""amzn1.echo-api.request.ddb60552-9a32-44d9-a687-338552532e6d"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""48""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure meters""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""millimeters""
                }
            }
        },
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request04()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.b70eec63-30a2-4bfa-936b-2b3f8410e1e5"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNKBTPUSHTQIDEKKNNKYR7JHIVOJ6XRZZNNNPRZKLLG5PPBCOEF4LJCJT7EDHO4GRWRX7PYPVZDM2YW4KRG7MWZOZXL2ANJ2FOXPQAJE6SSN43CHX33YBREQZOHJ276JLOFB7H2DK52VAZMFBA4KXWI4UGH2LAGQUZV7IV6M2LL53SRXFBP3LA"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-US"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:15Z"",
        ""requestId"": ""amzn1.echo-api.request.babfdab3-6446-49d6-ae5f-4fa002578bf8"",
        ""intent"": {
            ""name"": ""WithDecimal"",
            ""slots"": {
                ""decimalValue"": {
                    ""name"": ""decimalValue"",
                    ""value"": ""?""
                },
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""567""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure centimeters""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""millimeters""
                }
            }
        },
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }


        public static string Request03()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.e0026aa9-47a6-4318-9e57-ea3ce44151f3"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNLR6G6VTGKY7NU6NYOKUQKJYIUGRNHJSEYVM44G5KKRSDC5KUURX4XINAST3T4CFVMYRX5UOCJ44R3L57MNTT7ZSIEZ5RLCN5SWFYOPZ3C3ZQZKBJNCUNUZVCPSSAN6SYPRX2GDIEKZPSAEVCOCBV6CSP3HABMH2RQJUJIH6FUWJK63Y4KNLQ"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-IN"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:14Z"",
        ""requestId"": ""amzn1.echo-api.request.79f66c4c-e734-420b-8254-23a00e2158e4"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""9049""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure inches""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""feet""
                }
            }
        },
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }



        public static string Request02()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.77c600d6-4335-4758-bd85-281e07f5f6dc"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNAVW26CDDCDBO5UZUF7RF2LAI42UCB3FOUIAM4326BJH2QRZJSLF6XZE3NHJ75ULHHK7ETTZWXSR75Y4Q6GEMTMYEXQYOWLRBJ5T3JBLCEG6UTSOOGXN5ECQS3FCF6FNHA7K745MJ2VZ2IRM5TKYTBH5G3MJZYCE677BKSXI6TRMWTSEP2S3I"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-CA"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:14Z"",
        ""requestId"": ""amzn1.echo-api.request.6e6b3b95-cc4d-4368-9b99-512cce962fa6"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""10""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure inches""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""meters""
                }
            }
        },
        ""reason"": null
    }
}

";

            return CleanRequest(str);

        }


        public static string Request01()
        {
            var str = @"

{
    ""version"": ""1.0"",
    ""session"": {
        ""new"": true,
        ""sessionId"": ""amzn1.echo-api.session.d727c4ea-f6cd-4cb8-9db3-9ce14e96a8ef"",
        ""attributes"": {},
        ""application"": {
            ""applicationId"": ""amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5""
        },
        ""user"": {
            ""userId"": ""amzn1.ask.account.AFT5J6IUT6UN3NHORXCNS35WNRNEYZBMTBQJH2NTZSPEYJZM3MAT4SNL7EZTMNG3XEGYRIKXBEJFMLHKPZNGRUMKVJUTVIB6Q3G35DZDAWGNVHWLSQSCUTDEM752Y76LKRHNHCWFGMIGXGPMYH4UBYVAKD4TDCOLKLTQQXL257F4YNPXTBKY5JHK42T53PQ4OM52GQE66OSYK7Y"",
            ""accessToken"": null
        }
    },
    ""request"": {
        ""type"": ""IntentRequest"",
        ""locale"": ""en-GB"",
        ""RequestType"": 1,
        ""timestamp"": ""2021-09-24T09:16:14Z"",
        ""requestId"": ""amzn1.echo-api.request.bf846724-3b52-4bf4-a3d3-b83040a51253"",
        ""intent"": {
            ""name"": ""WithoutDecimal"",
            ""slots"": {
                ""inputValue"": {
                    ""name"": ""inputValue"",
                    ""value"": ""36""
                },
                ""sourceType"": {
                    ""name"": ""sourceType"",
                    ""value"": ""measure yards""
                },
                ""destType"": {
                    ""name"": ""destType"",
                    ""value"": ""meters""
                }
            }
        },
        ""reason"": null
    }
}
";

            return CleanRequest(str);

        }

    }
}