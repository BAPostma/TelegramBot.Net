using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a phone contact.
    /// </summary>
    public class Contact : ITelegramType, ITelegramSendable
    {
        /// <summary>
        /// Contact's phone number
        /// </summary>
        [JsonProperty("phone_number")]
        [JsonRequired]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contact's first name
        /// </summary>
        [JsonProperty("first_name")]
        [JsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Contact's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Optional. Contact's user identifier in Telegram
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}