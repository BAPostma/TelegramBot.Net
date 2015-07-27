using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class User : ITelegramType, ITelegramChat
    {
        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }

        /// <summary>
        /// User's or bot's first name
        /// </summary>
        [JsonProperty("first_name")]
        [JsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. User's or bot's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Optional. User's or bot's username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
