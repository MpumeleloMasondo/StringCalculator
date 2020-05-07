using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddCalculator
{
    public class StringCalculator
    {

        private readonly List<string> DefaultDelimiters = new List<string>() { ",", "\n" };
        private const string CustomDelimiterIdentifier = "//";
        private const string CustomDelimiterIdentifierSeparator = "\n";
        private const int CustomDelimiterIdentifierSeparatorLength = 2;
        private const int CustomDelimiterStartIndex = 2;
        private const int MaximumNumber = 1000;

        public int Add(string numbers)
        {

            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Contains(CustomDelimiterIdentifier))
            {
                GetCustomDelimeters(numbers);
                numbers = ExtractNumbers(numbers);
            }

            return GetSum(numbers);

        }

        private string ExtractNumbers(string numbers)
        {

            numbers = numbers.Substring(numbers.IndexOf("\n") + 1);

            return numbers;
        }

        public int GetSum(string numbers)
        {
            List<string> convertedStringNumbers = numbers.Split(DefaultDelimiters.ToArray(), StringSplitOptions.None).ToList();
            convertedStringNumbers.Remove(string.Empty);

            List<int> convertedNumbers = convertedStringNumbers.ConvertAll(int.Parse);

            PositiveNumbersValidation(convertedNumbers);

            int sumOfNumbers = convertedNumbers.Where(x => x <= MaximumNumber).Sum();

            return sumOfNumbers;
        }

        private void GetCustomDelimeters(string numbers)
        {
            var index = numbers.IndexOf("\n");
            var delimiters = numbers.Substring(CustomDelimiterStartIndex, index - CustomDelimiterStartIndex);
            List<string> splitDelimiters = delimiters.Split('[').Select(x => x.TrimEnd(']')).ToList();
            
            if (splitDelimiters.Contains(string.Empty))
                splitDelimiters.Remove(string.Empty);

            foreach (var delimiter in splitDelimiters)
                DefaultDelimiters.AddRange(delimiter.Split(","));
        }

        private void PositiveNumbersValidation(List<int> convertedNumbers)
        {
            if (!convertedNumbers.Any(x => x < 0)) return;

            var negativeNumbers = string.Join(",", convertedNumbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            throw new FormatException($"negatives not allowed '{negativeNumbers}'");
        }

    }
}