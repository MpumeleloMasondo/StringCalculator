using System;
using System.Collections.Generic;
using System.Linq;

namespace AddCalculator
{
    public class Program
    {

        private static readonly List<string> DefaultDelimiters = new List<string>() { ",", "\n" };
        private const string CustomDelimiterIdentifier = "//";
        private const string CustomDelimiterIdentifierSeparator = "\n";
        private const int CustomDelimiterIdentifierSeparatorLength = 2;
        private const int CustomDelimiterStartIndex = 2;
        private const int MaximumNumber = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter you value");
            string read = Console.ReadLine();
            Console.WriteLine(Add(read));
        }

        public static int Add(string numbers)
        {

            string delimiterPrefix = "//";

            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Contains(delimiterPrefix))
            {
                GetCustomDelimeters(numbers);
                numbers = ExtractNumbers(numbers);
            }

            return GetSum(numbers);

        }

        private static string ExtractNumbers(string numbers)
        {

            numbers = numbers.Substring(numbers.IndexOf(@"\n") + CustomDelimiterIdentifierSeparatorLength);

            return numbers; 
        }

        public static int GetSum(string numbers)
        {

            List<int> convertedNumbers = numbers.Split(DefaultDelimiters.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();

            PositiveNumbersValidation(convertedNumbers);

            int sumOfNumbers = convertedNumbers.Where(x => x <= MaximumNumber).Sum();

            return sumOfNumbers;
        }

        private static void GetCustomDelimeters(string numbers)
        {

            var delimiters = numbers.Substring(CustomDelimiterStartIndex, numbers.IndexOf(@"\n") - CustomDelimiterStartIndex);
            var splitDelimiters = delimiters.Split('[').Select(x => x.TrimEnd(']')).ToList();

            if (splitDelimiters.Contains(string.Empty))
                splitDelimiters.Remove(string.Empty);

            foreach (var delimiter in splitDelimiters)
                DefaultDelimiters.AddRange(delimiter.Split(","));
        }

        private static void PositiveNumbersValidation(List<int> convertedNumbers)
        {
            if (!convertedNumbers.Any(x => x < 0)) return;

            var negativeNumbers = string.Join(",", convertedNumbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            throw new FormatException($"negatives not allowed '{negativeNumbers}'");
        }

    }
}
