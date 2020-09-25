using Game_Platform.Games.ChemicalHunt.ChemicalElementsApi;
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

namespace Game_Platform.Games.ChemicalHunt.Views
{
    /// <summary>
    /// Lógica interna para ChemicalView.xaml
    /// </summary>
    public partial class ChemicalView : Window
    {
        public ChemicalView(ChemicalElement chemical)
        {
            InitializeComponent();
            ChemicalName.Text = chemical.Name;
            ChemicalNumber.Text = $"{chemical.AtomicNumber}";
            ChemicalSymbol.Text = chemical.Symbol;
            ChemicalWeight.Text = $"{chemical.Weight}";

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(chemical.IconPath, UriKind.Relative);
            bi.EndInit();
            ChemicalIcon.Source = bi;
        }

        private void CloseView(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
