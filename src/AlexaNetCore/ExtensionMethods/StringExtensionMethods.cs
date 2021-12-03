using System.Collections.Generic;
using System.Text;

namespace AlexaNetCore
{
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Determines whether this string is "like" the specified string. Performs a SQL "LIKE" comparison. 
        /// </summary>
        /// <param name="str">This string.</param>
        /// <param name="pattern">The string to compare it against.</param>
        /// <returns></returns>
        public static bool IsLike(this string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            // this code is much faster than a regular expression that performs the same comparison.
            bool isMatch = true;
            bool isWildCardOn = false;
            bool isCharWildCardOn = false;
            bool isCharSetOn = false;
            bool isNotCharSetOn = false;
            bool endOfPattern = false;
            int lastWildCard = -1;
            int patternIndex = 0;
            char p = '\0';
            var set = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                endOfPattern = (patternIndex >= pattern.Length);
                if (!endOfPattern)
                {
                    p = pattern[patternIndex];
                    if (!isWildCardOn && p == '%')
                    {
                        lastWildCard = patternIndex;
                        isWildCardOn = true;
                        while (patternIndex < pattern.Length && pattern[patternIndex] == '%')
                        {
                            patternIndex++;
                        }
                        p = (patternIndex >= pattern.Length) ? '\0' : pattern[patternIndex];
                    }
                    else if (p == '_')
                    {
                        isCharWildCardOn = true;
                        patternIndex++;
                    }
                    else if (p == '[')
                    {
                        if (pattern[++patternIndex] == '^')
                        {
                            isNotCharSetOn = true;
                            patternIndex++;
                        }
                        else
                        {
                            isCharSetOn = true;
                        }

                        set.Clear();
                        if (pattern[patternIndex + 1] == '-' && pattern[patternIndex + 3] == ']')
                        {
                            char start = char.ToUpper(pattern[patternIndex]);
                            patternIndex += 2;
                            char end = char.ToUpper(pattern[patternIndex]);
                            if (start <= end)
                            {
                                for (char ci = start; ci <= end; ci++)
                                {
                                    set.Add(ci);
                                }
                            }
                            patternIndex++;
                        }

                        while (patternIndex < pattern.Length && pattern[patternIndex] != ']')
                        {
                            set.Add(pattern[patternIndex]);
                            patternIndex++;
                        }
                        patternIndex++;
                    }
                }

                if (isWildCardOn)
                {
                    if (char.ToUpper(c) == char.ToUpper(p))
                    {
                        isWildCardOn = false;
                        patternIndex++;
                    }
                }
                else if (isCharWildCardOn)
                {
                    isCharWildCardOn = false;
                }
                else if (isCharSetOn || isNotCharSetOn)
                {
                    bool charMatch = (set.Contains(char.ToUpper(c)));
                    if ((isNotCharSetOn && charMatch) || (isCharSetOn && !charMatch))
                    {
                        if (lastWildCard >= 0)
                        {
                            patternIndex = lastWildCard;
                        }
                        else
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    isNotCharSetOn = isCharSetOn = false;
                }
                else
                {
                    if (char.ToUpper(c) == char.ToUpper(p))
                    {
                        patternIndex++;
                    }
                    else
                    {
                        if (lastWildCard >= 0)
                        {
                            patternIndex = lastWildCard;
                        }
                        else
                        {
                            isMatch = false;
                            break;
                        }
                    }
                }
            }
            endOfPattern = (patternIndex >= pattern.Length);

            if (isMatch && !endOfPattern)
            {
                bool isOnlyWildCards = true;
                for (int i = patternIndex; i < pattern.Length; i++)
                {
                    if (pattern[i] != '%')
                    {
                        isOnlyWildCards = false;
                        break;
                    }
                }
                if (isOnlyWildCards)
                {
                    endOfPattern = true;
                }
            }
            return (isMatch && endOfPattern);
        }

        public static string ToPhoneNumberWords(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";
            str = str.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            var sb = new StringBuilder();
            int counter = 0;
            foreach (char c in str)
            {
                counter++;
                sb.Append(c);
                sb.Append(" ");
                if (counter == 3 || counter == 6) sb.Append(",");
            }
            return sb.ToString();
        }
    }
}


