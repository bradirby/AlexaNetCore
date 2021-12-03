using System;

namespace AlexaNetCore
{
    public static class IntExtensionMethods
    {
        public static bool IsEven(this int num)
        {
            return (num % 2) == 0;
        }

        public static string ToWords(this int value)
        {
            if (value == 0)
                return "Zero";

            if (value < 0)
                return "minus " + ToWords(Math.Abs(value));

            string words = "";

            if ((value / 1000000) > 0)
            {
                words += ToWords(value / 1000000) + " Million ";
                value %= 1000000;
            }

            if ((value / 1000) > 0)
            {
                words += ToWords(value / 1000) + " Thousand ";
                value %= 1000;
            }

            if ((value / 100) > 0)
            {
                words += ToWords(value / 100) + " Hundred ";
                value %= 100;
            }

            if (value > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (value < 20)
                    words += unitsMap[value];
                else
                {
                    words += tensMap[value / 10];
                    if ((value % 10) > 0)
                        words += "-" + unitsMap[value % 10];
                }
            }

            return words;
        }

        public static string ToDenominatorWords(this int denominator, bool isPlural)
        {
            return denominator switch
            {
                2 => isPlural ? "Halves" : "Half",
                3 => isPlural ? "Thirds" : "Third",
                4 => isPlural ? "Fourths" : "Fourth",
                5 => isPlural ? "Fifths" : "Fifth",
                6 => isPlural ? "Sixths" : "Sixth",
                7 => isPlural ? "Sevenths" : "Seventh",
                8 => isPlural ? "Eighths" : "Eighth",
                9 => isPlural ? "Ninths" : "Ninth",
                10 => isPlural ? "Tenths" : "Tenth",
                16 => isPlural ? "Sixteenths" : "Sixteenth",
                32 => isPlural ? "Thirty-seconds" : "Thirty-second",
                64 => isPlural ? "Sixty-fourths" : "Sixty-fourth",
                _ => throw new ArgumentException("LocaleString not supported")
            };
        }

        //public static string ToFractionWords(this double decimalPart)
        //{
        //    var txt = "";
        //    decimalPart = decimalPart % 1.0;  //ensure we only have a fraction coming in
            
        //    if (decimalPart.Equals(0.5000)) txt += " One Half ";

        //    else if (decimalPart.Equals(0.2500)) txt += " One Quarter ";
        //    else if (decimalPart.Equals(0.7500)) txt += " Three Quarter ";

        //    else if (decimalPart.Equals(1 / 8.0)) txt += " One Eighth ";
        //    else if (decimalPart.Equals(3 / 8.0)) txt += " Three Eighths ";
        //    else if (decimalPart.Equals(5 / 8.0)) txt += " Five Eighths ";
        //    else if (decimalPart.Equals(7 / 8.0)) txt += " Seven Eighths ";

        //    else if (decimalPart.Equals(1 / 16.0)) txt += " One Sixteenth ";
        //    else if (decimalPart.Equals(3 / 16.0)) txt += " Three Sixteenths ";
        //    else if (decimalPart.Equals(5 / 16.0)) txt += " Five Sixteenths ";
        //    else if (decimalPart.Equals(7 / 16.0)) txt += " Seven Sixteenths ";
        //    else if (decimalPart.Equals(9 / 16.0)) txt += " Nine Sixteenths ";
        //    else if (decimalPart.Equals(11 / 16.0)) txt += " Eleven Sixteenths ";
        //    else if (decimalPart.Equals(13 / 16.0)) txt += " Thirteen Sixteenths ";
        //    else if (decimalPart.Equals(15 / 16.0)) txt += " Fifteen Sixteenths ";

        //    else if (decimalPart.Equals(1 / 32.0)) txt += " One Thirty Second ";
        //    else if (decimalPart.Equals(3 / 32.0)) txt += " Three Thirty Seconds ";
        //    else if (decimalPart.Equals(5 / 32.0)) txt += " Five Thirty Seconds ";
        //    else if (decimalPart.Equals(7 / 32.0)) txt += " Seven Thirty Seconds ";
        //    else if (decimalPart.Equals(9 / 32.0)) txt += " Nine Thirty Seconds ";
        //    else if (decimalPart.Equals(11 / 32.0)) txt += " Eleven Thirty Seconds ";
        //    else if (decimalPart.Equals(13 / 32.0)) txt += " Thirteen Thirty Seconds ";
        //    else if (decimalPart.Equals(15 / 32.0)) txt += " Fifteen Thirty Seconds ";
        //    else if (decimalPart.Equals(17 / 32.0)) txt += " Seventeen Thirty Second ";
        //    else if (decimalPart.Equals(19 / 32.0)) txt += " Nineteen Thirty Seconds ";
        //    else if (decimalPart.Equals(21 / 32.0)) txt += " Twenty One thirty Seconds ";
        //    else if (decimalPart.Equals(23 / 32.0)) txt += " Twenty Three thirty Seconds ";
        //    else if (decimalPart.Equals(25 / 32.0)) txt += " Twenty Five thirty Seconds ";
        //    else if (decimalPart.Equals(27 / 32.0)) txt += " Twenty Seven thirty Seconds ";
        //    else if (decimalPart.Equals(29 / 32.0)) txt += " Twenty Nine thirty Seconds ";
        //    else if (decimalPart.Equals(31 / 32.0)) txt += " Thirty One thirty Seconds ";

        //    else if (decimalPart.Equals(1 / 64.0)) txt += " one Sixty Fourth inch";
        //    else if (decimalPart.Equals(3 / 64.0)) txt += " Three Sixty Fourths ";
        //    else if (decimalPart.Equals(5 / 64.0)) txt += " Five Sixty Fourths ";
        //    else if (decimalPart.Equals(7 / 64.0)) txt += " Seven Sixty Fourths ";
        //    else if (decimalPart.Equals(9 / 64.0)) txt += " Nine Sixty Fourths ";
        //    else if (decimalPart.Equals(11 / 64.0)) txt += " Eleven Sixty Fourths ";
        //    else if (decimalPart.Equals(13 / 64.0)) txt += " Thirteen Sixty Fourths ";
        //    else if (decimalPart.Equals(15 / 64.0)) txt += " Fifteen Sixty Fourths ";
        //    else if (decimalPart.Equals(17 / 64.0)) txt += " Seventeen Sixty Fourths ";
        //    else if (decimalPart.Equals(19 / 64.0)) txt += " Nineteen Sixty Fourths ";
        //    else if (decimalPart.Equals(21 / 64.0)) txt += " Twenty One Sixty Fourths ";
        //    else if (decimalPart.Equals(23 / 64.0)) txt += " Twenty Three Sixty Fourths ";
        //    else if (decimalPart.Equals(25 / 64.0)) txt += " Twenty Five Sixty Fourths ";
        //    else if (decimalPart.Equals(27 / 64.0)) txt += " Twenty Seven Sixty Fourths ";
        //    else if (decimalPart.Equals(29 / 64.0)) txt += " Twenty Nine Sixty Fourths ";
        //    else if (decimalPart.Equals(31 / 64.0)) txt += " Thirty One Sixty Fourths ";
        //    else if (decimalPart.Equals(33 / 64.0)) txt += " Thirty Three Sixty Fourths ";
        //    else if (decimalPart.Equals(35 / 64.0)) txt += " Thirty Five Sixty Fourths ";
        //    else if (decimalPart.Equals(37 / 64.0)) txt += " Thirty Seven Sixty Fourths ";
        //    else if (decimalPart.Equals(39 / 64.0)) txt += " Thirty Nine Sixty Fourths ";
        //    else if (decimalPart.Equals(41 / 64.0)) txt += " Forty One Sixty Fourths ";
        //    else if (decimalPart.Equals(43 / 64.0)) txt += " Forty Three Sixty Fourths ";
        //    else if (decimalPart.Equals(45 / 64.0)) txt += " Forty Five Sixty Fourths ";
        //    else if (decimalPart.Equals(47 / 64.0)) txt += " Forty Seven Sixty Fourths ";
        //    else if (decimalPart.Equals(49 / 64.0)) txt += " Forty Nine Sixty Fourths ";
        //    else if (decimalPart.Equals(51 / 64.0)) txt += " Fifty One Sixty Fourths ";
        //    else if (decimalPart.Equals(53 / 64.0)) txt += " Fifty Three Sixty Fourths ";
        //    else if (decimalPart.Equals(55 / 64.0)) txt += " Fifty Five Sixty Fourths ";
        //    else if (decimalPart.Equals(57 / 64.0)) txt += " Fifty Seven Sixty Fourths ";
        //    else if (decimalPart.Equals(59 / 64.0)) txt += " Fifty Nine Sixty Fourths ";
        //    else if (decimalPart.Equals(61 / 64.0)) txt += " Sixty One Sixty Fourths ";
        //    else if (decimalPart.Equals(63 / 64.0)) txt += " Sixty Three Sixty Fourths ";

        //    return txt.Trim();
        //}

        public static string ToTimeWords(this int value)
        {
            var suffix = " A. M.";
            if (value >= 12)
            {
                suffix = " P. M.";
                value = value - 12;
            }
            decimal val = value;
            var words = val.ToWords(false);
            return words + suffix;
        }

        public static string ToMonthName(this int value)
        {
            switch (value)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
            }
            return "";
        }
    }
}
