using System;
using System.Collections.Generic;
using System.Text;
using AlexaNetCore;
using DistanceLibrary;

namespace ExactMeasureSkill
{
    public static class DistanceExtensionMethods
    {

        public static string GetNumericText(this ImperialDistance distance)
        {
            var measures = distance.ToInches().InchesToMilesFeetInchFraction();
            var inchesModifier = "";
            var txt = "";
            if (measures.Miles > 0)
            {
                if (measures.Miles == 1) txt += " 1 mile ";
                else txt +=  $" {measures.Miles} miles ";
            }
            if (measures.Feet > 0)
            {
                if (measures.Feet == 1) txt +=  " 1 foot ";
                else txt += $" {measures.Feet} feet ";
            }
            if (measures.Inches > 0)
            {
                txt += measures.Inches.ToString();
                inchesModifier = measures.Inches == 1 ? " inch " : " inches ";
            }

            if (measures.Numerator.Equals(0))
            {
                txt += inchesModifier;
            }
            else
            {
                txt += $" {measures.Numerator}/{measures.Denominator} inches";
            }

            return txt.Replace("  ", " ").Trim();

        }

        public static string GetSpokenText(this ImperialDistance distance)
        {
            var measures = distance.ToInches().InchesToMilesFeetInchFraction();
            var inchesModifier = "";
            var txt = "";
            if (measures.Miles > 0)
            {
                if (measures.Miles == 1) txt += measures.Miles.ToWords() + " mile ";
                else txt += measures.Miles.ToWords() + " miles ";
            }
            if (measures.Feet > 0)
            {
                if (measures.Feet == 1) txt += measures.Feet.ToWords() + " foot ";
                else txt += measures.Feet.ToWords() + " feet ";
            }
            if (measures.Inches > 0)
            {
                txt += measures.Inches.ToWords();
                inchesModifier = measures.Inches == 1 ? " inch " : " inches ";
            }

            if (measures.Numerator.Equals(0))
            {
                txt += inchesModifier;
                return txt.Replace("  ", " ").Trim();
            }

            txt += $" and {measures.Numerator.ToWords()} {measures.Denominator.ToDenominatorWords(measures.Numerator > 1)} inches";
            return txt.Replace("  ", " ").Trim();

        }


        public static string GetSpokenText(this MetricDistance distance)
        {
            
            var meters = (int)distance.ToMeters();
            var kilometers = (int) meters / 1000;
            meters = meters - (kilometers * 1000);

            var kilometerStr = "";
            var kilometerUnitsStr = "";
            if (kilometers > 0)
            {
                kilometerStr  = kilometers.ToWords();
                if (kilometers > 1)kilometerUnitsStr  = " kilometers ";
                else kilometerUnitsStr = " kilometer ";
            }

            var meterStr = "";
            var meterUnitsStr = "";
            if (meters > 0)
            {
                if (kilometers > 0) meterStr = " and ";
                meterStr += meters.ToWords();

                if (meters > 1) meterUnitsStr = " meters ";
                else meterUnitsStr =  " meter ";
            }


            var fractionStr = "";
            var fractionUnitsStr = "";
            var centimeters= (int)((distance.ToMeters() % 1.0)*100);
            if (centimeters> 0)
            {
                if (kilometers > 0 || meters > 0) fractionStr = " and ";
                fractionStr += centimeters.ToWords();

                if (centimeters > 1) fractionUnitsStr = " centimeters ";
                else fractionUnitsStr =  " centimeters ";
            }


            return ($"{kilometerStr} {kilometerUnitsStr} {meterStr} {meterUnitsStr} {fractionStr} {fractionUnitsStr}")
                .Replace("  ", " ")
                .Replace("  ", " ")
                .Trim();
        }

    }
}
