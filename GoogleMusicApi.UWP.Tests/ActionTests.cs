using System;
using System.Diagnostics;
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
        public async Task AdRemoveSongsFromPlaylist()
        {
            var account = CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Playlist item;
            Assert.IsNotNull(item = await mc.CreatePlaylist(Guid.NewGuid().ToString(), ""));
            
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
            Assert.IsNotNull(await mc.AddSongToPlaylist(item, track));

            var result = await mc.ListTracksFromPlaylist(item);
            Assert.IsTrue(result.Any(x=> x.StoreId == track.StoreId));

            Assert.IsNotNull(await mc.RemoveSongsFromPlaylist(mc.GetTrackPlaylistEntry(item, track)));

            Assert.IsNotNull(await mc.DetelePlaylist(item));

        }
        [TestMethod]
        public async Task IsPlaylistPublic()
        {
            var account = CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Playlist item;
            Assert.IsNotNull(item = await mc.CreatePlaylist(Guid.NewGuid().ToString(), "", ShareState.Public));
            Assert.IsTrue(await mc.IsPlaylistSharedAsync(item));
            Assert.IsNotNull(await mc.DetelePlaylist(item));
        }

        [TestMethod]
        public async Task ChangePlaylistShareState()
        {
            var account = CommonTests.GetAccount();
            var mc = new MobileClient();
            Assert.IsTrue(await mc.LoginAsync(account.Item1, account.Item2));
            Playlist item;
            Assert.IsNotNull(item = await mc.CreatePlaylist(Guid.NewGuid().ToString(), "", ShareState.Public));
            Assert.IsTrue(await mc.IsPlaylistSharedAsync(item));
            item.ShareState = ShareState.Private;
            Assert.IsNotNull(item = await mc.UpdatePlaylistAsync(item));
            Debug.WriteLine(item);
            Assert.IsFalse(await mc.IsPlaylistSharedAsync(item));
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