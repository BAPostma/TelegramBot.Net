using System;

namespace Telegram.API.Client.Bot.Helpers
{
    public static class DateTimeHelpers
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTimestamp(double timestamp)
        {
            DateTime converted = Epoch.AddSeconds(timestamp);
            return converted.ToLocalTime();
        }

        public static double ToUnixTimestamp(DateTime datetime)
        {
            return datetime.Subtract(Epoch).TotalSeconds;
        }
    }
}
