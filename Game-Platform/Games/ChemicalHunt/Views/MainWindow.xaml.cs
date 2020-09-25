using Game_Platform.Games.ChemicalHunt.ChemicalElementsApi;
using Game_Platform.Games.ChemicalHunt.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Orientation = Game_Platform.Games.ChemicalHunt.Models.Orientation;

namespace Game_Platform.Games.ChemicalHunt.Views
{
    public partial class MainWindow : Window
    {
        public static TextBlock[] texts = new TextBlock[10];

        public static Button[,] Letters;

        private static MainWindow INSTANCE;

        private MainWindow()
        {
            InitializeComponent();
            CreateContainer();
            Game game = new Game();
            InsertHiddenWords();
            InsertElementsToList();
        }

        public static Window create()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new MainWindow();
            }
            return INSTANCE;
        }

        public static void destroy()
        {
            INSTANCE.Close();
            INSTANCE = null;
        }

        private void CreateContainer()
        {
            Letters = new Button[20, 20];
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Letters[i, j] = new HuntButton
                    {
                        Content = Convert.ToChar(random.Next(26) + 65),
                        Background = Brushes.GhostWhite,
                        Foreground = Brushes.Black,
                        BorderBrush = null,
                        Point = new Point(i, j),
                        FontSize = 13,
                        FontWeight = FontWeights.SemiBold
                    };
                    Grid.SetRow(Letters[i, j], i);
                    Grid.SetColumn(Letters[i, j], j);
                    HuntingWordsContainer.Children.Add(Letters[i, j]);
                }
            }
        }

        private void InsertHiddenWords()
        {
            var list = Game.Words;

            foreach (HiddenWord Word in list)
            {
                char[] array = Word.Name.ToCharArray();
                Array.Reverse(array);
                String Copy = Word.Reversed ? new String(array) : Word.Name;
                if (Word.Orientation == Orientation.HORIZONTAL)
                {
                    int index = 0;
                    for (int i = Word.X; i < Word.X + Word.Name.Length; i++)
                    {
                        Letters[i, Word.Y].Content = $"{Copy[index++]}".ToUpper();
                        //Letters[i, Word.Y].Foreground = Brushes.Red;    //Deixando palavras com a letra vermelha...para teste
                    }
                }
                else
                {
                    int index = 0;
                    for (int j = Word.Y; j < Word.Y + Word.Name.Length; j++)
                    {
                        Letters[Word.X, j].Content = $"{Copy[index++]}".ToUpper();
                        //Letters[Word.X, j].Foreground = Brushes.Red;    //Deixando palavras com a letra vermelha...para teste
                    }
                }
            }
        }

        private void InsertElementsToList()
        {
            ChemicalElement[] ch = Game.Words.ToArray();
            for (int i = 0; i < 10; i++)
            {
                texts[i] = new TextBlock()
                {
                    Text = ch[i].Name.ToUpper(),
                    Foreground = Brushes.GhostWhite,
                    FontSize = 20,
                    Margin = new Thickness(3),
                };
                texts[i].MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(ShowChemicalInfo);
                ElementsList.Children.Add(texts[i]);
            }
        }

        private void ShowChemicalInfo(object obj, RoutedEventArgs args)
        {
            ChemicalElement[] ch = Game.Words.ToArray();
            TextBlock tb = (TextBlock)obj;
            foreach (ChemicalElement el in ch)
            {
                if (el.Name.ToUpper() == tb.Text)
                {
                    new ChemicalView(el).ShowDialog();
                }
            }
        }

    }
}
