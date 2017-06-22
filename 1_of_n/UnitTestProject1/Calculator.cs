using System;

namespace UnitTestProject1
{
    internal class Calculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbersSeperatedByDelimiter"></param>
        /// <returns></returns>
        internal static int Add(string numbersSeperatedByDelimiter)
        {
            ValuesExtractor valuesExtractor = new RegExValueExtractor();
            //ValuesExtractor valuesExtractor = new StringConcatValueExtractor();

            var values = valuesExtractor.Extract(numbersSeperatedByDelimiter);

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