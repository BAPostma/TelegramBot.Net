using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a general file (as opposed to <see cref="PhotoSize"/> and <see cref="Audio"/> files).
    /// </summary>
    public class Document : ITelegramType, ITelegramFile
    {
        /// <summary>
        /// Unique file identifier
        /// </summary>
        [JsonProperty("file_id")]
        [JsonRequired]
        public string FileId { get; set; }

        /// <summary>
        /// Optional. Document thumbnail as defined by sender
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumbnail { get; set; }

        /// <summary>
        /// Optional. Original filename as defined by sender
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        public int? FileSize { get; set; }
    }
}