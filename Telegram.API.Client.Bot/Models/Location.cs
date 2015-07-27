using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a point on the map.
    /// </summary>
    public class Location : ITelegramType, ITelegramSendable
    {
        /// <summary>
        /// Longitude as defined by sender
        /// </summary>
        [JsonProperty("longitude")]
        [JsonRequired]
        public float Longitude { get; set; }

        /// <summary>
        /// Latitude as defined by sender
        /// </summary>
        [JsonProperty("latitude")]
        [JsonRequired]
        public float Latitude { get; set; }
    }
}