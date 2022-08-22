using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JonasCodingTestNet6.API
{
    public class AppError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
