using System;
using System.Text;

namespace AlexaNetCore
{
    public static class DecimalExtensionMethods
    {

        private static string[] _ones =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        private static string[] _teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private static string[] _tens =
        {
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        // US Nnumbering:
        private static string[] _thousands =
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
        };

        public static string ToMoneyWords(this decimal value)
        {
            var dollarWords = value.ToWords(false);
            var cents = (value - Math.Truncate(value)) * 100;
            var centsWords = cents.ToWords(false);
            if (centsWords.Equals("zero", StringComparison.CurrentCultureIgnoreCase) ) return $"{dollarWords} dollars";
            return $"{dollarWords} dollars and {centsWords} cents";
            
        }

        /// <summary>
        /// Converts a numeric value to words suitable for the portion of
        /// a check that writes out the amount.
        /// </summary>
        /// <param name="value">LocaleString to be converted</param>
        /// <returns></returns>
        public static string ToWords(this decimal value, bool appendFraction = false)
        {
            var origValueWasNegative = false;
            if (value < 0)
            {
                origValueWasNegative = true;
                value = -value;
            }
            string digits, temp;
            bool showThousands = false;
            bool allZeros = true;

            StringBuilder builder = new StringBuilder();
            digits = ((long)value).ToString();
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int ndigit = (int)(digits[i] - '0');
                int column = (digits.Length - (i + 1));

                // Determine if ones, tens, or hundreds column
                switch (column % 3)
                {
                    case 0:        // Ones position
                        showThousands = true;
                        if (i == 0)
                        {
                            // First digit in number (last in loop)
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else if (digits[i - 1] == '1')
                        {
                            // This digit is part of "teen" value
                            temp = String.Format("{0} ", _teens[ndigit]);
                            // Skip tens position
                            i--;
                        }
                        else if (ndigit != 0)
                        {
                            // Any non-zero digit
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else
                        {
                            // This digit is zero. If digit in tens and hundreds
                            // column are also zero, don't show "thousands"
                            temp = String.Empty;
                            // Test for non-zero digit in this grouping
                            if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                                showThousands = true;
                            else
                                showThousands = false;
                        }

                        // Show "thousands" if non-zero in grouping
                        if (showThousands)
                        {
                            if (column > 0)
                            {
                                temp = String.Format("{0}{1}{2}",
                                    temp,
                                    _thousands[column / 3],
                                    allZeros ? " " : ", ");
                            }
                            // Indicate non-zero digit encountered
                            allZeros = false;
                        }
                        builder.Insert(0, temp);
                        break;

                    case 1:        // Tens column
                        if (ndigit > 0)
                        {
                            temp = String.Format("{0}{1}",
                                _tens[ndigit],
                                (digits[i + 1] != '0') ? "-" : " ");
                            builder.Insert(0, temp);
                        }
                        break;

                    case 2:        // Hundreds column
                        if (ndigit > 0)
                        {
                            temp = String.Format("{0} hundred ", _ones[ndigit]);
                            builder.Insert(0, temp);
                        }
                        break;
                }
            }

            // Append fractional portion/cents
            if (appendFraction) builder.AppendFormat("and {0:00}/100", (value - (long)value) * 100);

            // Capitalize first letter
            var retVal = $"{Char.ToUpper(builder[0])}{builder.ToString(1, builder.Length - 1)}";
            retVal = retVal.Replace("  ", " ").Trim();
            if (origValueWasNegative) retVal = "Negative " + retVal;
            return retVal;
        }
    }
}
