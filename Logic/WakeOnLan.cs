using System;
using System.Net.Sockets;

namespace Logic
{
    /// <summary>
    /// Может отправлять "волшебные" пакеты для включения удаленного компьютера
    /// </summary>
    public static class WakeOnLan
    {
        public static void Up(string ip, string mac, int? port = null)
        {
            var client = new UdpClient();
            var data = new byte[102];

            for (var i = 0; i <= 5; i++) // первые шесть байт - нулевые
                data[i] = 0xff;

            var macDigits = GetMacDigits(mac);
            if (macDigits.Length != 6)
                throw new ArgumentException("Incorrect MAC address supplied!");

            const int start = 6;
            for (var i = 0; i < 16; i++) // создаем нужную последовательность байт для пакета
                for (var x = 0; x < 6; x++)
                    data[start + i * 6 + x] = (byte)Convert.ToInt32(macDigits[x], 16);

            client.Send(data, data.Length, ip, port ?? 7); // отправляем пакет
        }

        private static string[] GetMacDigits(string mac) // парсим MAC
        {
            return mac.Split(mac.Contains("-") ? '-' : ':');
        }

        public static bool ValidateMac(string mac) // простая проверка на валидность MAC адреса
        {
            return GetMacDigits(mac).Length == 6;
        }
    }
}