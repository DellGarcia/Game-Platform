using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi.AlphaCode;
using System.Windows;

namespace Game_Platform.Games.GlobalHangman.Views
{
    public partial class InitView : Window
    {
        public InitView()
        {
            InitializeComponent();
            ApiRequest.LoadCountries();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            new MainView().Show();
            Close();
        }

        private void ShowGameInfo(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }
    }
}
