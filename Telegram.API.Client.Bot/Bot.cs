using System;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Telegram.API.Client.Bot.Interfaces;
using Telegram.API.Client.Bot.Models;

namespace Telegram.API.Client.Bot
{
    public partial class Bot
    {
        private readonly string _apiUrl = "https://api.telegram.org/bot";
        private readonly RestClient _restClient;

        public string APIToken { get; private set; }

        public Bot(string apiToken, string apiUrl = null)
        {
            APIToken = apiToken;
            _apiUrl = string.IsNullOrWhiteSpace(apiUrl) ? string.Concat(_apiUrl, APIToken) : string.Concat(apiUrl, apiToken);
            _restClient = new RestClient(_apiUrl);
        }

        private IRestRequest CreateGetRestRequest(string method)
        {
            IRestRequest request = new RestRequest("{method}", Method.GET);
            request.AddUrlSegment("method", method);
            return request;
        }

        private IRestRequest CreatePostRestRequest(string method)
        {
            IRestRequest request = new RestRequest("{method}", Method.POST);
            request.AddUrlSegment("method", method);
            return request;
        }

        private async Task<T> PrepareResult<T>(string response) where T : class, ITelegramType, new()
        {
            Result<T> resultWrapper = await Task.Run(() => JsonConvert.DeserializeObject<Result<T>>(response));
            if (resultWrapper.OK) return await Task.FromResult(resultWrapper.ResultObject);

            throw new WebException(string.Format("{0} (Error code {1})", resultWrapper.Description, resultWrapper.ErrorCode));
        }

        private async Task<T[]> PrepareResults<T>(string response) where T : class, ITelegramType, new()
        {
            Results<T> resultsWrapper = await Task.Run(() => JsonConvert.DeserializeObject<Results<T>>(response));
            if (resultsWrapper.OK) return await Task.FromResult(resultsWrapper.ResultObject);

            throw new WebException(string.Format("{0} (Error code {1})", resultsWrapper.Description, resultsWrapper.ErrorCode));
        }
    }
}
