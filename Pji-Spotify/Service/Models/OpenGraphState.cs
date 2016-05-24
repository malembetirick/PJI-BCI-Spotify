using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pji_Spotify.Service.Models
{
    public class OpenGraphState
    {
        [JsonProperty("private_session")]
        public Boolean PrivateSession { get; set; }

        [JsonProperty("posting_disabled")]
        public Boolean PostingDisabled { get; set; }
    }
}
