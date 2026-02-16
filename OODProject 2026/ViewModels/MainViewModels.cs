using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OODProject_2026.ApiModels;
using OODProject_2026.Models;
using OODProject_2026.Services;




namespace OODProject_2026.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICharacterRepository _repo = new CharacterRepository();
        private readonly ComicVineService _comicVine = new ComicVineService();

        public ObservableCollection<CharacterEntity> Characters { get; } = new ObservableCollection<CharacterEntity>();
        public ObservableCollection<ComicVineVolume> Runs { get; } = new ObservableCollection<ComicVineVolume>();
        public ObservableCollection<ComicVineIssue> Appearances { get; } = new ObservableCollection<ComicVineIssue>();

        private CharacterEntity _selectedCharacter;
        public CharacterEntity SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged();
                LoadComicDataForSelectedCharacterAsync();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged(); }
        }

        private string _publisherFilter = "All";
        public string PublisherFilter
        {
            get { return _publisherFilter; }
            set { _publisherFilter = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            RefreshCharacters();
        }

        public void RefreshCharacters()
        {
            Characters.Clear();
            foreach (var c in _repo.GetAllCharacters())
                Characters.Add(c);
        }

        public void SearchCharacters()
        {
            Characters.Clear();
            foreach (var c in _repo.Search(SearchText, PublisherFilter))
                Characters.Add(c);
        }

        private async void LoadComicDataForSelectedCharacterAsync()
        {
            if (SelectedCharacter == null)
            {
                Runs.Clear();
                Appearances.Clear();
                return;
            }

            try
            {
                var runsTask = _comicVine.SearchRunsAsync(SelectedCharacter.Name);
                var appTask = _comicVine.GetAppearancesAsync(SelectedCharacter.ComicVineCharacterId);

                var runs = await runsTask;
                var apps = await appTask;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Runs.Clear();
                    foreach (var r in runs) Runs.Add(r);

                    Appearances.Clear();
                    foreach (var a in apps) Appearances.Add(a);
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "ComicVine Error");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
