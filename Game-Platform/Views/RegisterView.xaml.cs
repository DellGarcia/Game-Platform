using Game_Platform.DAO;
using Game_Platform.Models;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

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
            PlayerDAO dao = new PlayerDAO();
            dao.SelectAll();
        }

        private void NavigateToLoginView(object sender, RoutedEventArgs e)
        {
            new LoginView().Show();
            Close();
        }

        private void RegisterAction()
        {
            if (txtSenha.Password == txtConfSenha.Password)
            {
                Player player = new Player
                {
                    Username = txtUsuario.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtSenha.Password
                };

                PlayerDAO dao = new PlayerDAO();
                dao.Insert(player);

                System.Windows.Forms.MessageBox.Show("Cadastro efetuado com sucesso, faça login para jogar!");

                new LoginView().Show();
                Close();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Senhas não coicidem");
            }
        }

        private void HandleRegister(object sender, RoutedEventArgs e)
        {
            RegisterAction();
        }

        private void HandleEnter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                System.Windows.Forms.MessageBox.Show("Enter");
            }
            System.Windows.Forms.MessageBox.Show("Click");
        }
    }
}
