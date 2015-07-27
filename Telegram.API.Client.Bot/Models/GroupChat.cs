using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a group chat.
    /// </summary>
    public class GroupChat : ITelegramType, ITelegramChat
    {
        /// <summary>
        /// Unique identifier for this group chat
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        [JsonProperty("title")]
        [JsonRequired]
        public string Title { get; set; }
    }
}