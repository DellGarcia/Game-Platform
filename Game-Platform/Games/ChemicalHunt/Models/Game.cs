using Game_Platform.Games.ChemicalHunt.ChemicalElementsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Game_Platform.Games.ChemicalHunt.Views;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace Game_Platform.Games.ChemicalHunt.Models
{
    public class Game
    {

        private static Point start = new Point(21, 21);

        private static Point final = new Point(21, 21);

        private static Button[,] Letters = Views.MainWindow.Letters;

        private static int Acertos = 0;

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
                word.FinalX = word.X + word.Name.Length - 1;
                word.FinalY = word.Y;
            }
            else
            {
                word.X = random.Next(20);
                word.Y = random.Next(20 - word.Name.Length);
                word.FinalX = word.X;
                word.FinalY = word.Y + word.Name.Length - 1;
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
            if(start.X == 21 && start.Y == 21)
            {
                start = Coordinate;
            }
            else
            {
                if (start != Coordinate)
                {
                    final = Coordinate;
                    if (!VerificaSelecao())
                    {
                        Letters[(int)start.X, (int)start.Y].Background = Brushes.GhostWhite;
                        Letters[(int)final.X, (int)final.Y].Background = Brushes.GhostWhite;
                    } else
                    {
                        Acertos++;
                        if(Acertos == 10)
                        {
                            MessageBox.Show("Parabéns voce encontrou todas as palavras!");
                            MainWindow.GetINSTANCE().Show();
                            Views.MainWindow.destroy();
                        }
                    }
                    start.X = 21;
                    start.Y = 21;
                    final.X = 21;
                    final.Y = 21;
                }
            }            
        }

        public static bool VerificaSelecao()
        {
            foreach(HiddenWord word in Words)
            {
                if (word.X == start.X || word.X == final.X)
                {
                    if (word.Y == start.Y || word.Y == final.Y)
                    {
                        if(word.FinalX == final.X || word.FinalX == start.X)
                        {
                            if (word.FinalY == final.Y || word.FinalY == start.Y)
                            {
                                foreach(TextBlock text in Views.MainWindow.texts)
                                {
                                    if(text.Text.ToUpper() == word.Name.ToUpper())
                                    {
                                        text.TextDecorations = TextDecorations.Strikethrough;
                                        word.Located = true;
                                        WordFound();
                                        return true;
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static void WordFound()
        {
            foreach(HiddenWord Word in Words)
            {
                if (Word.Orientation == Orientation.HORIZONTAL)
                {
                    for (int i = Word.X; i < Word.X + Word.Name.Length; i++)
                    {
                        if (Word.Located)
                        {
                            Letters[i, Word.Y].Background = Brushes.DarkGreen;
                            Letters[i, Word.Y].Foreground = Brushes.GhostWhite;
                        }
                    }
                }
                else
                {
                    for (int j = Word.Y; j < Word.Y + Word.Name.Length; j++)
                    {
                        if (Word.Located)
                        {
                            Letters[Word.X, j].Background = Brushes.DarkGreen;
                            Letters[Word.X, j].Foreground = Brushes.GhostWhite;
                        }
                    }
                }
            }
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
