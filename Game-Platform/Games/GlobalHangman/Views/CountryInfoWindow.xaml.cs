using Game_Platform.Games.GlobalHangman.Controllers;
using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi;
using System.Windows;

namespace Game_Platform.Games.GlobalHangman.Views
{
    /// <summary>
    /// Lógica interna para CountryInfoWindow.xaml
    /// </summary>
    public partial class CountryInfoWindow : Window
    {
        public CountryInfoWindow(RestCountriesResponse Country, string message)
        {
            InitializeComponent();
            CountryName.Text = Country.Translations.Br;
            CountryCapital.Text = Country.Capital;
            CountryRegion.Text = Country.Region;
            CountrySubregion.Text = Country.Subregion;
            CountryPopulation.Text = $"{Country.Population}";
            GameMessage.Text = message;

            string languages = "";
            for(int i = 0; i < Country.Languages.Count; i++)
                languages += (i != Country.Languages.Count - 1) ? $"{Country.Languages[i].Name}, " : Country.Languages[i].Name;
            
            CountryLanguages.Text = languages;

            string currencyString = "";
            for(int i = 0; i < Country.Currencies.Count; i++)
            {
                Currency currency = Country.Currencies[i];
                if (i != Country.Currencies.Count -1)
                {
                    currencyString += $"{currency.Name} ({currency.Code}), ";
                } else
                {
                    currencyString += $"{currency.Name} ({currency.Code})";
                }
            }

            CountryCurrency.Text = currencyString;
        }

        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            GameController.Reset();
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            GameController.CloseGame();
            Close();
        }
    }
}
