using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    public class Sticker : ITelegramType, ITelegramFile
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [JsonProperty("file_id")]
        [JsonRequired]
        public string FileId { get; set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        [JsonProperty("width")]
        [JsonRequired]
        public int Width { get; set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        [JsonProperty("height")]
        [JsonRequired]
        public int Height { get; set; }

        /// <summary>
        /// Optional. Sticker thumbnail in .webp or .jpg format
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumbnail { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        public int? FileSize { get; set; }
    }
}