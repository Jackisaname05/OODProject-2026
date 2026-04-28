using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OODProject_2026.ApiModels;

namespace OODProject_2026
{
    public partial class RunDetailsWindow : Window
    {
        public RunDetailsWindow(ComicVineRunDetails details)
        {
            InitializeComponent();

            DataContext = details;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
