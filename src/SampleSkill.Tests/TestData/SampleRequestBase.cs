using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    [DebuggerStepThrough]
    public abstract class SampleRequestBase
    {
        public static List<string> AllValidRequests { get; set;  } = new List<string>();

        public static void AddRequestToList(string req)
        {
            if (!AllValidRequests.Contains(req)) AllValidRequests.Add(req);
        }

        protected static string CleanRequest(string reqJson)
        {
            AddRequestToList(reqJson);
            return reqJson;
        }

    }
}
