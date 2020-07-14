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

namespace Game_Platform.Games.CosmosMemory.Views
{
    /// <summary>
    /// Lógica interna para DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        private readonly string Message;

        public DialogBox(String mensagem)
        {
            InitializeComponent();

            Message = mensagem;
            Init();
        }

        private void Init()
        {
            txtMensagem.Text = Message;
            btnSair.Click += new RoutedEventHandler();
        }
    }
}
