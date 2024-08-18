using StringCalculator.App.Interfaces;

namespace StringCalculator.App.Utilities
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            if (IsNullOrEmpty(numbers)) return 0;

            var delimiters = GetDefaultDelimiters();
            numbers = HandleCustomDelimiters(numbers, delimiters);

            var numberList = ParseNumbers(numbers, delimiters);

            ValidateNoNegatives(numberList);

            return CalculateSum(numberList);
        }

        private bool IsNullOrEmpty(string input) => string.IsNullOrEmpty(input);

        private List<string> GetDefaultDelimiters() => new List<string> { ",", "\n" };

        private string HandleCustomDelimiters(string numbers, List<string> delimiters)
        {
            if (!numbers.StartsWith("//")) return numbers;

            var delimiterEndIndex = numbers.IndexOf('\n');
            var delimiterSection = numbers.Substring(2, delimiterEndIndex - 2);

            if (IsMultipleCustomDelimiters(delimiterSection))
            {
                AddMultipleDelimiters(delimiters, delimiterSection);
            }
            else
            {
                delimiters.Add(delimiterSection);
            }

            return numbers.Substring(delimiterEndIndex + 1);
        }

        private bool IsMultipleCustomDelimiters(string delimiterSection) =>
            delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]");

        private void AddMultipleDelimiters(List<string> delimiters, string delimiterSection)
        {
            var customDelimiters = delimiterSection.Trim('[', ']').Split("][");
            delimiters.AddRange(customDelimiters);
        }

        private List<int> ParseNumbers(string numbers, List<string> delimiters)
        {
            var numArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            return numArray
                .Where(num => int.TryParse(num, out _))
                .Select(int.Parse)
                .ToList();
        }

        private void ValidateNoNegatives(List<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(",", negatives)}");
            }
        }

        private int CalculateSum(List<int> numbers) =>
            numbers.Where(n => n <= 1000).Sum();
    }
}
