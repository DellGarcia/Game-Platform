using Game_Platform.Games.ChemicalHunt.ChemicalElementsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Game_Platform.Games.ChemicalHunt.Models
{
    public class Game
    {
        public static List<HiddenWord> Words { get; private set; }

        public Game()
        {
            var array = Shuffle(ChemicalElements.Elements);
            Words = new List<HiddenWord>();
            int i = 0;
            foreach (ChemicalElement Element in array)
            {
                HiddenWord word = new HiddenWord(Element);
                Words.Add(word);
                HideWord(word);
                i++;
                if (i == 10)
                    break;
            }
        }

        private void HideWord(HiddenWord word)
        {

            do
            {
                SortPosition(word);
            } while (VerifyColision(word));

        }


        private void SortPosition(HiddenWord word)
        {
            Random random = new Random();

            word.Orientation = random.Next(2) == 0 ? Orientation.HORIZONTAL : Orientation.VERTICAL;

            word.Reversed = random.Next(3) == 0; 

            if (word.Orientation == Orientation.HORIZONTAL)
            {
                word.X = random.Next(20 - word.Name.Length);
                word.Y = random.Next(20);
                word.FinalX = word.X + word.Name.Length;
                word.FinalY = word.Y;
            }
            else
            {
                word.X = random.Next(20);
                word.Y = random.Next(20 - word.Name.Length);
                word.FinalX = word.X;
                word.FinalY = word.Y + word.Name.Length;
            }
        }

        private bool VerifyColision(HiddenWord word)
        {
            foreach (HiddenWord hidden in Words)
            {
                if (hidden != word)
                {
                    if (hidden.Orientation == word.Orientation)
                    {
                        if (hidden.Orientation == Orientation.HORIZONTAL)
                        {
                            if (hidden.Y == word.Y)
                            {
                                if (word.Y >= hidden.Y && word.Y <= hidden.FinalY
                                    || word.FinalY >= hidden.Y && word.FinalY <= hidden.FinalY)
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (hidden.X == word.X)
                            {
                                if (word.X >= hidden.X && word.X <= hidden.FinalX
                                    || word.FinalX >= hidden.X && word.FinalX <= hidden.FinalX)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (word.Orientation == Orientation.HORIZONTAL)
                        {
                            if (word.X <= hidden.X && word.FinalX >= hidden.X && word.Y >= hidden.Y && word.FinalY <= hidden.FinalY)
                                return true;
                        }
                        else
                        {
                            if (word.Y <= hidden.Y && word.FinalY >= hidden.Y && word.X >= hidden.X && word.X <= hidden.FinalX)
                                return true;
                        }
                    }
                }
            }

            return false;
        }


        public static void AddCoordinate(Point Coordinate)
        {

        }


        private static ChemicalElement[] Shuffle(ChemicalElement[] list)
        {
            var rnd = new Random();

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            return query.ToList().ToArray();
        }

    }
}
