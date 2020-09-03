using Game_Platform.Games.CosmosMemory.Utils;
using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi;
using Game_Platform.Games.GlobalHangman.Services.RestCountriesApi.AlphaCode;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Game_Platform.Games.GlobalHangman.Models
{
    public class Game
    {
        private RestCountriesResponse Country;
        public int Attemps { get; private set; }
        private List<string> TriedCorrectLetters { get; set; }

        private string Word { get; set; }
        public string WordHidden { get; private set; }

        public Game()
        {
            Attemps = 6;
            Country = ApiRequest.NextCountry();
            Word = Methods.RemoveAccents(Country.Translations.Br.ToUpper());;
            WordHidden = "";
            TriedCorrectLetters = new List<string>();
            foreach (char Letter in Word)
                WordHidden += Letter != ' ' ? "_ " : "- ";

            MessageBox.Show(Word);
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
                    sb.Append($"{Letter} ");
                }
                else
                {
                    sb.Append(TriedCorrectLetters.Contains($"{Word[i]}") ? $"{Word[i]} " :
                    Word[i] == ' ' ? "- " : "_ ");
                }
            }

            WordHidden = sb.ToString().Trim();

            if (!exists)
                Attemps--;
            if (Attemps == 0)
            {
                MessageBox.Show("Fim de Jogo, Voce perdeu");
            }
            else
                TriedCorrectLetters.Add(Letter);
        }

        
    }
}
