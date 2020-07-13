using Game_Platform.Games.CosmosMemory.Controller;
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
    /// Lógica interna para EasyGameView.xaml
    /// </summary>
    public partial class EasyGameView : Window
    {
        Image[] images;
        TextBlock[] texts;
 
        public EasyGameView()
        {
            InitializeComponent();
            Init();
            new CardController(images, texts);
        }

        private void Init()
        {
            images = new Image[8];
            images[0] = card1;
            images[1] = card2;
            images[2] = card3;
            images[3] = card4;
            images[4] = card5;
            images[5] = card6;
            images[6] = card7;
            images[7] = card8;

            texts = new TextBlock[2];
            texts[0] = txtAcertos;
            texts[1] = txtErros;
        }
    }
}
