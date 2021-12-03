using AlexaNetCore;
using ExactMeasureSkill.Intents;
using ExactMeasureSkill.Tests;
using ExactMeasureSkill.Tests.TestData;
using NUnit.Framework;

namespace ExactMeasureSkill.Tests
{
    /// <summary>
    /// These tests attempt to cover the skills submission tests that are listed here:
    /// https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-voice-interface-and-user-experience-testing?ref_=pe_679090_102923190
    /// </summary>
    public class SkillSubmissionTests 
    {

        [Test]
        public void LaunchRequest_InvokeWithNoIntent()
        {
            var skill = new ExactMeasureAlexaSkill();
            skill.LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual("Hello, what would you like this Debug version 0.9 to convert?", skill.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void StartRequest()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();
            
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
        }

        
        [Test]
        public void CancelRequest()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("Goodbye", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void EmptyRequest()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.EmptyRequest());
            s.ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual(ResponseTextObjects.BadUnitOfMeasure.GetText(), s.ResponseEnv.Response.OutputSpeech.GetText());
            Assert.AreEqual("Sorry, I didn't understand the value you are asking about. Please try again.", s.ResponseEnv.Response.Card.Text.GetText());
        }

        
        [Test]
        public void StopRequest()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("Goodbye", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));

        }

          [Test]
        public void OpenExactMeasure()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.OpenExactMeasure()).ProcessRequest();
            
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.AreEqual("Hello, what would you like this Debug version 0.9 to convert?", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
        }
     

        [Test]
        public void InvalidIntentName()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.InvalidIntentName()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
        }

        [Test]
        public void InvalidIntentType()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.InvalidIntentType()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("I can help you convert length measurements from ImperialAnswer to MetricAnswer and back.  Just tell me the measure you want to convert, the original units like feet, inches , meters, or millimeters, and the units you want to convert into. I will tell you the conversion up to 4 decimal places.", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void LambdaManagementTestToolStartSession()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.StartSession()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("Hello, what would you like this Debug version 0.9 to convert?", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }
        [Test]
        public void LambdaManagementTestToolEndSession()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.EndSession()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("Goodbye", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }
        [Test]
        public void CancelRequestSentFromSimulator()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("Goodbye", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }


        //[Test]
        //public void ProvidingHelp_Test11_AskForHintWithNoProblemActive()
        //{
        //    var skill = new ExactMeasure();
        //    skill.ProcessRequest(ExactMeasureSampleRequests.LaunchRequest());

        //    //get a hint
        //    var hintRequest = new WordProblemSkill(ExactMeasureSampleRequests.Give_Me_A_Hint(), repo, probProvider);
        //    hintRequest.ProcessRequest();

        //    Assert.AreEqual(false, hintRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(hintRequest.HintInvalidMessage, hintRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}

        //[Test]
        //public void ProvidingHelp_Test12_NoActiveProblem()
        //{
        //    var probProvider = new ProblemProvider();
        //    var repo = new UserRepository();

        //    //start the skill
        //    var initRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetLaunchRequest(), repo, probProvider);
        //    initRequest.ProcessRequest();

        //    //ask for help
        //    var helpRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetHelpRequest(), repo, probProvider);
        //    helpRequest.ProcessRequest();

        //    Assert.AreEqual(false, helpRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(helpRequest.HelpMessageNoActiveProblem, helpRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}

        //[Test]
        //public void ProvidingHelp_Test12_ImmediatelyAskQuestion()
        //{
        //    var mockProbProvider = new Mock<IProblemProvider>();

        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(x => x.Get(It.IsAny<string>())).Returns((UserStatus)null);

        //    //ask for help
        //    var helpRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetHelpRequest(), mockRepo.Object, mockProbProvider.Object);
        //    helpRequest.ProcessRequest();

        //    Assert.AreEqual(false, helpRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(helpRequest.HelpMessageNoActiveProblem, helpRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}

        //[Test]
        //public void ProvidingHelp_Test12_ActiveProblem()
        //{
        //    var probProvider = new ProblemProvider();
        //    var repo = new UserRepository();

        //    //start the skill
        //    var initRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetLaunchRequest(), repo, probProvider);
        //    initRequest.ProcessRequest();

        //    //ask a question
        //    var getProbRequest = new WordProblemSkill(ExactMeasureSampleRequests.Tell_Me_A_Problem(), repo, probProvider);
        //    getProbRequest.ProcessRequest();

        //    //ask for help
        //    var helpRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetHelpRequest(), repo, probProvider);
        //    helpRequest.ProcessRequest();

        //    Assert.AreEqual(false, helpRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(helpRequest.HelpMessageActiveProblem, helpRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}


        //[Test]
        //public void ProvidingHelp_Test13_InitSkillAndStop()
        //{
        //    var probProvider = new ProblemProvider();
        //    var repo = new UserRepository();

        //    //start the skill
        //    var initRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetLaunchRequest(), repo, probProvider);
        //    initRequest.ProcessRequest();

        //    //stop
        //    var stopRequest = new WordProblemSkill(ExactMeasureSampleRequests.StopRequest(), repo, probProvider);
        //    stopRequest.ProcessRequest();

        //    Assert.AreEqual(true, stopRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(stopRequest.GoodbyeMessage, stopRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}

        //[Test]
        //public void ProvidingHelp_Test13_AskForProblemThenStop()
        //{
        //    var probProvider = new ProblemProvider();
        //    var repo = new UserRepository();

        //    //start the skill
        //    var initRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetLaunchRequest(), repo, probProvider);
        //    initRequest.ProcessRequest();

        //    //ask a question
        //    var getProbRequest = new WordProblemSkill(ExactMeasureSampleRequests.Tell_Me_A_Problem(), repo, probProvider);
        //    getProbRequest.ProcessRequest();

        //    //stop
        //    var stopRequest = new WordProblemSkill(ExactMeasureSampleRequests.StopRequest(), repo, probProvider);
        //    stopRequest.ProcessRequest();


        //    Assert.AreEqual(true, stopRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(stopRequest.GoodbyeMessage, stopRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}

        //[Test]
        //public void ProvidingHelp_Test13_AskForHintThenStop()
        //{
        //    var probProvider = new ProblemProvider();
        //    var repo = new UserRepository();

        //    //start the skill
        //    var initRequest = new WordProblemSkill(ExactMeasureSampleRequests.GetLaunchRequest(), repo, probProvider);
        //    initRequest.ProcessRequest();

        //    //ask a question
        //    var getProbRequest = new WordProblemSkill(ExactMeasureSampleRequests.Tell_Me_A_Problem(), repo, probProvider);
        //    getProbRequest.ProcessRequest();

        //    //get a hint
        //    var hintRequest = new WordProblemSkill(ExactMeasureSampleRequests.Give_Me_A_Hint(), repo, probProvider);
        //    hintRequest.ProcessRequest();

        //    //stop
        //    var stopRequest = new WordProblemSkill(ExactMeasureSampleRequests.StopRequest(), repo, probProvider);
        //    stopRequest.ProcessRequest();

        //    //should not stop the process when person stops the hint
        //    Assert.AreEqual(false, stopRequest.ResponseEnv.ResponseEnv.ShouldEndSession);
        //    Assert.AreEqual(stopRequest.OKMessage, stopRequest.ResponseEnv.ResponseEnv.OutputSpeech.Text);
        //}
    }
}

