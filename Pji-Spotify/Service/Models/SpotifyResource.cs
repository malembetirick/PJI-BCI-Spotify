using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pji_Spotify.Service.Models
{
    public class SpotifyResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("location")]
        public TrackResourceLocation Location { get; set; }

        public SpotifyUri ParseUri()
        {
            return SpotifyUri.Parse(Uri);
        }
    }
}
