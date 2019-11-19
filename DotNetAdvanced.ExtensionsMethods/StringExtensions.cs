public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string s, bool whitespace = false)
    {
        if (whitespace)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        return string.IsNullOrEmpty(s);
    }
}
