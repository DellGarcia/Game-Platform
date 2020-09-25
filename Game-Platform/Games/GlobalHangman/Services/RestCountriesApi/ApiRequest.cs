using Refit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Platform.Games.GlobalHangman.Services.RestCountriesApi.AlphaCode
{
    public static class ApiRequest
    {
        public static int Index { get; private set; }
        private static List<RestCountriesResponse> Countries;

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

        public static RestCountriesResponse NextCountry()
        {
            return Countries[Index++];
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
