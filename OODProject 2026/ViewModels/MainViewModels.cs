using OODProject_2026.ApiModels;
using OODProject_2026.Models;
using OODProject_2026.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace OODProject_2026.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICharacterRepository _repo = new CharacterRepository();
        private readonly ComicVineService _comicVine = new ComicVineService();

        public ObservableCollection<CharacterEntity> Characters { get; } = new ObservableCollection<CharacterEntity>();
        public ObservableCollection<ComicVineVolume> Runs { get; } = new ObservableCollection<ComicVineVolume>();
        private int _loadVersion = 0;

        public ObservableCollection<string> RunSortOptions { get; } = new ObservableCollection<string>
{
    "Best Match",
    "Year (Newest First)",
    "Year (Oldest First)",
    "Issue Count (High to Low)",
    "Issue Count (Low to High)"
};

        private List<ComicVineVolume> _latestRuns = new List<ComicVineVolume>();

        private string _selectedRunSortOption = "Best Match";
        public string SelectedRunSortOption
        {
            get { return _selectedRunSortOption; }
            set
            {
                _selectedRunSortOption = value;
                OnPropertyChanged();
                ApplyRunSort();
            }
        }
        public ObservableCollection<string> Publishers { get; } = new ObservableCollection<string>
        {
            "All",
            "Marvel Comics",
            "DC Comics",
            "Image Comics",
            "Dark Horse Comics"
        };

        private CharacterEntity _selectedCharacter;
        public CharacterEntity SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                if (_selectedCharacter == value)
                    return;

                _selectedCharacter = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSelectedCharacter));
                OnPropertyChanged(nameof(ShowNoCharacterState));
                OnPropertyChanged(nameof(ShowRunsEmptyState));
                OnPropertyChanged(nameof(ShowRunList));
                OnPropertyChanged(nameof(RunsLoadedText));

                LoadComicDataForSelectedCharacterAsync();
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private string _publisherFilter = "All";
        public string PublisherFilter
        {
            get { return _publisherFilter; }
            set
            {
                _publisherFilter = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoadingRuns;
        public bool IsLoadingRuns
        {
            get { return _isLoadingRuns; }
            set
            {
                _isLoadingRuns = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowRunsEmptyState));
                OnPropertyChanged(nameof(ShowRunList));
                OnPropertyChanged(nameof(RunsLoadedText));
            }
        }

        public bool HasSelectedCharacter
        {
            get { return SelectedCharacter != null; }
        }

        public bool ShowNoCharacterState
        {
            get { return SelectedCharacter == null; }
        }

        public bool ShowRunsEmptyState
        {
            get
            {
                return !IsLoadingRuns &&
                       SelectedCharacter != null &&
                       Runs.Count == 0 &&
                       !HasInlineError;
            }
        }

        public bool ShowRunList
        {
            get
            {
                return !IsLoadingRuns &&
                       SelectedCharacter != null &&
                       Runs.Count > 0;
            }
        }

        public string RunsLoadedText
        {
            get
            {
                if (SelectedCharacter == null)
                    return "Select a character to load runs";

                if (IsLoadingRuns)
                    return "Loading...";

                return Runs.Count == 1 ? "1 run loaded" : Runs.Count + " runs loaded";
            }
        }
        private string _inlineErrorMessage;
        public string InlineErrorMessage
        {
            get { return _inlineErrorMessage; }
            set
            {
                _inlineErrorMessage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasInlineError));
            }
        }

        public bool HasInlineError
        {
            get { return !string.IsNullOrWhiteSpace(InlineErrorMessage); }
        }

        public MainViewModel()
        {
            RefreshCharacters();
        }

        public void RefreshCharacters()
        {
            Characters.Clear();

            foreach (var character in _repo.GetAllCharacters())
            {
                Characters.Add(character);
            }

            if (Characters.Count > 0 && (SelectedCharacter == null || !Characters.Contains(SelectedCharacter)))
            {
                SelectedCharacter = Characters.FirstOrDefault();
            }
            else
            {
                OnPropertyChanged(nameof(ShowRunsEmptyState));
            }
        }
        public void ClearFilters()
        {
            SearchText = string.Empty;
            PublisherFilter = "All";
            SearchCharacters();
        }

        public void SearchCharacters()
        {
            try
            {
                InlineErrorMessage = null;

                var text = (SearchText ?? string.Empty).Trim();
                var results = _repo.Search(text, PublisherFilter);

                Characters.Clear();

                foreach (var character in results)
                {
                    Characters.Add(character);
                }

                if (Characters.Count > 0)
                {
                    if (SelectedCharacter == null || !Characters.Any(c => c.Id == SelectedCharacter.Id))
                    {
                        SelectedCharacter = Characters.FirstOrDefault();
                    }
                }
                else
                {
                    SelectedCharacter = null;
                    _latestRuns.Clear();
                    Runs.Clear();

                    InlineErrorMessage = "No characters matched your search/filter. Try clearing the filters.";

                    OnPropertyChanged(nameof(ShowRunsEmptyState));
                    OnPropertyChanged(nameof(ShowRunList));
                    OnPropertyChanged(nameof(RunsLoadedText));
                }
            }
            catch (Exception ex)
            {
                InlineErrorMessage = "There was a problem searching the characters. " + ex.Message;
            }
        }
        private async void LoadComicDataForSelectedCharacterAsync()
        {
            var loadVersion = ++_loadVersion;

            if (SelectedCharacter == null)
            {
                _latestRuns.Clear();
                Runs.Clear();
                IsLoadingRuns = false;

                OnPropertyChanged(nameof(ShowNoCharacterState));
                OnPropertyChanged(nameof(ShowRunsEmptyState));
                OnPropertyChanged(nameof(ShowRunList));
                OnPropertyChanged(nameof(RunsLoadedText));

                return;
            }

            try
            {
                InlineErrorMessage = null;
                IsLoadingRuns = true;

                _latestRuns.Clear();
                Runs.Clear();

                OnPropertyChanged(nameof(ShowRunsEmptyState));
                OnPropertyChanged(nameof(ShowRunList));
                OnPropertyChanged(nameof(RunsLoadedText));

                var selectedCharacterAtStart = SelectedCharacter;

                var searchName = string.IsNullOrWhiteSpace(selectedCharacterAtStart.ComicVineSearchName)
                    ? selectedCharacterAtStart.Name
                    : selectedCharacterAtStart.ComicVineSearchName;

                var runs = await _comicVine.SearchRunsAsync(searchName);

                if (loadVersion != _loadVersion)
                    return;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    _latestRuns = runs ?? new List<ComicVineVolume>();
                    ApplyRunSort();

                    IsLoadingRuns = false;

                    OnPropertyChanged(nameof(ShowRunsEmptyState));
                    OnPropertyChanged(nameof(ShowRunList));
                    OnPropertyChanged(nameof(RunsLoadedText));
                });
            }
            catch (Exception ex)
            {
                if (loadVersion != _loadVersion)
                    return;

                IsLoadingRuns = false;

                InlineErrorMessage =
                    "ComicVine data could not be loaded. You can still browse the local character details. " + ex.Message;

                OnPropertyChanged(nameof(ShowRunsEmptyState));
                OnPropertyChanged(nameof(ShowRunList));
                OnPropertyChanged(nameof(RunsLoadedText));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private void ApplyRunSort()
        {
            if (_latestRuns == null)
                return;

            IEnumerable<ComicVineVolume> sorted = _latestRuns;

            switch (SelectedRunSortOption)
            {
                case "Year (Newest First)":
                    sorted = _latestRuns
                        .OrderByDescending(r => ParseYear(r.Start_Year))
                        .ThenBy(r => r.Name);
                    break;

                case "Year (Oldest First)":
                    sorted = _latestRuns
                        .OrderBy(r => ParseYear(r.Start_Year) == 0 ? int.MaxValue : ParseYear(r.Start_Year))
                        .ThenBy(r => r.Name);
                    break;

                case "Issue Count (High to Low)":
                    sorted = _latestRuns
                        .OrderByDescending(r => r.Count_Of_Issues)
                        .ThenBy(r => r.Name);
                    break;

                case "Issue Count (Low to High)":
                    sorted = _latestRuns
                        .OrderBy(r => r.Count_Of_Issues)
                        .ThenBy(r => r.Name);
                    break;
            }

            Runs.Clear();

            foreach (var run in sorted)
            {
                Runs.Add(run);
            }

            OnPropertyChanged(nameof(ShowRunsEmptyState));
            OnPropertyChanged(nameof(ShowRunList));
            OnPropertyChanged(nameof(RunsLoadedText));
        }

        private int ParseYear(string year)
        {
            int parsed;
            return int.TryParse(year, out parsed) ? parsed : 0;
        }
    }
}