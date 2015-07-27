using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents one size of a <see cref="PhotoSize"/> or a <see cref="Document"/> / <see cref="Sticker"/> thumbnail.
    /// </summary>
    public class PhotoSize : ITelegramType, ITelegramSendable
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [JsonProperty("file_id")]
        [JsonRequired]
        public string FileId { get; set; }

        /// <summary>
        /// Photo width
        /// </summary>
        [JsonProperty("width")]
        [JsonRequired]
        public int Width { get; set; }

        /// <summary>
        /// Photo height
        /// </summary>
        [JsonProperty("height")]
        [JsonRequired]
        public int Height { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        public int? FileSize { get; set; }
    }
}