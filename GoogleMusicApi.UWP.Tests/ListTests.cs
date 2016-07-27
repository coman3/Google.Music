using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Common;
using GoogleMusicApi.UWP.Structure;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GoogleMusicApi.UWP.Tests
{
    [TestClass]
    public class ListTests
    {
        private readonly string _accountPath = Path.Combine("Directory", "account.txt");

        public Tuple<string, string> GetAccount()
        {
            if (!File.Exists(_accountPath))
            {
                Assert.Fail("account.txt file not found: " + _accountPath);
            }
            var file = File.ReadAllLines(_accountPath);
            return new Tuple<string, string>(file[0], file[1]);
        }

        [TestMethod]
        public async Task ListListenNowSituations()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListListenNowSituationsAsync());
        }

        [TestMethod]
        public async Task ListListenNowTracks()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListListenNowTracksAsync());
        }
        [TestMethod]
        public async Task ListPlaylistItems()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            ResultList<Playlist> playlist;
            Assert.IsNotNull(playlist = await mc.ListPlaylistsAsync());
            Assert.IsNotNull(await mc.ListTracksFromPlaylist(playlist.Data.Items.First()));

        }

        [TestMethod]
        public async Task ListPlaylists()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListPlaylistsAsync());
        }

        [TestMethod]
        public async Task ListPromotedTracksAsync()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListPromotedTracksAsync());
        }

        [TestMethod]
        public async Task ListStationCategories()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListStationCategoriesAsync());
        }


    }
}