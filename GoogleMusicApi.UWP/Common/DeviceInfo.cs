using System;
using System.Security.Cryptography;
using System.Text;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;

namespace GoogleMusicApi.Common
{
    public sealed class DeviceInfo
    {
        private static DeviceInfo _instance;
        public static DeviceInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DeviceInfo();
                return _instance;
            }

        }

        public string Id { get; private set; }
        public string Model { get; private set; }
        public string Manufracturer { get; private set; }
        public string Name { get; private set; }
        public static string OsName { get; set; }

        private DeviceInfo()
        {
            Id = GetId();
            var deviceInformation = new EasClientDeviceInformation();
            Model = deviceInformation.SystemProductName;
            Manufracturer = deviceInformation.SystemManufacturer;
            Name = deviceInformation.FriendlyName;
            OsName = deviceInformation.OperatingSystem;
        }

        private static string GetId()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.System.Profile.HardwareIdentification"))
            {
                var token = HardwareIdentification.GetPackageSpecificToken(null);
                var hardwareId = token.Id;
                var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);

                byte[] bytes = new byte[hardwareId.Length];
                dataReader.ReadBytes(bytes);

                return BitConverter.ToString(bytes).Replace("-", "");
            }

            throw new Exception("NO API FOR DEVICE ID PRESENT!");
        }
        public static string CalculateMD5Hash(string input)

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