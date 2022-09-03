namespace SplatoonBot
{
    public static class TimeExtension
    {
        private static readonly DateTime UnixTimeStartDate = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dateTime = UnixTimeStartDate.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}