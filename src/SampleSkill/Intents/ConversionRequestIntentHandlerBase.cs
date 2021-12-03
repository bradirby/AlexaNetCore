using AlexaNetCore;
using DistanceLibrary;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ExactMeasureSkill.Intents
{
    public abstract class ConversionRequestIntentHandlerBase : AlexaIntentHandlerBase
    {
        private int SignificantDigits => 4;
        private MeasureProcessingService MeasureSvc;

        private string SrcType { get; set; }
        private string DestType { get; set; }
        private double InputVal { get; set; }

        protected ConversionRequestIntentHandlerBase(string intentName, IAlexaSkillMessageLogger log) : base(intentName, log)
        {
        }

        protected abstract double ParseInputVal();

        private string GetSourceType()
        {
            //First try to get from the slot - this can be blank of this is a retry or change in target measure
            var typStr = MeasureProcessingService.PluralizeMeasureType(GetSlotValue(SlotNames.SourceTypeSlotName,""));
            if (!string.IsNullOrEmpty(typStr)) return typStr;

            //look at the attributes to see if we still have a source type from last request
            var prevVal = GetSessionValue("SourceType","");
            if (!string.IsNullOrEmpty(prevVal)) return prevVal;

            return "";
        }

        private string GetDestType()
        {
            //First try to get from the slot - this can be blank of this is a retry or change in target measure
            var typStr = MeasureProcessingService.PluralizeMeasureType( GetSlotValue(SlotNames.DestTypeSlotName,""));
            if (!string.IsNullOrEmpty(typStr)) return typStr;

            //look at the attributes to see if we still have a type from last request
            var prevVal = GetSessionValue("DestType","");
            if (!string.IsNullOrEmpty(prevVal)) return prevVal;
            
            return "";
        }

        public override void Process()
        {
            try
            {
                SrcType = GetSourceType();
                DestType = GetDestType();
                InputVal = ParseInputVal();

                MeasureSvc = new MeasureProcessingService(SrcType, DestType, InputVal, 6);
                
                if (!MeasureSvc.IsValidMeasure(SrcType))
                {
                    MsgLogger.Warning($"Found bad input values SrcType={SrcType}");
                    ResponseEnv.Response.OutputSpeech.SetText(ResponseTextObjects.BadUnitOfMeasure);
                    if (string.IsNullOrEmpty(SrcType)) ResponseEnv.Response.AddSimpleCard("I didn't get that", $"Sorry, I don't think you specified the type of measure you want to convert");
                    else ResponseEnv.Response.AddSimpleCard("I didn't get that", $"Sorry, '{SrcType}' is not a unit of measure I understand");
                    ResponseEnv.Response.SetRepromptSpeech("Can you try that again?");
                    return;
                }


                if (!MeasureSvc.IsValidMeasure(DestType) )
                {
                    MsgLogger.Warning($"Found bad input values DestType={DestType}");
                    ResponseEnv.Response.OutputSpeech.SetText(ResponseTextObjects.BadUnitOfMeasure);
                    if (string.IsNullOrEmpty(DestType))ResponseEnv.Response.AddSimpleCard("I didn't get that", $"Sorry, I don't think you told me what you want to convert {SrcType} into");
                    ResponseEnv.Response.AddSimpleCard("I didn't get that", $"Sorry, '{DestType}' is not a unit I can convert to");
                    ResponseEnv.Response.SetRepromptSpeech("Can you try that again?");
                    return;
                }

                if (InputVal == 0)
                {
                    MsgLogger.Warning($"Found bad input values InputVal={InputVal}");
                    ResponseEnv.Response.OutputSpeech.SetText(ResponseTextObjects.BadUnitOfMeasure);
                    ResponseEnv.Response.AddSimpleCard("I didn't get that", $"Sorry, I didn't understand the value you are asking about. Please try again.");
                    ResponseEnv.Response.SetRepromptSpeech("Can you try that again?");
                    return;
                }

                SetSessionValue("SourceType",SrcType);
                SetSessionValue("DestType",DestType);
                SetSessionValue("OrigVal",InputVal.ToString("f6"));


                if (MeasureSvc.IsImperialMeasure(SrcType))
                {
                    MeasureSvc.ProcessImperialSource();
                }
                else
                {
                    MeasureSvc.ProcessMetricSource( );
                }

                string imgName = "";
                if (MeasureSvc.IsImperialMeasure(SrcType))
                {
                    if (MeasureSvc.IsImperialMeasure(DestType)) imgName = "ExactMeasureImperialToImperial";
                    else imgName = "ExactMeasureImperialToMetric";
                }
                else
                {
                    if (MeasureSvc.IsImperialMeasure(DestType)) imgName = "ExactMeasureMetricToImperial";
                    else imgName = "ExactMeasureMetricToMetric";
                }


                ResponseEnv.Response.AddStandardCard($"{SrcType} to {DestType}", CalculateAnswerForCard(),
                    new AlexaImageLink($"https://exactmeasurebucket.s3.amazonaws.com/{imgName}Small.png"
                        ,$"https://exactmeasurebucket.s3.amazonaws.com/{imgName}Large.png"));


                ResponseEnv.Response.OutputSpeech.SetText(CalculateAnswerInWords());
                ResponseEnv.Response.SetRepromptSpeech(ResponseTextObjects.Reprompt);

            }
            catch (Exception exc)
            {
                MsgLogger.Error(exc, "DecimalRequestIntentHandler");
                ResponseEnv.Response.OutputSpeech.SetText($"I'm sorry, something went wrong.  Can you try again?");
            }

        }

        private string CalculateAnswerInWords()
        {
             
             var retValDecimalStr = GetAnswerString();

             string retValImperialStr = "";
             if (MeasureSvc.IsImperialMeasure(DestType) && !MeasureSvc.IsImperialMeasure(SrcType))
                 retValImperialStr = ", or " + MeasureSvc.ImperialAnswer.GetSpokenText();

             var localSrcType = SrcType;
             if (InputVal == 1) localSrcType = MeasureProcessingService.SingularizeMeasureType(SrcType);
             return InputVal + " " + localSrcType + " is " + retValDecimalStr + retValImperialStr;
        }

        private string CalculateAnswerForCard()
        {
            var retValDecimalStr = GetAnswerString();
            
            var localSrcType = SrcType;
            if (InputVal == 1) localSrcType = MeasureProcessingService.SingularizeMeasureType(SrcType);

            var sb = new StringBuilder();
            sb.AppendLine($"{InputVal} {localSrcType}");
            sb.AppendLine( $" = {retValDecimalStr}");

            if (MeasureSvc.IsImperialMeasure(DestType) && !MeasureSvc.IsImperialMeasure(SrcType))
                sb.AppendLine($" = {MeasureSvc.ImperialAnswer.GetNumericText()}");


            return sb.ToString();

        }

        private string GetAnswerString()
        {
            double retVal;
            if (DestType == "millimeters") retVal = MeasureSvc.MetricAnswer.ToMillimeters();
            else if (DestType == "centimeters") retVal = MeasureSvc.MetricAnswer.ToCentimeters();
            else if (DestType == "meters") retVal = MeasureSvc.MetricAnswer.ToMeters();
            else if (DestType == "kilometers") retVal = MeasureSvc.MetricAnswer.ToKilometers();
            else if (DestType == "inches") retVal = MeasureSvc.ImperialAnswer.ToInches();
            else if (DestType == "feet") retVal = MeasureSvc.ImperialAnswer.ToFeet();
            else if (DestType == "yards") retVal = MeasureSvc.ImperialAnswer.ToYards();
            else if (DestType == "miles") retVal = MeasureSvc.ImperialAnswer.ToMiles();
            else
            {
                //don't know what this could be
                return "";
            }

            return Math.Round(retVal, SignificantDigits) + " " + DestType;
        }

    }
}
