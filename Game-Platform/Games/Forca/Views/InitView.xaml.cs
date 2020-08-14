using Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode;
using Refit;
using System;
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
            GetCode();
        }

        public static async void GetCode()
        {
            try
            {
                var response = RestService.For<IAlphaCode>("https://restcountries.eu");

                MessageBox.Show("Consultando API");
                var codes = await response.GetAsyncAlphaCode();

                MessageBox.Show(codes[0].Alpha2Code);

            }
            catch (Exception e)
            {
                MessageBox.Show("Erro " + e.Message);
            }
        }
    }
}
