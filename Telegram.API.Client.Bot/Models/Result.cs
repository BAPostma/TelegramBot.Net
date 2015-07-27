using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    public abstract class ResultBase : ITelegramType
    {
        [JsonProperty("ok")]
        [JsonRequired]
        public bool OK { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Result<T> : ResultBase where T : class, ITelegramType
    {
        [JsonProperty("result")]
        public T ResultObject { get; set; }
    }

    public class Results<T> : ResultBase where T : class, ITelegramType
    {
        [JsonProperty("result")]
        public T[] ResultObject { get; set; }
    }
}