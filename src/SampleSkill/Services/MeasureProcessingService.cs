using AlexaNetCore;
using DistanceLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Intents
{
    public class MeasureProcessingService
    {

        public string SrcType { get; private set; }
        public string DestType { get; private set; }
        public double OrigInputVal { get; private set; }
        public double CalculatedOutput { get; set; }
        public ImperialDistance ImperialAnswer { get; private set; }
        public MetricDistance MetricAnswer { get; private set; }
        public int SignificantDigits { get; private set; }
        public AlexaMultiLanguageText SpokenText { get; private set; }


        public MeasureProcessingService(string srcType, string destType, double origInputVal, int significantDigits)
        {
            SrcType = srcType;
            DestType = destType;
            OrigInputVal = origInputVal;
            SignificantDigits = significantDigits;
        }

        public void ProcessRequest(string srcType, string destType, double origInputVal, int significantDigits)
        {
            SrcType = PluralizeMeasureType(srcType);
            DestType = PluralizeMeasureType(destType);
            SignificantDigits = significantDigits;
            OrigInputVal = origInputVal;

            if (IsImperialMeasure(SrcType)) ProcessImperialSource();
            else ProcessMetricSource();

            if (DestType == "millimeters") CalculatedOutput = MetricAnswer.ToMillimeters();
            else if (DestType == "centimeters") CalculatedOutput = MetricAnswer.ToCentimeters();
            else if (DestType == "meters") CalculatedOutput = MetricAnswer.ToMeters();
            else if (DestType == "kilometers") CalculatedOutput = MetricAnswer.ToKilometers();
            else if (DestType == "inches") CalculatedOutput = ImperialAnswer.ToInches();
            else if (DestType == "feet") CalculatedOutput = ImperialAnswer.ToFeet();
            else if (DestType == "yards") CalculatedOutput = ImperialAnswer.ToYards();
            else if (DestType == "miles") CalculatedOutput = ImperialAnswer.ToMiles();
            else
            {
                SpokenText = ResponseTextObjects.BadUnitOfMeasure;
                return;
            }

            var retValDecimalStr = Math.Round(CalculatedOutput, SignificantDigits) + " " + DestType;

            string retValImperialStr = "";
            if (IsImperialMeasure(SrcType)) retValImperialStr = ", or " + ImperialAnswer.GetSpokenText();

            var fullTextString = OrigInputVal + " " + SrcType + " is " + retValDecimalStr + retValImperialStr;

        }

        public bool IsValidMeasure(string val)
        {
            return IsImperialMeasure(val) || IsMetricMeasure(val);
        }

        public bool IsImperialMeasure(string val)
        {
            if (string.IsNullOrEmpty(val)) return true;
            var valLower = val.ToLower();
            if (valLower == "feet" || valLower == "foot") return true;
            if (valLower == "yards" || valLower == "yard") return true;
            if (valLower == "miles" || valLower == "mile") return true;
            if (valLower == "inches" || valLower == "inch") return true;
            return false;
        }

        public bool IsMetricMeasure(string val)
        {
            if (string.IsNullOrEmpty(val)) return true;
            var valLower = val.ToLower();
            if (valLower == "centimeter" || valLower == "centimeters") return true;
            if (valLower == "millimeter" || valLower == "millimeters") return true;
            if (valLower == "meter" || valLower == "meters") return true;
            if (valLower == "kilometer" || valLower == "kilometers") return true;
            return false;
        }


        public static string PluralizeMeasureType(string srcType)
        {
            if (srcType == "inch") return "inches";
            if (srcType == "foot") return "feet";
            if (srcType == "yard") return "yards";
            if (srcType == "mile") return "miles";

            if (srcType == "millimeter") return "millimeters";
            if (srcType == "centimeter") return "centimeters";
            if (srcType == "meter") return "meters";
            if (srcType == "kilometer") return "kilometers";
            return srcType;

        }

        public static string SingularizeMeasureType(string srcType)
        {
            if (srcType == "inches") return "inch";
            if (srcType == "feet") return "foot";
            if (srcType == "yards") return "yard";
            if (srcType == "miles") return "mile";

            if (srcType == "millimeters") return "millimeter";
            if (srcType == "centimeters") return "centimeter";
            if (srcType == "meters") return "meter";
            if (srcType == "kilometers") return "kilometer";
            return srcType;

        }

        
        public void ProcessImperialSource()
        {
            if (SrcType == "feet") OrigInputVal *= 12;
            else if (SrcType == "yards") OrigInputVal *= 12 * 3;
            else if (SrcType == "miles") OrigInputVal *= 63360;

            ImperialAnswer= new ImperialDistance(OrigInputVal);
            MetricAnswer = ImperialAnswer.ToMetricDistance();
        }
        

        public void ProcessMetricSource()
        {
            if (SrcType == "millimeters") OrigInputVal /= 1000;
            else if (SrcType == "centimeters") OrigInputVal /= 100;
            else if (SrcType == "kilometers") OrigInputVal *= 1000;

            MetricAnswer = new MetricDistance(OrigInputVal);
            ImperialAnswer = MetricAnswer.ToImperialDistance();

        }


    }
}
