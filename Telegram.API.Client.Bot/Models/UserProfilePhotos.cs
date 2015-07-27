using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represent a user's profile pictures.
    /// </summary>
    public class UserProfilePhotos : ITelegramType
    {
        /// <summary>
        /// Total number of profile pictures the target user has
        /// </summary>
        [JsonProperty("total_count")]
        [JsonRequired]
        public int Count { get; set; }

        /// <summary>
        /// Requested profile pictures (in up to 4 sizes each)
        /// </summary>
        [JsonProperty("photos")]
        [JsonRequired]
        public PhotoSize[][] Photos { get; set; }
    }
}