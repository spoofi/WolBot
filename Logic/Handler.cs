using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Logic
{
    public class Handler
    {
        private readonly Api _bot;

        public Handler()
        {
            _bot = Bot.Get();
        }

        /// <summary>
        /// Обрабатывает сообщение от пользователя
        /// </summary>
        public async void Handle(Message message)
        {
            var text = message.Text.Split(' ');
            if (text.First() != "/wol") return;
            switch (text.Count())
            {
                case 1:
                case 2:
                    await _bot.SendTextMessage(message.Chat.Id, "Пример использования: /wol 1.2.3.4 01:02:03:04:05:06 7");
                    break;
                default:
                    if (!WakeOnLan.ValidateMac(text[2]))
                        await _bot.SendTextMessage(message.Chat.Id, "Неверный MAC адрес");
                    else
                    {
                        try
                        {
                            WakeOnLan.Up(text[1], text[2], GetPort(text));
                            await _bot.SendTextMessage(message.Chat.Id, "Пакет отправлен!");
                        }
                        catch (Exception)
                        {
                            await _bot.SendTextMessage(message.Chat.Id, "Произошла ошибка :(");
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Получаем порт из параметров
        /// </summary>
        private static int? GetPort(IReadOnlyList<string> text)
        {
            int port;
            if (text.Count == 4 && int.TryParse(text[3], out port))
                return port;
            return null;
        }
    }
}