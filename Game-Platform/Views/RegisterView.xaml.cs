using Game_Platform.DAO;
using Game_Platform.Models;
using System.Windows;
using System.Windows.Forms;

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

        private void HandleRegister(object sender, RoutedEventArgs e)
        {
            if(txtSenha.Password == txtConfSenha.Password)
            {
                Player player = new Player
                {
                    Username = txtUsuario.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtSenha.Password
                };

                PlayerDAO dao = new PlayerDAO();
                dao.Insert(player);

            } else
            {
                System.Windows.Forms.MessageBox.Show("Senhas não coicidem");
            }
        }
    }
}
