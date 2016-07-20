using System;
using System.IO;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Common;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GoogleMusicApi.UWP.Tests
{
    [TestClass]
    public class CommonTests
    {

        public static Tuple<string, string> GetAccount()
        {
            //if (!File.Exists(_accountPath))
            //{
            //    Assert.Fail("account.txt file not found: " + _accountPath);
            //}
            //var file = File.ReadAllLines(_accountPath);
            return new Tuple<string, string>("dev.lvelden", "qwertasd123");
        }
        [TestMethod]
        public void FindFile()
        {
            //if (!File.Exists(_accountPath))
            //{
            //    Assert.Fail("account.txt file not found: " + _accountPath);
            //}
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