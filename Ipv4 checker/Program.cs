public class Ipv4Checker
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("IPv4 Checker");
        Console.WriteLine("=============");

        do
        {
            Console.WriteLine("\nPaste your IP here:");
            string? userIp = Console.ReadLine();

            if (string.IsNullOrEmpty(userIp))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nInput cannot be empty!");
                Console.ResetColor();
            }
            else if (ValidateIP(userIp))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{userIp} is a valid IPv4 address.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{userIp} is not a valid IPv4 address.");
                Console.ResetColor();
            }
            Thread.Sleep(1000);
        } while (true);
    }

    public static bool ValidateIP(string? userIp)
    {
        if (userIp == null || userIp.Length < 7 || userIp.Length > 15)
            return false;

        string[] parts = userIp.Split('.');
        if (parts.Length != 4)
            return false;

        foreach (string part in parts)
        {
            if (part.Length > 3)
                return false;

            if (!int.TryParse(part, out int number) || number < 0 || number > 255 || (part.Length > 1 && part[0] == '0'))
                return false;
        }
        return true;
    }
}
