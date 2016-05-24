﻿using Pji_Spotify.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pji_Spotify.Service
{
    public class TrackChangeEventArgs
    {
        public Track OldTrack { get; set; }
        public Track NewTrack { get; set; }
    }

    /// <summary>
    /// Event gets triggered, when the Playin-state is changed (e.g Play --> Pause)
    /// </summary>
    public class PlayStateEventArgs
    {
        public Boolean Playing { get; set; }
    }

    /// <summary>
    /// Event gets triggered, when the volume changes
    /// </summary>
    public class VolumeChangeEventArgs
    {
        public double OldVolume { get; set; }
        public double NewVolume { get; set; }
    }

    /// <summary>
    /// Event gets triggered, when the tracktime changes
    /// </summary>
    public class TrackTimeChangeEventArgs
    {
        public double TrackTime { get; set; }
    }
}
