using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace StringCalculator.App
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            RunStringCalculator(serviceProvider);
            RunLinkedListDemo(serviceProvider);
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .BuildServiceProvider();
        }

        private static void RunStringCalculator(ServiceProvider serviceProvider)
        {
            var calculator = new Utilities.StringCalculator();

            Console.WriteLine("Enter numbers for the String Calculator:");
            var input = Console.ReadLine();

            input = ReplaceEscapedNewline(input);

            try
            {
                var result = calculator.Add(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static string ReplaceEscapedNewline(string input)
        {
            return input?.Replace("\\n", "\n");
        }

        private static void RunLinkedListDemo(ServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService<ILogger<Program>>();
            var linkedListLogger = serviceProvider.GetService<ILogger<Models.LinkedList<int>>>();

            var linkedList = new Models.LinkedList<int>(linkedListLogger);

            InsertElements(linkedList, logger);
            DeleteElements(linkedList, logger);
        }

        private static void InsertElements(Models.LinkedList<int> linkedList, ILogger logger)
        {
            linkedList.Insert(1, 0);
            linkedList.Insert(2, 1);
            linkedList.Insert(3, 2);
            linkedList.Insert(4, 1);

            logger.LogInformation("List after inserting elements:");
            linkedList.PrintList(); // Output: 1 -> 4 -> 2 -> 3 -> null
        }

        private static void DeleteElements(Models.LinkedList<int> linkedList, ILogger logger)
        {
            linkedList.Delete(1);
            logger.LogInformation("List after deleting element at position 1:");
            linkedList.PrintList(); // Output: 1 -> 2 -> 3 -> null

            linkedList.Delete(0);
            logger.LogInformation("List after deleting head:");
            linkedList.PrintList(); // Output: 2 -> 3 -> null

            linkedList.Delete(1);
            logger.LogInformation("List after deleting last element:");
            linkedList.PrintList(); // Output: 2 -> null
        }
    }
}
