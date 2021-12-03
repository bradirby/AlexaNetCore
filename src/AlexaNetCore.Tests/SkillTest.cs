using System.Collections.Generic;
using AlexaSkillDotNet;

namespace SkillForNet.Tests
{
    public class SkillTest : AlexaSkillBase
    {
        public List<string> VisitedList { get; set; } = new List<string>();  
        public SkillTest() : base(new FakeAlexaSkillMessageLogger( "SkillTest"))
        {
        }

        protected override void ProcessSessionEndedRequest()
        {
            VisitedList.Add("ProcessSessionEndedRequest");
        }

        protected override void ProcessStartOverIntent()
        {
            VisitedList.Add("ProcessStartOverIntent");
        }

        protected override void ProcessYesIntent()
        {
            VisitedList.Add("ProcessYesIntent");
        }

        protected override void ProcessNoIntent()
        {
            VisitedList.Add("ProcessNoIntent");
        }

        protected override void ProcessPauseIntent()
        {
            VisitedList.Add("ProcessPauseIntent");
        }

        protected override void ProcessPreviousIntent()
        {
            VisitedList.Add("ProcessPreviousIntent");
        }

        protected override void ProcessResumeIntent()
        {
            VisitedList.Add("ProcessResumeIntent");
        }

        protected override void ProcessRepeatIntent()
        {
            VisitedList.Add("ProcessRepeatIntent");
        }

        protected override void ProcessCustomIntentRequest()
        {
            VisitedList.Add("ProcessCustomIntentRequest");
        }

        protected override void ProcessLaunchRequest()
        {
            VisitedList.Add("ProcessLaunchRequest");
        }


        protected override void ProcessCancelIntent()
        {
            VisitedList.Add("ProcessCancelIntent");
        }

        protected override void ProcessStopIntent()
        {
            VisitedList.Add("ProcessStopIntent");
        }

        protected override void ProcessHelpIntent()
        {
            VisitedList.Add("ProcessHelpIntent");
        }

        protected override void ProcessNextIntent()
        {
            VisitedList.Add("ProcessNextIntent");
        }

        protected override void ProcessErrorInRequest()
        {
            VisitedList.Add("ProcessErrorInRequest");
        }
    }
}