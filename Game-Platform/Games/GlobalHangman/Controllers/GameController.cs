using Game_Platform.Games.GlobalHangman.Models;
using Game_Platform.Games.GlobalHangman.Views;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game_Platform.Games.GlobalHangman.Controllers
{
    public class GameController
    {
        private static Button[] VirtualKeyBoard;
        private static Game Game;

        private static MainView Main;

        public GameController(MainView main, Button[] virtualKeyboard)
        {
            VirtualKeyBoard = virtualKeyboard;
            Main = main;

            Reset();

            foreach (Button btn in VirtualKeyBoard)
                btn.Click += Attemp;
        }

        public static void Reset()
        {
            Game = new Game();
            Main.Country.Text = Game.WordHidden;
            Main.Attemps.Text = $"{Game.Attemps}";

            foreach (Button btn in VirtualKeyBoard)
                btn.IsEnabled = true;
        }

        public static void CloseGame()
        {
            MainWindow.GetINSTANCE().Show();
            Main.Close();
        }

        public static void ShowFinalResult()
        {
            Main.Country.Text = Game.WordHidden;
            Main.Attemps.Text = $"{Game.Attemps}";
        }

        private void Attemp(object sender, System.Windows.RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            Game.Attempt(btn.Content.ToString());
            Main.Country.Text = Game.WordHidden;
            Main.Attemps.Text = $"{Game.Attemps}";
        }
    }
}
