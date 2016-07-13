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
    public class GetTests
    {
        private readonly string _accountPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "account.txt");

        [TestMethod]
        public async Task ExploreTabs()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ExploreTabsAsync());
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
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetAlbumAsync("Bdyocq5dfo3a72heswzl7nhni64")); // Lunch Money - EP, By: SoySauce
        }

        [TestMethod]
        public async Task GetConfig()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetConfigAsync());
        }

        [TestMethod]
        public async Task GetTrack()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.GetTrackAsync("Tkou6ps7lrj2wz3c2ejrgar337m")); // Essence, By: Skrux
        }

        [TestMethod]
        public async Task GetStationfeed()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(
                await
                    mc.GetStationFeed(ExplicitType.Explicit,
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
        public async Task GetStreamUrl()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            RadioFeed tracks;
            Assert.IsNotNull(tracks = await
                    mc.GetStationFeed(ExplicitType.Explicit,
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
            var track = tracks.Data.Stations.First().Tracks.First();
            Assert.IsNotNull(await mc.GetStreamUrlAsync(track));
        }
        
    }
}