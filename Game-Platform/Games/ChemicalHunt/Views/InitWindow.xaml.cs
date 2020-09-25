using System.Windows;

namespace Game_Platform.Games.ChemicalHunt.Views
{
    public partial class InitWindow : Window
    {
        public InitWindow()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            MainWindow.create().Show();
            Close();
        }
    }
}
