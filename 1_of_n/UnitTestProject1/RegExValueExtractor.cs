using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class RegExValueExtractor : ValuesExtractor
    {
        private const string CUSTOM_PREFIX_REGEX_PATTERN =
            @"(" +
            CUSTOM_DELIMITER_PREFIX +
            @"(.+)" +
            CUSTOM_DELIMITER_POSTFIX +
            ")(.*)";
        private const int NUMBERS_REGEX_GROUP = 3;
        private const int DELIMITER_REGEX_GROUP = 2;

        public override void resolveNumbersSeperatedByDelimiter(string input)
        {
            Match match = Regex.Match(input, CUSTOM_PREFIX_REGEX_PATTERN);

            if (match.Success)
            {
                numbersSeperatedByDelimiter = match.Groups[NUMBERS_REGEX_GROUP].ToString();
                delimiter = match.Groups[DELIMITER_REGEX_GROUP].ToString().ToCharArray()[0];
            }
        }
    }
}
