using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class ValuesExtractor
    {
        protected const char DEFAULT_DELIMITER = ',';

        protected const string CUSTOM_DELIMITER_PREFIX = "//";
        protected const string CUSTOM_DELIMITER_POSTFIX = "\n";

        protected char delimiter = DEFAULT_DELIMITER;
        protected string numbersSeperatedByDelimiter = "";

        public string[] Values { get; private set; }

        public ValuesExtractor()
        {
            Values = null;
        }

        public ValuesExtractor(string input)
        {
            Values = Extract(input);
        }

        public virtual string[] Extract(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return new string[0];
            }

            resolveNumbersSeperatedByDelimiter(input);
            SplitByDelimiterAndNewline();

            return Values;
        }

        private void SplitByDelimiterAndNewline()
        {
            Values = numbersSeperatedByDelimiter.Split(delimiter, '\n');
        }

        public virtual void resolveNumbersSeperatedByDelimiter(string input) { }


    }

    public class StringConcatValueExtractor : ValuesExtractor
    {
        public override void resolveNumbersSeperatedByDelimiter(string input)
        {
            int numbersStartPosision = 0;

            if (input.StartsWith(CUSTOM_DELIMITER_PREFIX))
            {
                delimiter = input.Substring(CUSTOM_DELIMITER_PREFIX.Length, CUSTOM_DELIMITER_PREFIX.Length + 1).ToCharArray()[0];
                numbersStartPosision += CUSTOM_DELIMITER_PREFIX.Length + CUSTOM_DELIMITER_POSTFIX.Length + 1;//+1 for delimiter size
            }


            int numbersEndPosition = input.Length - numbersStartPosision;

            numbersSeperatedByDelimiter = input.Substring(
                    numbersStartPosision,
                    numbersEndPosition);
        }
    }

    
}
