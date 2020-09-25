using Game_Platform.Games.CosmosMemory.Utils;
using Game_Platform.Games.GlobalHangman.Controllers;
using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi;
using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi.AlphaCode;
using Game_Platform.Games.GlobalHangman.Views;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game_Platform.Games.GlobalHangman.Models
{
    public class Game
    {
        public RestCountriesResponse Country { get; private set; }
        public int Attemps { get; private set; }
        private List<string> TriedCorrectLetters { get; set; }

        private string Word { get; set; }
        public string WordHidden { get; private set; }
        public string WordReal { get; private set; }

        public int Hits { get; private set; }

        public Game()
        {
            Attemps = 6;
            Hits = 0;
            Country = ApiRequest.NextCountry();
            Word = Methods.RemoveAccents(Country.Translations.Br.ToUpper());
            WordReal = Country.Translations.Br.ToUpper();
            WordHidden = "";
            TriedCorrectLetters = new List<string>();
            foreach (char Letter in Word)
                WordHidden += Letter != ' ' ? "_ " : "- ";

            foreach (char letter in Word)
                Hits += letter == ' ' ? 1 : 0;

        }

        public void Attempt(string Letter)
        {
            bool exists = false;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == Letter[0])
                {
                    exists = true;
                    sb.Append($"{WordReal[i]} ");
                    Hits++;
                }
                else
                {
                    sb.Append(TriedCorrectLetters.Contains($"{Word[i]}") ? $"{WordReal[i]} " :
                    Word[i] == ' ' ? "- " : "_ ");
                }
            }

            WordHidden = sb.ToString().Trim();

            if (!exists)
                Attemps--;

            if (Hits == Word.Length)
            {
                GameController.ShowFinalResult();
                new CountryInfoWindow(Country, "Parabéns você descobriu o nome do país!").ShowDialog();
            }

            if (Attemps == 0)
            {
                GameController.ShowFinalResult();
                new CountryInfoWindow(Country, "Infelizmente suas tentativas acabaram...").ShowDialog();
            }
            else
                TriedCorrectLetters.Add(Letter);
      
        }

    }
}
