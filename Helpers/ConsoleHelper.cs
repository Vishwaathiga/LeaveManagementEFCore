
namespace LeaveManagementEFCore.Helpers;

public static class ConsoleHelper
{
    public static string ReadRequiredInput(string prompt)
    {
        string? input;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }

        } while (string.IsNullOrWhiteSpace(input));

        return input.Trim();
    }

    public static bool TryReadId(string prompt, out int id)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out id) && id > 0)
        {
            return true;
        }

        Console.WriteLine("Invalid ID. Please enter a positive number.");
        id = 0;
        return false;
    }
}
