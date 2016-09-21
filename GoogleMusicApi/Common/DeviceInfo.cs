using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace GoogleMusicApi.Common
{
    public sealed class DeviceInfo
    {
        private static DeviceInfo _instance;
        public static DeviceInfo Instance => _instance ?? (_instance = new DeviceInfo());

        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Manufracturer { get; private set; }
        public string Name { get; private set; }
        public static string OsName { get; set; }

        private DeviceInfo()
        {
            Id = GetId();
            Model = "Unknown";
            Manufracturer = "Unknown";
            Name = "Unknown";
            OsName = "Unknown";
        }

        private static string GetId()
        {
            var device =
                NetworkInterface
                    .GetAllNetworkInterfaces()
                    .FirstOrDefault(x => x.OperationalStatus == OperationalStatus.Up)?.GetPhysicalAddress()
                    .ToString();

            if (device != null)
                return device;

            throw new Exception("NO API FOR DEVICE ID PRESENT!");
        }
        public static string CalculateMd5Hash(string input)

        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

    }
}