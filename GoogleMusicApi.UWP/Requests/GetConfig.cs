using System.Threading.Tasks;
using GoogleMusicApi.Structure;

namespace GoogleMusicApi.Requests
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