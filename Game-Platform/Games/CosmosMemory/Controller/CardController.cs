using Game_Platform.Games.CosmosMemory.Models;
using Game_Platform.Games.CosmosMemory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Game_Platform.Games.CosmosMemory.Controller
{
    public class CardController
    {
        readonly List<Card> Cards;
        private static Card First;
        private static Card Second;

        private static int Acertos = 0;
        private static int Erros = 0;

        private static TextBlock TxtAcertos;
        private static TextBlock TxtErros;

        public CardController(Image[] images, TextBlock[] texts) 
        {
            Cards = new List<Card>();
            List<String> ConstellationsNames = Shuffle(SplitAndDuplicate(Shuffle(Constellations.Names.ToList<String>()), images.Length/2));

            for (int i = 0; i < images.Length; i++) 
                Cards.Add(new Card(i, images[i], ConstellationsNames[i]));

            TxtAcertos = texts[0];
            TxtErros = texts[1];
        }

        private List<String> Shuffle(List<String> items)
        {
            var list = items;
            var rnd = new Random();

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            return query.ToList();
        }

        private List<String> SplitAndDuplicate(List<String> list, int n)
        {
            List<string> Splipted = new List<string>();
            for(int i = 0; i < n; i++)
            {
                Splipted.Add(list[i]);
                Splipted.Add(list[i]);
            }
            return Splipted;
        }

        public static async void Compare(Card card)
        {

            if (First == null)
            {
                First = card;
            }
            else
            {
                Second = card;

                if (First.Constellation == Second.Constellation)
                {
                    First.Active = false;
                    Second.Active = false;
                    First = null;
                    Second = null;
                    Acertos++;
                    TxtAcertos.Text = $"{Acertos}";
                }
                else
                {
                    await Task.Delay(200);
                    First.Flip();
                    Second.Flip();
                    First = null;
                    Second = null;
                    Erros++;
                    TxtErros.Text = $"{Erros}";
                }
            }
        }
    }
}
