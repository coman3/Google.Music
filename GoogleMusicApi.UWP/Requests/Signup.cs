using GoogleMusicApi.UWP.Sessions;
using GoogleMusicApi.UWP.Structure;
using Newtonsoft.Json;

namespace GoogleMusicApi.UWP.Requests
{
    public class Signup : StructuredRequest<SignupRequest, SignupResponse>
    {
        public override string RelativeRequestUrl => "signup/offers";
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class SignupRequest : PostRequest
    {
        private const int GmsCoreVersionCodeConst = 9256440;
        private const int PhoneSkyVersionCodeConst = 80682400;

        [JsonProperty("gmsCoreVersionCode")]
        public int GmsCoreVersionCode { get; set; }
        [JsonProperty("phoneskyVersionCode")]
        public int PhoneSkyVersionCode { get; set; }

        public SignupRequest(Session session) : base(session)
        {
            GmsCoreVersionCode = GmsCoreVersionCodeConst;
            PhoneSkyVersionCode = PhoneSkyVersionCodeConst;
        }
    }

    public class SignupResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("lockerAvail")]
        public bool LockerAvail { get; set; }

        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; } //TODO (Low): Enum Account Status

        [JsonProperty("entitlementStatus")]
        public EntitlementStatus EntitlementStatus { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("gift")]
        public Gift Gift { get; set; }

    }

    public class Gift
    {
        [JsonProperty("backendDocid")]
        public string BackendDocId { get; set; }

        [JsonProperty("messages")]
        public GiftMessages Messages { get; set; }

        [JsonProperty("offerDetail")]
        public GiftOfferDetail[] OfferDetail { get; set; }

        
    }

    public class GiftOfferDetail
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("imageRef")]
        public ArtReference[] ImageRef { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

    }

    public class GiftMessages
    {
        [JsonProperty("landingPageTitle")]
        public string LandingPageTitle { get; set; }

        [JsonProperty("landingPageContent")]
        public string LandingPageContent { get; set; }

        [JsonProperty("unavailableTitle")]
        public string UnavailableTitle { get; set; }

        [JsonProperty("unavailableMessage")]
        public string UnavailableMessage { get; set; }

        [JsonProperty("unknownTitle")]
        public string UnknownTitle { get; set; }

        [JsonProperty("unknownMessage")]
        public string UnknownMessage { get; set; }

    }

    public class EntitlementStatus
    {
        [JsonProperty("wsAccess")]
        public string WsAccess { get; set; }

        [JsonProperty("purchaseAccess")]
        public string PurchaseAccess { get; set; }

        [JsonProperty("uploadAccess")]
        public string UploadAccess { get; set; }

        [JsonProperty("nautilusAccess")]
        public string NautilusAccess { get; set; }

        [JsonProperty("partridgeAccess")]
        public string PartridgeAccess { get; set; }

        [JsonProperty("partridgeManagement")]
        public string PartridgeManagement { get; set; }

    }
}