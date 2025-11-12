namespace ConsoleApplication.Presentation.Helpers
{
    public static class Helper
    {
        public static void ConsoleText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static string Capitalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

    }
}
