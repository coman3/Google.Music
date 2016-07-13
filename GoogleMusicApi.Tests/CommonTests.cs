using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using GoogleMusicApi.Common;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Requests.Data;
using GoogleMusicApi.Structure;
using GoogleMusicApi.Structure.Enums;
using Rating = GoogleMusicApi.Structure.Enums.Rating;

namespace GoogleMusicApi.Tests
{
    [TestClass]
    public class CommonTests
    {
        private static readonly string _accountPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "account.txt");

        public static Tuple<string, string> GetAccount()
        {
            if (!File.Exists(_accountPath))
            {
                Assert.Fail("account.txt file not found: " + _accountPath);
            }
            var file = File.ReadAllLines(_accountPath);
            return new Tuple<string, string>(file[0], file[1]);
        }
        [TestMethod]
        public void FindFile()
        {
            if (!File.Exists(_accountPath))
            {
                Assert.Fail("account.txt file not found: " + _accountPath);
            }
        }
        
        [TestMethod]
        public async Task Login()
        {
            var account = CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
        }
    }
}