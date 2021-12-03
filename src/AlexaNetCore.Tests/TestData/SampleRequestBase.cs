using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlexaSkillDotNet.Tests
{

    public static class ApprovalSubmissionSampleRequestsExtensionMethods
    {
        public static string SetLocale(this string reqString, string lang)
        {
            return reqString.Replace(@"""locale"": ""en-US""", @"""locale"": """ + lang + @"""");
        }

        public static string SetLocale(this string reqString, AlexaLocale locale)
        {
            return reqString.Replace(@"""locale"": ""en-US""", @"""locale"": """ + locale.LocaleString + @"""");
        }

      
    }


    [DebuggerStepThrough]
    public abstract class SampleRequestBase
    {
        public static List<string> AllValidRequests { get; set;  } = new List<string>();

        public static void AddRequestToList(string req)
        {
            if (!AllValidRequests.Contains(req)) AllValidRequests.Add(req);
        }

        public static string CleanRequest(string reqJson)
        {
            AddRequestToList(reqJson);
            return reqJson;
        }

    }
}
