using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode
{
    public static class ApiRequest
    {

        public static List<RestCountriesResponse> Countries { get; private set; }

        public static async void LoadCountries()
        {
            try
            {
                var api = RestService.For<IRestCountries>("https://restcountries.eu");

                Countries = await api.GetAsyncCountries();
                Shuffle();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao consumir a API: \n${e.Message}");
            }
        }

        public static void Shuffle()
        {
            var list = Countries;
            var rnd = new Random();

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            Countries = query.ToList();
        }
    }
}
