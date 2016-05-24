using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pji_Spotify.Service.Models
{
    internal class Cfid
    {
        public Error Error { get; set; }
        public string Token { get; set; }
        public string Version { get; set; }
        public string ClientVersion { get; set; }
        public Boolean Running { get; set; }
    }

    internal class Error
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
