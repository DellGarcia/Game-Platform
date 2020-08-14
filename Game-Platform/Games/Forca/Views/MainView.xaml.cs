using Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode;
using System.Windows;

namespace Game_Platform.Games.Forca.Views
{
    /// <summary>
    /// Lógica interna para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private int Index = 0;

        public MainView()
        {
            InitializeComponent();
            Country.Text = ApiRequest.Countries[Index].Name;
            Index++;
        }

        private void NextCountry(object sender, RoutedEventArgs e)
        {
            Country.Text = ApiRequest.Countries[Index].Name;
            Index++;
        }
    }
}
