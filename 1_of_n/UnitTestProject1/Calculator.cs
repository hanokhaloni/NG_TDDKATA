using System;

namespace UnitTestProject1
{
    internal class Calculator
    {
        private const string CUSTOM_PREFIX = "//";
        private static string CUSTOM_AFTER_PREFIX = "\n";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commaSeperatedNumbers"></param>
        /// <returns></returns>
        internal static int Add(string commaSeperatedNumbers)
        {
            var defaultDelimiter = ',';
            //TODO extract "returnZeroForEmptyString
            if (String.IsNullOrEmpty(commaSeperatedNumbers))
            {
                return 0;
            }

            if (commaSeperatedNumbers.StartsWith(CUSTOM_PREFIX))
            {
                defaultDelimiter = commaSeperatedNumbers.Substring(CUSTOM_PREFIX.Length, CUSTOM_PREFIX.Length + 1).ToCharArray()[0];
                commaSeperatedNumbers = commaSeperatedNumbers.Substring(
                    CUSTOM_PREFIX.Length + CUSTOM_AFTER_PREFIX.Length + 1, 
                    commaSeperatedNumbers.Length - CUSTOM_PREFIX.Length - CUSTOM_AFTER_PREFIX.Length - 1);
            }

            var values = commaSeperatedNumbers.Split(defaultDelimiter, '\n');

            return SumValues(values);
        }

        private static int SumValues(string[] values)
        {
            int sum = 0;
            foreach (var val in values)
            {
                sum += int.Parse(val);
            }

            return sum;
        }
    }
}