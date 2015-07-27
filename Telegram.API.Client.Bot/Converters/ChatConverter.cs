using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Telegram.API.Client.Bot.Helpers;
using Telegram.API.Client.Bot.Models;

namespace Telegram.API.Client.Bot.Converters
{
    internal class ChatConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // default way of writing
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IDictionary<string, object> deserialisedValue = serializer.Deserialize<IDictionary<string, object>>(reader);
            string deserialisedStringValue = JsonConvert.SerializeObject(deserialisedValue);

            if (deserialisedValue.ContainsKey("title"))
            {
                return JsonConvert.DeserializeObject<GroupChat>(deserialisedStringValue);
            }
            else
            {
                return JsonConvert.DeserializeObject<User>(deserialisedStringValue);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(GroupChat).IsAssignableFrom(objectType) && typeof(User).IsAssignableFrom(objectType);
        }
    }
}
