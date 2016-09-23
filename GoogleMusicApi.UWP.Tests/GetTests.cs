using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Common;
using GoogleMusicApi.UWP.Structure;
using GoogleMusicApi.UWP.Structure.Enums;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GoogleMusicApi.UWP.Tests
{
    [TestClass]
    public class GetTests
    {

        [TestMethod]
        public async Task ExploreTabs()
        {
            var account =CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Assert.IsNotNull(await mc.ExploreTabsAsync());
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