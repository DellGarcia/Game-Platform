using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game_Platform.Games.ChemicalHunt.Views
{
    public partial class MainWindow : Window
    {
        private Button[,] Letters;


        public MainWindow()
        {
            InitializeComponent();
            CreateContainer();
        }

        private void CreateContainer()
        {
            Letters = new Button[20, 20];

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Letters[i, j] = new Button
                    {
                        Content = "L",
                        Background = Brushes.GhostWhite,
                        Foreground = Brushes.Black,
                        BorderBrush = null,
                        Margin = new Thickness(1)
                    };
                    Letters[i, j].Click += Select;
                    Grid.SetRow(Letters[i, j], i);
                    Grid.SetColumn(Letters[i, j], j);
                    HuntingWordsContainer.Children.Add(Letters[i,j]);
                }
            }
        }

        private void Select(object obj, RoutedEventArgs args)
        {
            Button btn = (Button)obj;
            btn.Background = Brushes.DarkGreen;
        }
    }
}
