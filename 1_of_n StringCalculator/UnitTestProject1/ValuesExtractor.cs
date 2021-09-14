using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public interface Ix
    {
         void resolveNumbersSeperatedByDelimiter(string input);

    }
    public abstract class ValuesExtractor : Ix
    {
        protected const string DEFAULT_DELIMITER = ",";

        protected const string CUSTOM_DELIMITER_PREFIX = "//";
        protected const string CUSTOM_DELIMITER_POSTFIX = "\n";

        protected string delimiter = DEFAULT_DELIMITER;
        protected string numbersSeperatedByDelimiter = "";

        public IList<String> Values { get; private set; }

        public ValuesExtractor()
        {
            Values = null;
        }

        public IList<String> Extract(string input)
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
            var seperators = new string[] { delimiter, CUSTOM_DELIMITER_POSTFIX };
            Values = numbersSeperatedByDelimiter.Split(seperators, StringSplitOptions.None).ToList();
        }

        public abstract void resolveNumbersSeperatedByDelimiter(string input);
    }

    public class StringConcatValueExtractor : ValuesExtractor
    {
        public override void resolveNumbersSeperatedByDelimiter(string input)
        {
            int numbersStartPosision = 0;
            int numbersLength = 0;

            if (input.StartsWith(CUSTOM_DELIMITER_PREFIX))
            {
                numbersStartPosision = input.IndexOf(CUSTOM_DELIMITER_POSTFIX) + CUSTOM_DELIMITER_POSTFIX.Length;

                int delimiterStartProsition;
                int delimiterEndPosition;
                int delimiterSize;
                if (input.Contains('['))
                {
                    delimiterStartProsition = input.IndexOf('[')+1;
                    delimiterEndPosition = input.IndexOf(']');
                    delimiterSize = delimiterEndPosition - delimiterStartProsition;
                    delimiter = input.Substring(delimiterStartProsition, delimiterSize);

                }
                else
                {
                    delimiterStartProsition = input.IndexOf(CUSTOM_DELIMITER_PREFIX) + CUSTOM_DELIMITER_PREFIX.Length;
                    delimiterEndPosition = input.IndexOf(CUSTOM_DELIMITER_POSTFIX);
                    delimiterSize = delimiterEndPosition - delimiterStartProsition;
                    delimiter = input.Substring(delimiterStartProsition, delimiterSize);
                }
            }

            numbersLength = input.Length - numbersStartPosision;

            numbersSeperatedByDelimiter = input.Substring(
                    numbersStartPosision,
                    numbersLength);
        }
    }

    
}
