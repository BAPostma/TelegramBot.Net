using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.API.Client.Bot.Models;

namespace Telegram.API.Client.Bot
{
    public partial class Bot
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private Task _getUpdatesTask;
        private int _lastUpdateId = 0;

        public event Action<Message> OnMessageReceived;

        protected virtual void FireMessageReceived(Message result)
        {
            if (OnMessageReceived == null) return;
            OnMessageReceived.Invoke(result);
        }

        /// <summary>
        /// Starts the listening for updates and fires a <see cref="OnMessageReceived"/> event when a message is received.
        /// </summary>
        /// <param name="pollingInterval">The interval of polling in seconds (default set)</param>
        public void Start(int pollingInterval = 1)
        {
            if (_getUpdatesTask != null) return;

            try
            {
                Action poll = async () =>
                {
                    while (!_cancellationTokenSource.IsCancellationRequested)
                    {
                        Update[] updates = await GetUpdatesAsync(_lastUpdateId, timeout: pollingInterval);
                        foreach (Update update in updates.Where(u => u.UpdateId > _lastUpdateId))
                        {
                            FireMessageReceived(update.Message);
                            _lastUpdateId = update.UpdateId;
                        }
                        //await Task.Delay(pollingInterval * 1000);
                    }
                };
                _getUpdatesTask = Task.Run(poll, _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Stops the bot listening for updates
        /// </summary>
        public void Stop()
        {
            try
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
