using System;
using Newtonsoft.Json;
using Telegram.API.Client.Bot.Helpers;

namespace Telegram.API.Client.Bot.Converters
{
    internal class UnixTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            double unixTimestamp = DateTimeHelpers.ToUnixTimestamp((DateTime)value);
            serializer.Serialize(writer, unixTimestamp);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string deserialisedValue = serializer.Deserialize<string>(reader);

            double unixTimestamp;
            if (double.TryParse(deserialisedValue, out unixTimestamp) && unixTimestamp > 0)
            {
                return DateTimeHelpers.FromUnixTimestamp(unixTimestamp);
            }

            if (objectType == typeof(DateTime?))
            {
                return null;
            }

            return DateTime.MinValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(double).IsAssignableFrom(objectType);
        }
    }
}
