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

namespace Game_Platform.Games.CosmosMemory.Views
{
    /// <summary>
    /// Lógica interna para CosmosMemoryMainView.xaml
    /// </summary>
    public partial class InitView : Window
    {
        public InitView()
        {
            InitializeComponent();
        }

        private void OpenEasyGame(object sender, RoutedEventArgs e)
        {
            new EasyGameView().Show();
            this.Close();
        }

        private void OpenHardGame(object sender, RoutedEventArgs e)
        {
            new HardGameView().Show();
            this.Close();
        }

        private void OpenAboutPage(object sender, RoutedEventArgs e)
        {
            new AboutPage().ShowDialog();
        }
    }
}
