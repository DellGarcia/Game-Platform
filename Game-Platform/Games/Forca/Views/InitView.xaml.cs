using Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode;
using System.Windows;

namespace Game_Platform.Games.Forca.Views
{
    /// <summary>
    /// Lógica interna para MainView.xaml
    /// </summary>
    public partial class InitView : Window
    {
        public InitView()
        {
            InitializeComponent();
            ApiRequest.LoadCountries();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            AwaitView.Create().Show();
            Close();
        }
    }
}
