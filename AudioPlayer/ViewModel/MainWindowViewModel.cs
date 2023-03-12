using AudioPlayer.View;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace AudioPlayer
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MusicPlayerService _service;
        private DispatcherTimer serializationTimer = new();
        private ObservableCollection<Song> _songs = new ObservableCollection<Song>();
        public event PropertyChangedEventHandler? PropertyChanged;

        public MusicPlayerService Service { get { return _service; } private set { _service = value; } }
        public ObservableCollection<Song> Songs { get { return _songs; } set { _songs = value; NotifyPropertyChanged("Songs"); } }
        public ICommand AddSongCommand { get; set; }
        public ICommand MainCommand { get; set; }
        public ICommand NextSongCommand { get; set; }
        public ICommand PrevSongCommand { get; set; }
        public ICommand ShuffleSongsCommand { get; set; }
        public ICommand MouseDownCommand { get; set; }
        public ICommand MouseUpCommand { get; set; }
        public ICommand SelectSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public MainWindowViewModel()
        {
            AddSongCommand = new RelayCommand(addSong);
            MainCommand = new RelayCommand(pausePlay);
            NextSongCommand = new RelayCommand(nextSong);
            PrevSongCommand = new RelayCommand(previousSong);
            ShuffleSongsCommand = new RelayCommand(shuffleSongs);
            MouseDownCommand = new RelayCommand(mouseDown);
            MouseUpCommand = new RelayCommand(mouseUp);
            SelectSongCommand = new ParameterRelayCommand<Song>(selectSong);
            DeleteSongCommand = new ParameterRelayCommand<Song>(deleteSong);

            List<string>? fajlovi=null;
            try
            {
                fajlovi = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\source\\repos\\AudioPlayer\\AudioPlayer\\bin\\Debug\\net6.0-windows").ToList();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            if (fajlovi!=null && fajlovi.Any(s => s.EndsWith("plejer.json")))
            {
                string content = File.ReadAllText("plejer.json");
                MusicPlayerService? deserializedPlayer = JsonSerializer.Deserialize<MusicPlayerService>(content);
                if (deserializedPlayer != null)
                {   
                    if (deserializedPlayer.IsActive)
                    {
                        deserializedPlayer.IsActive = false;
                    }
                    if (deserializedPlayer.SelectedSong != null)
                    {
                        Song? temp = deserializedPlayer.List.ToList().Find(s => s.IsPlaying == true);
                        if(temp is not null)
                        {
                            deserializedPlayer.SelectedSong = null;
                            deserializedPlayer.Open(temp);
                        }
                    }
                    _service = deserializedPlayer;
                    foreach (Song s in Service.List)
                    {
                        Songs.Add(s);
                    }
                }
            }
            else
            {
                _service = new MusicPlayerService();
            }

            serializationTimer.Interval = TimeSpan.FromSeconds(5);
            serializationTimer.Tick += (e,a)=>serialize();
            serializationTimer.Start();
        }

        private void addSong()
        {
            AddSongWindowViewModel vm = new AddSongWindowViewModel(Songs);
            AddSongWindow win = new AddSongWindow();
            win.DataContext = vm;   
            vm.OnCloseRequest += (a, b) => {
                Song s = new Song(vm.SongPath, vm.SongName, vm.PlayerName);
                Songs.Add(s);
                Service.List.Add(s);
                if(Service.SelectedSong!=null)
                {
                    Service.SetNextPrevAvailability(Service.SelectedSong);
                }
                win.Close(); 
            };
            win.Show();
        }

        private void pausePlay()
        {
            if(Service.IsActive)
            {
                Service.Pause();
            }
            else
            {
                Service.Play();
            }

        }

        private void nextSong()
        {
            Service.PlayNext();
        }

        private void previousSong()
        {
            Service.PlayPrevious();
        }

        private void shuffleSongs()
        {
            Service.ShuffleSongList();
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            foreach(Song s in Service.List)
            {
                songs.Add(s);    
            }
            Songs = songs;
        }
     
        private void serialize()
        {
            var obj = JsonSerializer.Serialize(Service);
            File.WriteAllText("plejer.json", obj);
        }

        private void mouseDown()
        {
            if(Service!=null)
            {
                Service.Pause();
            }
        }

        private void mouseUp()
        {
            if(Service!=null)
            {
                Service.UpdatePosition();
                Service.Resume();
            }
        }

        private void selectSong(Song song)
        {
            Service.Open(song); 
            Service.Play();
        }

        private void deleteSong(Song song)
        {
            Service.DeleteSong(song); 
            Songs.Remove(song);
        }

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
