using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents an incoming update. 
    /// </summary>
    public class Update : ITelegramType
    {
        /// <summary>
        /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you're using Webhooks, 
        /// since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.
        /// </summary>
        [JsonProperty("update_id")]
        [JsonRequired]
        public int UpdateId { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}