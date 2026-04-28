using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OODProject_2026.ApiModels;
using OODProject_2026.Services;
using OODProject_2026.ViewModels;

namespace OODProject_2026
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;
        private readonly ComicVineService _comicVineService = new ComicVineService();

        public MainWindow()
        {
            InitializeComponent();

            _vm = new MainViewModel();
            DataContext = _vm;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (_vm == null)
                return;

            _vm.SearchCharacters();
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            if (_vm == null)
                return;

            _vm.ClearFilters();
        }

        private async void RunsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as ListBox;

            if (listBox == null)
                return;

            var selectedRun = listBox.SelectedItem as ComicVineVolume;

            if (selectedRun == null)
                return;

            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                var details = await _comicVineService.GetRunDetailsAsync(selectedRun.Id);

                if (details == null)
                {
                    MessageBox.Show(
                        "Could not load details for this run.",
                        "Run Details",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    return;
                }

                var window = new RunDetailsWindow(details);
                window.Owner = this;
                window.ShowDialog();
            }
            catch
            {
                MessageBox.Show(
                    "Something went wrong while loading the run details.",
                    "Run Details Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}