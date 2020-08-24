using Game_Platform.Games.Forca.Models;
using Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode;
using Game_Platform.Games.Forca.Views;
using System.Windows.Controls;

namespace Game_Platform.Games.Forca.Controllers
{
    public class GameController
    {
        private readonly Button[] VirtualKeyBoard;
        private readonly Game Game;

        private readonly MainView Main;

        public GameController(MainView main, Button[] virtualKeyboard)
        {
            VirtualKeyBoard = virtualKeyboard;
            Game = new Game();
            Main = main;
            Main.Country.Text = Game.WordHidden;
            Main.Attemps.Text = $"{Game.Attemps}";

            foreach (Button btn in VirtualKeyBoard)
                btn.Click += Attemp;
        }

        private void Attemp(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            Game.Attempt(btn.Content.ToString());
            Main.Country.Text = Game.WordHidden;
            Main.Attemps.Text = $"{Game.Attemps}";
        }
    }
}
