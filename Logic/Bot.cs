using Telegram.Bot;

namespace Logic
{
    public static class Bot
    {
        private static Api _bot;

        /// <summary>
        /// Получаем бота, а если он еще
        /// не инициализирован - инициализируем
        /// и возвращаем
        /// </summary>
        public static Api Get()
        {
            if (_bot != null) return _bot;
            _bot = new Api(Config.BotApiKey);
            _bot.SetWebhook(Config.WebHookUrl);
            return _bot;
        }
    }
}