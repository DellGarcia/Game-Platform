using Game_Platform.DAO;
using Game_Platform.Models;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Input;
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
            
            if(Application.Current.Properties["loggedPlayer"] != null)
            {
                MainWindow.GetINSTANCE().Show();
                Close();
            }
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
                    Application.Current.Properties["loggedPlayer"] = player;
                    Window main = MainWindow.GetINSTANCE();
                    main.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Senha incorreta");
                }
            }
            else
            {
                MessageBox.Show("Email não cadastrado");
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
