using System;
using System.Linq;
using System.Threading.Tasks;
using GoogleMusicApi.UWP.Common;
using GoogleMusicApi.UWP.Requests.Data;
using GoogleMusicApi.UWP.Structure;
using GoogleMusicApi.UWP.Structure.Enums;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Rating = GoogleMusicApi.UWP.Structure.Enums.Rating;

namespace GoogleMusicApi.UWP.Tests
{
    [TestClass]
    public class ActionTests
    {
       [TestMethod]
        public async Task CreateDeletePlaylist()
        {
            var account = CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Playlist item;
            Assert.IsNotNull(item = await mc.CreatePlaylist(Guid.NewGuid().ToString(), ""));
            Assert.IsNotNull(await mc.DetelePlaylist(item));
        }

       [TestMethod]
        public async Task LikeDislikeTrack()
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
            RecordRealTimeResponse data;
            Assert.IsNotNull(data = await mc.SetTrackRating(Rating.FiveStars, track));
            Assert.IsTrue(data.EventResults.All(x=> x.Code != ResponseCode.Invalid));
            Assert.IsNotNull(data = await mc.SetTrackRating(Rating.OneStar, track));
            Assert.IsTrue(data.EventResults.All(x => x.Code != ResponseCode.Invalid));
            Assert.IsNotNull(data = await mc.SetTrackRating(Rating.NoRating, track));
            Assert.IsTrue(data.EventResults.All(x => x.Code != ResponseCode.Invalid));
        }

    }
}