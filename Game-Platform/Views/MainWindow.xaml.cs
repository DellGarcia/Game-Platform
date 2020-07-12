using Game_Platform.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_Platform
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Player Player { get; set; }

        public MainWindow(Player player)
        {
            Player = player;
            InitializeComponent();
            ShowPlayerInfo();
        }

        private void ShowPlayerInfo()
        {
            txtUsername.Text = Player.Username;
            txtScore.Text = $"{Player.Vitorias}";
            txtFriends.Text =  $"{Player.Friends.Count()}";
        }

    }
}
