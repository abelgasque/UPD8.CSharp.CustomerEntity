using Newtonsoft.Json;

namespace UPD8.CSharp.Infrastructure.Entities.Settings
{
    public class AppSettings
    {
        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("Server")]
        public string Server { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

        [JsonProperty("PasswordDb")]
        public string PasswordDb { get; set; }

        public string GetConnectionString
        {
            get
            {
                return string.Format(ConnectionString, Server, Name, UserId, PasswordDb);
            }
        }
    }
}
