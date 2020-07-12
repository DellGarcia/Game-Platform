using Game_Platform.DAO;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace Game_Platform.Views
{
    /// <summary>
    /// Lógica interna para InitView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void NavigateToRegisterView(object sender, RoutedEventArgs e)
        {
            new RegisterView().Show();
            Close();
        }

        private void LoginAction()
        {
            String email = txtEmail.Text;
            String password = txtSenha.Password;

            Player player = new PlayerDAO().Select(email);

            if (player != null)
            {
                if (player.Password == password)
                {
                    MainWindow main = new MainWindow(player);
                    main.Show();
                    Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Senha incorreta");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Email não cadastrado");
            }
        }

        private void HandleLogin(object sender, RoutedEventArgs e)
        {
            LoginAction();
        }

        private void HandleEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               LoginAction();
            }
        }
    }
}
