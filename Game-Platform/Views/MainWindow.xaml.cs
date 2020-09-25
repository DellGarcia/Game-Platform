using Game_Platform.Models;
using Game_Platform.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Game_Platform
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Player Player { get; set; }

        private static MainWindow INSTANCE;

        private MainWindow(Player player)
        {
            Player = player;
            InitializeComponent();
            ShowPlayerInfo();
        }


        public static Window GetINSTANCE()
        {
            if (Application.Current.Properties["loggedPlayer"] == null)
                return new LoginView();

            if (INSTANCE == null)
            {
                INSTANCE = new MainWindow((Player)Application.Current.Properties["loggedPlayer"]);
            }


            return INSTANCE;
        }

        public static void DestroyInstance()
        {
            INSTANCE.Close();
        }

        private void ShowPlayerInfo()
        {
            txtUsername.Text = Player.Username;
            txtScore.Text = $"{Player.Vitorias}";
            txtFriends.Text = $"{Player.Friends.Count()}";
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri($"https://www.gravatar.com/avatar/{Player.HashEmail}?d=robohash", UriKind.Absolute);
            image.EndInit();
            imgGravatar.ImageSource = image;
        }

        private void HandleExit(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void PlayCosmosMemory(object sender, MouseButtonEventArgs e)
        {
            Hide();
            new Games.CosmosMemory.Views.InitView().Show();
        }

        private void PlayGlobalHangman(object sender, MouseButtonEventArgs e)
        {
            Hide();
            new Games.GlobalHangman.Views.InitView().Show();
        }

        private void PlayChemicalHunt(object sender, MouseButtonEventArgs e)
        {
            Hide();
            new Games.ChemicalHunt.Views.InitWindow().Show();
        }
    }
}
