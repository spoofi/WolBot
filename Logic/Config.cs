using System.Collections.Specialized;
using System.Configuration;

namespace Logic
{
    public static class Config
    {
        /// <summary>
        /// Настройки для бота храним в настройках приложения
        /// </summary>
        private static readonly NameValueCollection Appsettings = ConfigurationManager.AppSettings;

        /// <summary>
        /// Полученный токен для бота
        /// </summary>
        public static string BotApiKey
        {
            get { return Appsettings["BotApiKey"]; }
        }

        /// <summary>
        /// URL, на который должны приходить все обновления от бота
        /// </summary>
        public static string WebHookUrl
        {
            get { return Appsettings["WebHookUrl"]; }
        }
    }
}
