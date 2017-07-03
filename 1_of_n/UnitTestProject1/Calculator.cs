using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    class StringCalculator : IStringCalculator
    {
        /// <summary>
        /// The only max value in the world EV-AR~!
        /// </summary>
        private const int MAX_VALUE = 1000;
        ValuesExtractor valuesExtractor = new StringConcatValueExtractor();

        public int Add(string numbersSeperatedByDelimiter)
        {
            var stringValues = valuesExtractor.Extract(numbersSeperatedByDelimiter);
            var intValues = ParseToInts(stringValues);
            var filteredIntValues = FilterGreaterThanMaxValue(intValues);
            ValidateIntsArePositive(filteredIntValues);

            return SumValues(filteredIntValues);
        }

        private static IList<int> FilterGreaterThanMaxValue(IList<int> parsedValues)
        {
            var result = new List<int>();
            foreach (var value in parsedValues)
            {
                if (value <= MAX_VALUE)
                {
                    result.Add(value);
                }
            }
            return result;
        }

        private static void ValidateIntsArePositive(IList<int> values)
        {
            var negatives = new List<int>();
            foreach (int value in values)
            {
                if (value < 0)
                {
                    negatives.Add(value);
                }
            }
            if (!IsEmpty(negatives))
            {
                var negativesAsCommaSeparetedString = string.Join(",", negatives);
                var exceptionMessage = string.Format("negatives not allowed {0}", negativesAsCommaSeparetedString);
                throw new ArgumentOutOfRangeException(exceptionMessage, new Exception());
            }
        }

        private static bool IsEmpty(IList<int> negatives)
        {
            return negatives.Count == 0;
        }

        private static IList<int> ParseToInts(IList<string> stringValues)
        {
            var result = new List<int>();

            foreach (string val in stringValues)
            {
                var parsedInt = int.Parse(val);
                result.Add(parsedInt);
            }

            return result;
        }

        private static int SumValues(IList<int> values)
        {
            int sum = 0;
            foreach (int val in values)
            {
                sum += val;
            }

            return sum;
        }
    }

    
}