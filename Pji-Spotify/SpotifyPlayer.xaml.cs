using Newtonsoft.Json;
using Pji_Spotify.Service;
using Pji_Spotify.Service.Enums;
using Pji_Spotify.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pji_Spotify
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SpotifyLocalAPI _spotify;
        private Track _currentTrack;
        Dispatcher obj = null;

        public MainWindow()
        {
            InitializeComponent();
            _spotify = new SpotifyLocalAPI();
            _spotify.OnPlayStateChange += _spotify_OnPlayStateChange;
            _spotify.OnTrackChange += _spotify_OnTrackChange;
            _spotify.OnTrackTimeChange += _spotify_OnTrackTimeChange;
            _spotify.OnVolumeChange += _spotify_OnVolumeChange;

             Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate ()
            { _spotify.SynchronizingObject = obj; }
            );

            //artistLinkLabel.Content = Process.Start(artistLinkLabel.Tag.ToString());
            //albumLinkLabel.Content =  Process.Start(albumLinkLabel.Tag.ToString());
            //titleLinkLabel.Content = Process.Start(titleLinkLabel.Tag.ToString());
        }
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public void Connect()
        {
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                MessageBox.Show(@"Connexion impossible à spotify!");
                return;
            }
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                MessageBox.Show(@"Connexion impossible à spotify!");
                return;
            }

            bool successful = _spotify.Connect();
            if (successful)
            {
                con.Content = @"Connexion a Spotify reussi";
                UpdateInfos();
                _spotify.ListenForEvents = true;
            }
            else
            {
                // DialogResult res = MessageBox.Show(@"Connexion impossible à spotify. Reessayer?", @"Spotify", MessageBoxButtons.YesNo);
                // if (res == DialogResult.Yes)
                Connect();
            }
        }
        public void UpdateInfos()
        {
            StatusResponse status = _spotify.GetStatus();
            if (status == null)
                return;

            //Basic Spotify Infos
            UpdatePlayingStatus(status.Playing);
            //clientVersionLabel.Text = status.ClientVersion;
            //versionLabel.Text = status.Version.ToString();
            //repeatShuffleLabel.Text = status.Repeat + @" and " + status.Shuffle;

            if (status.Track != null) //Update track infos
                UpdateTrack(status.Track);
        }

        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }
        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            _spotify.Play();
        }
        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            _spotify.Pause();
        }
        private void btn_prev_Click(object sender, RoutedEventArgs e)
        {
            _spotify.Previous();
        }
        private void btn_skip_Click(object sender, RoutedEventArgs e)
        {
            _spotify.Skip();
        }
        private void btn_alea_Click(object sender, RoutedEventArgs e)
        {
            _spotify.Skip();
        }
        private void btn_play_Url(object sender, EventArgs e)
        {
            _spotify.PlayURL(playTextBox.Text, "");
        }
        public async void UpdateTrack(Track track)
        {
            _currentTrack = track;


            timeProgressBar.Maximum = track.Length;

            if (track.IsAd())
                return; //Don't process further, maybe null values

            titleLinkLabel.Content = track.TrackResource.Name;
            titleLinkLabel.Tag = track.TrackResource.Uri;

            artistLinkLabel.Content = track.ArtistResource.Name;
            artistLinkLabel.Tag = track.ArtistResource.Uri;

            albumLinkLabel.Content = track.AlbumResource.Name;
            albumLinkLabel.Tag = track.AlbumResource.Uri;

            SpotifyUri uri = track.TrackResource.ParseUri();

            //trackInfoBox.Text = $"Track Info - {uri.Id}";

           smallAlbumPicture.Content = await track.GetAlbumArtAsync(AlbumArtSize.Size160);
        }

        public void UpdatePlayingStatus(bool playing)
        {
            isPlayingLabel.Content = playing.ToString();
        }

        private void _spotify_OnVolumeChange(object sender, VolumeChangeEventArgs e)
        {
            volumeLabel.Content = (e.NewVolume * 100).ToString(CultureInfo.InvariantCulture);
        }

        private void _spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
        {
            timeLabel.Content = $"{FormatTime(e.TrackTime)}/{FormatTime(_currentTrack.Length)}";
            timeProgressBar.Value = (int)e.TrackTime;
        }

        private void _spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
        {
            UpdateTrack(e.NewTrack);
        }

        private void _spotify_OnPlayStateChange(object sender, PlayStateEventArgs e)
        {
            UpdatePlayingStatus(e.Playing);
        }
        private static String FormatTime(double sec)
        {
            TimeSpan span = TimeSpan.FromSeconds(sec);
            String secs = span.Seconds.ToString(), mins = span.Minutes.ToString();
            if (secs.Length < 2)
                secs = "0" + secs;
            return mins + ":" + secs;
        }
    }
}
