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
using System.Windows.Shapes;

namespace Game_Platform.Views
{
    /// <summary>
    /// Lógica interna para RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void NavigateToLoginView(object sender, RoutedEventArgs e)
        {
            new LoginView().Show();
            Close();
        }

        private void HandleRegister(object sender, RoutedEventArgs e)
        {
            if(txtSenha.Password == txtConfSenha.Password)
            {
                Player player = new Player();

                player.Username = txtUsuario.Text.Trim();
                player.Email = txtEmail.Text.Trim();
                player.Password = txtSenha.Password;

                MainWindow main = new MainWindow(player);
                main.Show();
                Close();
            } else
            {
                MessageBox.Show("Senhas não coicidem");
            }
        }
    }
}
