namespace Extensions
{
    public static class StringExtensions
    {
        public static bool IsInt(this string s)
        {
            int output;
            return int.TryParse(s, out output);
        }
    }
}
