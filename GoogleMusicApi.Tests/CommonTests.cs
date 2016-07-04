using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using GoogleMusicApi.Common;
using GoogleMusicApi.Requests;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Tests
{
    [TestClass]
    public class CommonTests
    {
        private readonly string _accountPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "account.txt");

        [TestMethod]
        public async Task ExploreTabs()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ExploreTabsAsync());
        }

        [TestMethod]
        public void FindFile()
        {
            if (!File.Exists(_accountPath))
            {
                Assert.Fail("account.txt file not found: " + _accountPath);
            }
        }

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
        public async Task GetAlbum()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetAlbumAsync("Bdyocq5dfo3a72heswzl7nhni64")); // Lunch Money - EP, By: SoySauce
        }

        [TestMethod]
        public async Task GetConfig()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetConfigAsync());
        }

        [TestMethod]
        public async Task GetTrack()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetTrackAsync("Tkou6ps7lrj2wz3c2ejrgar337m")); // Essence, By: Skrux
        }

        [TestMethod]
        public async Task ListListenNowSituations()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListListenNowSituationsAsync());
        }

        [TestMethod]
        public async Task ListListenNowTracks()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListListenNowTracksAsync());
        }

        [TestMethod]
        public async Task ListPlaylists()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListPlaylistsAsync());
        }

        [TestMethod]
        public async Task ListPromotedTracksAsync()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListPromotedTracksAsync());
        }

        [TestMethod]
        public async Task ListStationCategories()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ListStationCategoriesAsync());
        }

        [TestMethod]
        public async Task CreateDeletePlaylist()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Playlist item;
            Assert.IsNotNull(item = await mc.CreatePlaylist(Guid.NewGuid().ToString(), ""));
            Assert.IsNotNull(await mc.DetelePlaylist(item));
        }

        [TestMethod]
        public async Task GetStationfeed()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(
                await
                    mc.GetStationFeed(1,
                        new StationFeedStation
                        {
                            LibraryContentOnly = false,
                            NumberOfEntries = 25,
                            RecentlyPlayed = new Track[0],
                            Seed = new StationSeed
                            {
                                SeedType = 6
                            }
                        }
                    ));
        }

        [TestMethod]
        public async Task Login()
        {
            var account = GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
        }
    }
}