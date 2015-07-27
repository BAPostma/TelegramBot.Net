using Newtonsoft.Json;
using Telegram.API.Client.Bot.Interfaces;

namespace Telegram.API.Client.Bot.Models
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class Video : ITelegramType, ITelegramFile
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [JsonProperty("file_id")]
        [JsonRequired]
        public string FileId { get; set; }

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        [JsonProperty("width")]
        [JsonRequired]
        public int Width { get; set; }

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        [JsonProperty("height")]
        [JsonRequired]
        public int Height { get; set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        [JsonProperty("required")]
        [JsonRequired]
        public int Duration { get; set; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumbnail { get; set; }

        /// <summary>
        /// Optional. Mime type of a file as defined by sender
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        public int? FileSize { get; set; }

        /// <summary>
        /// Optional. Text description of the video (usually empty)
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}