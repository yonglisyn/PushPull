using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PushPull.Constants
{
    public class AccountConstSettings
    {
        public const  int PasswordExpiredMonth = 3;
        public const int ContentLength = 200;
        public const int UsernameLength = 50;
        public const int CommonStringLength = 50;
        public const int PasswordHashLength = 200;
        public const int OneWeekCount = 7;

        public static readonly JsonSerializerSettings SerializerSetting = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}