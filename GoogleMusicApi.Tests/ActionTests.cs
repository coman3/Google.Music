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
    public class ActionTests
    {
        private readonly string _accountPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "account.txt");

       
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
        public async Task LikeDislikeTrack()
        {
            var account = GetAccount();
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