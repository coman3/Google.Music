using System.Threading.Tasks;
using GoogleMusicApi.UWP.Structure;

namespace GoogleMusicApi.UWP.Requests
{
    public class GetConfig : StructuredRequest<GetRequest, Config>
    {
        public override string RelativeRequestUrl => "config";

        public override Task<Config> GetAsync(GetRequest data)
        {
            data.UrlData.Add(new WebRequestHeader("dv", 0.ToString()));
            return base.GetAsync(data);
        }
    }
}