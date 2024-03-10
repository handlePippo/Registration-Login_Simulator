namespace ClubMembershipApplication.Commons
{

    public enum FontTheme
    {
        Default,
        Danger,
        Success
    }

    public static class CommonOutputFormat
    {
        public static void ChangeFontColor(FontTheme theme)
        {
            if (theme == FontTheme.Danger)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (theme == FontTheme.Success)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
