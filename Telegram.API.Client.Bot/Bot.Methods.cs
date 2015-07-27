using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Telegram.API.Client.Bot.Interfaces;
using Telegram.API.Client.Bot.Models;

namespace Telegram.API.Client.Bot
{
    public partial class Bot
    {
        /// <summary>
        /// A simple method for testing your bot's auth token.
        /// </summary>
        /// <returns>
        /// Returns basic information about the bot in form of a <see cref="User"/> object.
        /// </returns>
        public async Task<User> GetMeAsync()
        {
            IRestRequest request = CreateGetRestRequest("getMe");
            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<User>(response.Content);
        }

        public User GetMe()
        {
            return GetMeAsync().Result;
        }

        /// <summary>
        /// Use this method to send text messages. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="text">Text of the message to be sent</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A <see cref="ITelegramKeyboard"/> object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns>The sent <see cref="Message"/></returns>
        public async Task<Message> SendMessageAsync(int chatId, string text, bool? disableWebPagePreview = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            IRestRequest request = CreatePostRestRequest("sendMessage");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("text", text);
            request.AddParameter("disable_web_page_preview", disableWebPagePreview);
            request.AddParameter("reply_to_message_id", replyToMessageId);
            request.AddParameter("reply_markup", JsonConvert.SerializeObject(replyMarkup));

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message SendMessage(int chatId, string text, bool? disableWebPagePreview = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            return SendMessageAsync(chatId, text, disableWebPagePreview, replyToMessageId, replyMarkup).Result;
        }

        /// <summary>
        /// Use this method to forward messages of any kind. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="fromChatId">Unique identifier for the chat where the original message was sent — User or GroupChat id</param>
        /// <param name="messageId">Unique message identifier</param>
        /// <returns>The sent <see cref="Message"/></returns>
        public async Task<Message> ForwardMessageAsync(int chatId, int fromChatId, int messageId)
        {
            IRestRequest request = CreatePostRestRequest("forwardMessage");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("from_chat_id", fromChatId);
            request.AddParameter("message_id", messageId);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message ForwardMessage(int chatId, int fromChatId, int messageId)
        {
            return ForwardMessageAsync(chatId, fromChatId, messageId).Result;
        }

        #region Send photo
        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="fileName">The name of the file including the extension</param>
        /// <param name="inputFile">Photo to send. Uploads a new photo using multipart/form-data.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A <see cref="ITelegramKeyboard"/> object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        public async Task<Message> SendPhotoAsync(int chatId, string fileName, byte[] inputFile, string caption = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            IRestRequest request = CreatePostRestRequest("sendPhoto");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("caption", caption);
            request.AddParameter("reply_to_message_id", replyToMessageId);
            request.AddParameter("reply_markup", JsonConvert.SerializeObject(replyMarkup));
            request.AddFile("photo", inputFile, fileName);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message SendPhoto(int chatId, string fileName, byte[] inputFile, string caption = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            return SendPhotoAsync(chatId, fileName, inputFile, caption, replyToMessageId, replyMarkup).Result;
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="photo">Photo to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A <see cref="ITelegramKeyboard"/> object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        public async Task<Message> SendPhotoAsync(int chatId, string photo, string caption = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            IRestRequest request = CreatePostRestRequest("sendPhoto");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("caption", caption);
            request.AddParameter("reply_to_message_id", replyToMessageId);
            request.AddParameter("reply_markup", JsonConvert.SerializeObject(replyMarkup));
            request.AddParameter("photo", photo);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message SendPhoto(int chatId, string photo, string caption = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            return SendPhotoAsync(chatId, photo, caption, replyToMessageId, replyMarkup).Result;
        }
        #endregion

        #region Send audio
        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message.
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as <see cref="Document"/>).
        /// On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="fileName">The name of the file including the extension</param>
        /// <param name="inputFile">Audio to send. Uploads a new photo using multipart/form-data.</param>
        /// <param name="duration">Duration of sent audio in seconds</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A <see cref="ITelegramKeyboard"/> object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        public async Task<Message> SendAudioAsync(int chatId, string fileName, byte[] inputFile, int? duration = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            IRestRequest request = CreatePostRestRequest("sendAudio");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("duration", duration);
            request.AddParameter("reply_to_message_id", replyToMessageId);
            request.AddParameter("reply_markup", JsonConvert.SerializeObject(replyMarkup));
            request.AddFile("audio", inputFile, fileName);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message SendAudio(int chatId, string fileName, byte[] inputFile, int? duration = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            return SendAudioAsync(chatId, fileName, inputFile, duration, replyToMessageId, replyMarkup).Result;
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message.
        /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as <see cref="Document"/>).
        /// On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="audio">Audio to send. You can pass a file_id as String to resend an audio that is already on the Telegram servers</param>
        /// <param name="duration">Duration of sent audio in seconds</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message</param>
        /// <param name="replyMarkup">Additional interface options. A <see cref="ITelegramKeyboard"/> object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        public async Task<Message> SendAudioAsync(int chatId, string audio, int? duration = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            IRestRequest request = CreatePostRestRequest("sendAudio");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("duration", duration);
            request.AddParameter("reply_to_message_id", replyToMessageId);
            request.AddParameter("reply_markup", JsonConvert.SerializeObject(replyMarkup));
            request.AddParameter("audio", audio);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<Message>(response.Content);
        }

        public Message SendAudio(int chatId, string audio, int? duration = null, int? replyToMessageId = null, ITelegramKeyboard replyMarkup = null)
        {
            return SendAudioAsync(chatId, audio, duration, replyToMessageId, replyMarkup).Result;
        }
        #endregion


        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side.
        /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// </summary>
        /// <remarks>
        /// We only recommend using this method when a response from the bot will take a noticeable amount of time to arrive.
        /// </remarks>
        /// <param name="chatId">Unique identifier for the message recipient — User or GroupChat id</param>
        /// <param name="action">Type of action to broadcast. Choose one, depending on what the user is about to receive: typing for text messages, upload_photo for photos, record_video or upload_video for videos, record_audio or upload_audio for audio files, upload_document for general files, find_location for location data.</param>
        /// <example>
        /// The ImageBot needs some time to process a request and upload the image.
        /// Instead of sending a text message along the lines of “Retrieving image, please wait…”, 
        /// the bot may use sendChatAction with action = upload_photo.
        /// The user will see a “sending photo” status for the bot.
        /// </example>
        public async void SendChatActionAsync(int chatId, ChatAction action)
        {
            string actionString;
            switch (action)
            {
                case ChatAction.Typing:
                    actionString = "typing";
                    break;
                case ChatAction.UploadPhoto:
                    actionString = "upload_photo";
                    break;
                case ChatAction.RecordVideo:
                    actionString = "record_video";
                    break;
                case ChatAction.UploadVideo:
                    actionString = "upload_video";
                    break;
                case ChatAction.RecordAudio:
                    actionString = "record_audio";
                    break;
                case ChatAction.UploadAudio:
                    actionString = "upload_audio";
                    break;
                case ChatAction.UploadDocument:
                    actionString = "upload_document";
                    break;
                case ChatAction.FindLocation:
                    actionString = "find_location";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("action");
            }

            IRestRequest request = CreateGetRestRequest("sendChatAction");
            request.AddParameter("chat_id", chatId);
            request.AddParameter("action", actionString);

            IRestResponse response = _restClient.Execute(request);
        }

        public void SendChatAction(int chatId, ChatAction action)
        {
            SendChatActionAsync(chatId, action);
        }

        /// <summary>
        /// Use this method to get a list of profile pictures for a user.
        /// </summary>
        /// <param name="userId">Unique identifier of the target user</param>
        /// <param name="offset">Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns>Returns a <see cref="UserProfilePhotos"/> object.</returns>
        public async Task<UserProfilePhotos> GetUserProfilePhotosAsync(int userId, int? offset = null, int? limit = 100)
        {
            Debug.Assert(limit > 0 && limit <= 100);

            IRestRequest request = CreateGetRestRequest("getUserProfilePhotos");
            request.AddParameter("user_id", userId);
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResult<UserProfilePhotos>(response.Content);
        }

        public UserProfilePhotos GetUserProfilePhotos(int userId, int? offset = null, int? limit = 100)
        {
            return GetUserProfilePhotosAsync(userId, offset, limit).Result;
        }

        /// <summary>
        /// Use this method to receive incoming updates using long polling.
        /// </summary>
        /// <param name="offset">Identifier of the first update to be returned. Must be greater by one than the highest among the identifiers of previously received updates. By default, updates starting with the earliest unconfirmed update are returned. An update is considered confirmed as soon as getUpdates is called with an offset higher than its update_id.</param>
        /// <param name="limit">Limits the number of updates to be retrieved. Values between 1—100 are accepted. Defaults to 100</param>
        /// <param name="timeout">Timeout in seconds for long polling. Defaults to 0, i.e. usual short polling</param>
        /// <returns>An Array of <see cref="Update"/> objects is returned.</returns>
        public async Task<Update[]> GetUpdatesAsync(int? offset = null, int? limit = 100, int? timeout = 0)
        {
            Debug.Assert(limit > 0 && limit <= 100);

            IRestRequest request = CreateGetRestRequest("getUpdates");
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);
            request.AddParameter("timeout", timeout);

            IRestResponse response = _restClient.Execute(request);
            return await PrepareResults<Update>(response.Content);
        }

        public Update[] GetUpdates(int? offset = null, int? limit = 100, int? timeout = 0)
        {
            return GetUpdatesAsync(offset, limit, timeout).Result;
        }

        /// <summary>
        /// Use this method to specify a url and receive incoming updates via an outgoing webhook.
        /// Whenever there is an update for the bot, we will send an HTTPS POST request to the specified url, containing a JSON-serialized Update.
        /// In case of an unsuccessful request, we will give up after a reasonable amount of attempts.
        /// </summary>
        /// <param name="url">HTTPS url to send updates to. Use an empty string to remove webhook integration</param>
        /// <example>
        /// If you'd like to make sure that the Webhook request comes from Telegram, we recommend using a secret path in the URL, e.g. www.example.com/&lt;token&gt;.
        /// Since nobody else knows your bot‘s token, you can be pretty sure it’s us.
        /// </example>
        /// <remarks>
        /// 1. You will not be able to receive updates using getUpdates for as long as an outgoing webhook is set up.
        /// 2. We currently do not support self-signed certificates.
        /// 3. Ports currently supported for Webhooks: 443, 80, 88, 8443.
        /// </remarks>
        public async void SetWebhookAsync(string url = "")
        {
            IRestRequest request = CreateGetRestRequest("setWebhook");
            request.AddParameter("url", url);

            IRestResponse response = _restClient.Execute(request);
        }

        public void SetWebhook(string url = "")
        {
            SetWebhookAsync(url);
        }
    }
}
