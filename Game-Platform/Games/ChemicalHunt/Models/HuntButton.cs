using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game_Platform.Games.ChemicalHunt.Models
{
    public class HuntButton : Button
    {
        public bool Selected { get; set; }
        public Point Point { get; set; }

        public HuntButton()
        {
            IsEnabled = true;
            Selected = false;
            Click += Select;
            Width = 40;
            Height = 30;
        }

        private void Select(object obj, RoutedEventArgs args)
        {
            HuntButton btn = (HuntButton)obj;

            if (btn.Background == Brushes.GhostWhite)
            {
                Selected = true;

                btn.Background = Selected ? Brushes.DarkGreen : Brushes.GhostWhite;

                Game.AddCoordinate(Point);
            }            
        }
    }
}
