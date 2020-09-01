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
            Selected = false;
            Click += Select;
            Width = 40;
            Height = 30;
        }

        private void Select(object obj, RoutedEventArgs args)
        {
            HuntButton btn = (HuntButton)obj;

            Selected = !Selected;

            btn.Background = Selected ? Brushes.Gold : Brushes.GhostWhite;

            Game.AddCoordinate(Point);
        }
    }
}
