using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Song : INotifyPropertyChanged
    {
        private bool _isPlaying = false;
        public string SongPath { get; set; }
        public string SongName { get; set; }
        public string PlayerName { get; set; }
        public bool IsPlaying { get { return _isPlaying; } set { _isPlaying = value; NotifyPropertyChanged("IsPlaying"); } }
        public string SongTitle { get; set; }

        public Song(string songPath, string songName, string playerName)
        {
            SongPath = songPath;
            SongName = songName;
            PlayerName = playerName;
            SongTitle = playerName + " - " + songName;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
